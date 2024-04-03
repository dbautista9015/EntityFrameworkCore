using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore.Data;

public class FootballLeagueDbContext : DbContext
{
    public FootballLeagueDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Combine(path, "FootballLeague_EfCore.db");
    }


    public DbSet<Team> Teams { get; set; }
    public DbSet<Coach> Coaches { get; set; }
    public string DbPath { get; private set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        // Do not use EnableSensitiveData and Detailed for production
        // Only for educational purposes
        optionsBuilder.UseSqlite($"Data Source={DbPath}")
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Team>().HasData(
            new Team
            {
                TeamId = 1,
                Name = "Tivoli Gardens F.C.",
                CreatedDate = DateTimeOffset.UtcNow.DateTime,
            },
            new Team
            {
                TeamId = 2,
                Name = "Waterhouse F.C.",
                CreatedDate = DateTimeOffset.UtcNow.DateTime,
            },
            new Team
            {
                TeamId = 3,
                Name = "Humble Lions F.C.",
                CreatedDate = DateTimeOffset.UtcNow.DateTime,
            }
        );
    }
}