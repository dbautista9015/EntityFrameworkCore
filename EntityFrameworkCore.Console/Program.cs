using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

// First we need an instance of context
using var context = new FootballLeagueDbContext();

// Select all teams
// GetAllTeams();

// Selecting a single record - First one in the list
// var teamOne = await context.Coaches.FirstAsync();
// var teamOne = await context.Coaches.FirstOrDefaultAsync();

// Selecting a single record - First one in the list that meets a condition
// var teamTwo = await context.Teams.FirstAsync(team => team.TeamId == 1);
// var teamTwo = await context.Teams.FirstOrDefaultAsync(team => team.TeamId == 1);

// Selecting a single record - Only one record should be returned
// var teamThree = await context.Teams.SingleAsync();
// var teamThree = await context.Teams.SingleAsync(team => team.TeamId == 3);
// var teamFour = await context.Teams.SingleOrDefaultAsync(team => team.TeamId == 3);

// Selecting based on ID
var teamBasedOnId = await context.Teams.FindAsync(3);
if (teamBasedOnId is not null)
{
    Console.WriteLine(teamBasedOnId.Name);
}


void GetAllTeams()
{
    // SELECT * FROM TEAMS
    var teams = context.Teams.ToList();

    foreach (var t in teams)
    {
        Console.WriteLine(t.Name);
    }
    
}