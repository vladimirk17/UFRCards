using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UFRCards.API.Hubs;
using UFRCards.Business.Dto;
using UFRCards.Business.Interfaces;
using UFRCards.Business.Services;
using UFRCards.Data;
using UFRCards.Data.Utilities;

var builder = WebApplication.CreateBuilder(args);

//Services

builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddSignalR();

builder.Services.AddDbContext<Context>(options =>
{
    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    var migrationAssembly = typeof(Context).Namespace;

    var connectionString = string.Empty;

    if (env == "Development")
    {
        connectionString = builder.Configuration.GetConnectionString("defaultConnection");
    }
    else
    {
        //Complete upon deploy
    }

    options.UseNpgsql(connectionString, optionsBuilder =>
        optionsBuilder.MigrationsAssembly(migrationAssembly));
});

var mapperConfiguration = new MapperConfiguration(config =>
{
    config.AddProfile<MappingProfile>();
});

var mapper = mapperConfiguration.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IGameSessionService, GameSessionService>();
builder.Services.AddScoped<IConnectionService, ConnectionService>();

var app = builder.Build();

//Middleware

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<Context>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    await DbInitializer.Initialize(context);
}
catch (Exception exception)
{
    logger.LogError(exception, "Problem with data migration");
}

app.UseCors(options =>
{
    options
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithOrigins("http://localhost:3000");
});

app.MapControllers();
app.MapHub<GameHub>("/game");

app.MapGet("/", () => "Hello World!");

await app.RunAsync();