using Microsoft.EntityFrameworkCore;
using UFRCards.Data.Entities;

namespace UFRCards.Data;

public class UfrContext : DbContext
{
    public UfrContext(DbContextOptions options) : base(options)
    {

    }
    
    public DbSet<Card> Cards { get; set; }
}