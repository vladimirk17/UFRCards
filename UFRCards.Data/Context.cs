using Microsoft.EntityFrameworkCore;
using UFRCards.Data.Entities;

namespace UFRCards.Data;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {

    }
    
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
}