using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class FootballContext : DbContext
{
    public DbSet<MatchData> MatchData { get; set; }

    public FootballContext(DbContextOptions<FootballContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source=MatchAnalysis.db");
    }
}