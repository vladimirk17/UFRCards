using Microsoft.EntityFrameworkCore;
using UFRCards.Data.Entities;

namespace UFRCards.Data;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    { }
    
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<GameSession> GameSessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameSession>()
            .OwnsOne(x => x.GameSessionSettings);

        modelBuilder.Entity<GameRound>()
            .HasKey(x => new { GameRoomId = x.GameSessionId, x.RoundNumber });

        modelBuilder.Entity<GameRound>()
            .HasMany(x => x.PlayerAnswersSelections)
            .WithOne(x => x.GameRound);
        
        base.OnModelCreating(modelBuilder);
    }
}