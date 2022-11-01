using Microsoft.EntityFrameworkCore;
using UFRCards.Data.Entities;

namespace UFRCards.Data;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    { }
    
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<GameRoom> GameRooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameRoom>()
            .OwnsOne(x => x.GameRoomSettings);

        modelBuilder.Entity<GameRound>()
            .HasKey(x => new { x.GameRoomId, x.RoundNumber });

        modelBuilder.Entity<GameRound>()
            .Ignore(x => x.AnswerIdsByPlayerId);
        
        base.OnModelCreating(modelBuilder);
    }
}