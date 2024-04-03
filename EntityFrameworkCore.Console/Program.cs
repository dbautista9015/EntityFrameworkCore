using EntityFrameworkCore.Data;

// First we need an instance of the context
using var context = new FootballLeagueDbContext();

GetAllTeams();

void GetAllTeams()
{
    // SELECT * FROM teams
    var teams = context.Teams.ToList();

    foreach (var team in teams)
    {
        Console.WriteLine(team.Name);
    }
}
