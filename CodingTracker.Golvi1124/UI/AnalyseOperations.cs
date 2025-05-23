using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using CodingTracker.Golvi1124.Models;
using CodingTracker.Golvi1124.Helpers;
using static CodingTracker.Golvi1124.UI.Enums;
using CodingTracker.Golvi1124.Data;

namespace CodingTracker.Golvi1124.UI;

internal class AnalyseOperations
{
    internal static void FilterPerPeriod(IEnumerable<CodingRecord> records)
    {
        Console.Clear();

        if (!records.Any())
        {
            AnsiConsole.MarkupLine("[red]No records found in the system.[/]");
            return;
        }

        var oldestRecord = records.Min(r => r.DateStart);
        var newestRecord = records.Max(r => r.DateStart);

        Console.WriteLine("Now you need to choose period you want to see records from.");
        AnsiConsole.MarkupLine($"In system, records are from [green]{oldestRecord:dd-MM-yy}[/] to [green]{newestRecord:dd-MM-yy}[/]");

        // Prompt for start date
        DateTime startDate = Validation.GetValidDate(
            "Enter the start date (dd-MM-yy):",
            date => date.Date >= oldestRecord.Date && date.Date <= newestRecord.Date
        );

        // Prompt for end date
        DateTime endDate = Validation.GetValidDate(
            "Enter the end date (dd-MM-yy):",
            date => date.Date >= startDate.Date && date.Date <= newestRecord.Date
        );

        // Ask for sort order
        bool isDescending = Extras.AskSortDirection();

        // Filter and sort records
        var filtered = records
            .Where(r => r.DateStart.Date >= startDate.Date && r.DateStart.Date <= endDate.Date)
            .OrderBy(r => isDescending ? -r.DateStart.Ticks : r.DateStart.Ticks)
            .ToList();

        AnsiConsole.MarkupLine($"[blue]Found {filtered.Count} records between {startDate:dd-MM-yy} and {endDate:dd-MM-yy}[/]");

        if (filtered.Any())
        {
            RecordOperations.ViewRecords(filtered);
        }
        else
        {
            AnsiConsole.MarkupLine("[red]No records found in the selected date range.[/]");
        }
    }




    internal static void ViewTotalAndAverage()
    {
        Console.Clear();
        var allRecords = new DataAccess().GetAllRecords();

        PeriodType period = Extras.AskPeriodType();

        if (period == PeriodType.Back)
            return;

        var range = Extras.AskDateRangeForPeriod(period);

        var recordsInRange = allRecords
            .Where(r => r.DateStart >= range.Start && r.DateStart <= range.End)
            .ToList();

        Console.Clear();

        if (!recordsInRange.Any())
        {
            AnsiConsole.MarkupLine($"[red]No records found between {range.Start:dd-MM-yy} and {range.End:dd-MM-yy}.[/]");
            return;
        }

        int sessionCount = recordsInRange.Count;
        double totalMinutes = recordsInRange.Sum(r => r.Duration.TotalMinutes);
        TimeSpan totalDuration = TimeSpan.FromMinutes(totalMinutes);

        double averagePerSessionMinutes = totalMinutes / sessionCount;
        TimeSpan averagePerSession = TimeSpan.FromMinutes(averagePerSessionMinutes);

        double periodDays = (range.End - range.Start).TotalDays + 1;
        double averagePerDayMinutes = totalMinutes / periodDays;
        TimeSpan averagePerDay = TimeSpan.FromMinutes(averagePerDayMinutes);

        AnsiConsole.MarkupLine($"[blue]In selected period ({range.Start:dd-MM-yy} to {range.End:dd-MM-yy}):[/]");
        AnsiConsole.MarkupLine($"[green]• Sessions:[/] {sessionCount}");
        AnsiConsole.MarkupLine($"[green]• Total time:[/] {totalDuration.Hours}h {totalDuration.Minutes % 60}m");
        AnsiConsole.MarkupLine($"[green]• Avg per session:[/] {averagePerSession.Hours}h {averagePerSession.Minutes % 60}m");
        AnsiConsole.MarkupLine($"[green]• Avg per day:[/] {averagePerDay.Hours}h {averagePerDay.Minutes % 60}m");

        Console.WriteLine();
        AnsiConsole.MarkupLine("[grey]Press any key to return to the Analyse Menu...[/]");
        Console.ReadKey();
    }


    internal static void IsGoalReached()
    {
        Console.WriteLine("Coming soon...");
        /*Create the ability to set coding goals and show how far the users are from reaching their goal, 
         along with how many hours a day they would have to code to reach their goal.  


        Make % of goal reached. Including if over the goal. Play with colors. Add emojis? xD
         */
    }







}
