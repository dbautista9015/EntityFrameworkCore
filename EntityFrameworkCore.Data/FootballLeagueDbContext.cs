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

    private string DbPath { get; set; }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Coach> Coaches { get; set; }

    // Adding connection string here is just for demo purposes
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // EnableSensitiveDataLogging and EnableDetailedErrors is for demo purposes
        // Do not use them in production
        optionsBuilder.UseSqlite($"Data Source={DbPath}")
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>().HasData(
            new Team
            {
                TeamId = 1,
                Name = "Tivoli Gardens FC",
                CreatedDate = DateTimeOffset.UtcNow.DateTime
            },
            new Team
            {
                TeamId = 2,
                Name = "Waterhouse F.C",
                CreatedDate = DateTimeOffset.UtcNow.DateTime
            },
            new Team
            {
                TeamId = 3,
                Name = "Humble Lions F.C.",
                CreatedDate = DateTimeOffset.UtcNow.DateTime
            }
        );
    }
}