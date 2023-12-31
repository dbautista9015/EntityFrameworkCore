﻿using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

// First we need an instance of context
using var context = new FootballLeagueDbContext();

// Select all teams
// await GetAllTeams()
// await GetAllTeamsQuerySyntax();

// Select one team
// await GetOneTeam()

// Select all record that meet a condition
// await GetFilteredTeams();

// Aggregate Methods
// await AggregateMethods();

// Grouping and Aggregating
// GroupByMethod();

//Ordering
// await OrderByMethods();

// Skip and Take - Great for Paging
var recordCount = 3;
var page = 0;
var next = true;

while (next)
{
    var teams = await context.Teams.Skip(page * recordCount).Take(recordCount).ToListAsync();

    foreach (var team in teams)
    {
        Console.WriteLine(team.Name);
    }
    Console.WriteLine("Enter 'true' for the next set of records, 'false' to exit");
    next = Convert.ToBoolean(Console.ReadLine());

    if (!next) break;
    page += 1;
}

async Task OrderByMethods()
{
// Ordering
    var orderedTeams = await context.Teams
        .OrderBy(q => q.Name)
        .ToListAsync();

    foreach (var item in orderedTeams)
    {
        Console.WriteLine(item.Name);
    }

    var descOrderedTeams = await context.Teams
        .OrderByDescending(q => q.Name)
        .ToListAsync();

    foreach (var item in descOrderedTeams)
    {
        Console.WriteLine(item.Name);
    }

// Getting the record with a maximum value
    var maxByDescendingOrder = await context.Teams
        .OrderByDescending(q => q.TeamId)
        .FirstOrDefaultAsync();

// Alternative to the one above
    var maxBy = context.Teams.MaxBy(q => q.TeamId);

    var minByDescendingOrder = await context.Teams
        .OrderByDescending(q => q.TeamId)
        .FirstOrDefaultAsync();

// Alternative to the one above
    var minBy = context.Teams.MinBy(q => q.TeamId);
    
}

void GroupByMethod()
{
    var groupedTeams = context.Teams
        // .Where(q => q.Name == '') Translates to a WHERE clause
        .GroupBy(q => q.CreatedDate.Date)
        // .Where()... Translates to a HAVING clause
        .ToList();
    foreach (var group in groupedTeams)
    {
        Console.WriteLine(group.Key);
        Console.WriteLine(group.Sum(q => q.TeamId));
    
        foreach (var team in group)
        {
            Console.WriteLine(team.Name);
        }
    }
}

async Task AggregateMethods()
{
    var numberOfTeams = await context.Teams.CountAsync();
    Console.WriteLine($"Number of Teams: {numberOfTeams}");

    // Count
    var numberOfTeamsWithCondition = await context.Teams.CountAsync(q => q.TeamId == 1);
    Console.WriteLine($"Number of Teams with condition above {numberOfTeamsWithCondition}");

    // Max
    var maxTeams = await context.Teams.MaxAsync(q => q.TeamId);
    // Min
    var minTeams = await context.Teams.MinAsync(q => q.TeamId);
    // Average
    var avgTeams = await context.Teams.AverageAsync(q => q.TeamId);
    // Sum
    var sumTeams = await context.Teams.SumAsync(q => q.TeamId);
}

async Task GetAllTeamsQuerySyntax()
{
    Console.WriteLine("Enter Search Term");
    var searchTerm = Console.ReadLine();

    var teams = await (from team in context.Teams
            where EF.Functions.Like(team.Name, $"%{searchTerm}%")
            select team)
        .ToListAsync();
    foreach (var t in teams)
    {
        Console.WriteLine(t.Name);
    }
}

async Task GetFilteredTeams()
{
    Console.WriteLine("Enter Search Team");
    var searchTerm = Console.ReadLine();
    
    var teamsFiltered = await context.Teams.Where(q => q.Name == searchTerm).ToListAsync();
    foreach (var item in teamsFiltered)
    {
        Console.WriteLine(item.Name);
    }

    // var partialMatches = await context.Teams.Where(q => q.Name.Contains(searchTerm)).ToListAsync();
    var partialMatches = await context.Teams
        .Where(q => EF.Functions.Like(q.Name, $"%{searchTerm}%"))
        .ToListAsync();
    foreach (var item in partialMatches)
    {
        Console.WriteLine(item.Name);
    }
}

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