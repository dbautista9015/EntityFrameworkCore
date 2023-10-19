using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Data;

public class FootballLeagueDbContext : DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Coach> Coaches { get; set; }

    // Adding connection string here is just for demo purposes
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=FootballLeague_EfCore.db");
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