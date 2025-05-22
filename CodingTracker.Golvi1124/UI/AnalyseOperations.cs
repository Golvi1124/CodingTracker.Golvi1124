using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using CodingTracker.Golvi1124.Models;
using CodingTracker.Golvi1124.Helpers;

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

        PeriodType selectedPeriod = AskPeriodType();

        /* Create reports where the users can see their total and average coding session per period.
         
* create sorting method to use here and in the next method
            
        Make some sort of calendar, where can see info that there is a record on that date.
        Menu choices for year, month, week, day.
        "In selected period you coded X times
              - with total of X hours X minutes
              - with average of X hours X minutes per session
              - with average of X hours X minutes per this period
         */
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
