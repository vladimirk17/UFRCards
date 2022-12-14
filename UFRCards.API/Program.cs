using Microsoft.EntityFrameworkCore;
using UFRCards.Business.Interfaces;
using UFRCards.Business.Services;
using UFRCards.Data;
using UFRCards.Data.Utilities;

var builder = WebApplication.CreateBuilder(args);

//Services

builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddDbContext<UfrContext>(options =>
{
    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    var migrationAssembly = typeof(UfrContext).Namespace;
    
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

builder.Services.AddScoped<ICardService, CardService>();

var app = builder.Build();

//Middleware

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<UfrContext>();
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
        .WithOrigins("http://localhost:3000");
});

app.MapControllers();

app.MapGet("/", () => "Hello World!");

await app.RunAsync();