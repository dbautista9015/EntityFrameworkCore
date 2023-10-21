using System.Net.Mime;
using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

// First we need an instance of context
using var context = new FootballLeagueDbContext();

// Select all teams
// await GetAllTeams()

// Select one team
// await GetOneTeam()

async Task GetAllTeams()
{
    // SELECT * FROM Teams
    var teams = await context.Teams.ToListAsync();

    foreach (var t in teams)
    {
        Console.WriteLine(t.Name);
    }
}

async Task GetOneTeam()
{
    var teamFirst = await context.Coaches.FindAsync();
    if (teamFirst is not null)
    {
        Console.WriteLine(teamFirst.Name);
    }
    
    var teamFirstOrDefault = await context.Coaches.FirstOrDefaultAsync();
    if (teamFirstOrDefault is not null)
    {
        Console.WriteLine(teamFirstOrDefault.Name);
    }
    
    // Selecting a single record - First one in the list that meets a condition
    var teamFirstWithCondition = await context.Teams.FirstAsync(team => team.TeamId == 1);
    if (teamFirstWithCondition is not null)
    {
        Console.WriteLine(teamFirstWithCondition.Name);
    }

    var teamFirstOrDefaultWithCondition = await context.Teams.FirstOrDefaultAsync(team => team.TeamId == 1);
    if (teamFirstOrDefaultWithCondition is not null)
    {
        Console.WriteLine(teamFirstOrDefaultWithCondition.Name);
    }
    
    // Selecting a single record - Only one record should be returned, or an exception will be thrown
    var teamSingle = await context.Teams.SingleAsync();
    if (teamSingle is not null)
    {
        Console.WriteLine(teamSingle.Name);
    }

    var teamSingleWithCondition = await context.Teams.SingleAsync(team => team.TeamId == 2);
    if (teamSingleWithCondition is not null)
    {
        Console.WriteLine(teamSingleWithCondition.Name);
    }

    var singleOrDefault = await context.Teams.SingleOrDefaultAsync(team => team.TeamId == 2);
    if (singleOrDefault is not null)
    {
        Console.WriteLine(singleOrDefault.Name);
    }
    
    // Selecting based on Primary Key Id value
    var teamBasedOnId = await context.Teams.FindAsync(3);
    if (teamBasedOnId is not null)
    {
        Console.WriteLine(teamBasedOnId.Name);
    }
}