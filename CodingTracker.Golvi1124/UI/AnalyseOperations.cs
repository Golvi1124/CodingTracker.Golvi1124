using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Golvi1124.UI;

internal class AnalyseOperations
{
    internal static void FilterPerPeriod()
    { 
        Console.WriteLine("Coming soon...");
        /* Let the user filter their coding records per period (weeks, days, years) and/or order ascending or descending.
     ...make this just a filter for range and by specific times together with averaget etc in next method

 *  Make helper method for ascending or descending to use accross
        
        Show data range. Oldest date and newest date (Don't show records, just the dates)
        Validate the dates and don't allow older date to be after the newer date.
        Don't allow to choose a date range that is not in the records.
        Ask if want to see descending or ascending order.
        
        "Found 5 records between 2023-01-01 and 2023-01-05"
            + Show records in a table.
         */
    }



    internal static void ViewTotalAndAverage()
    {
        Console.WriteLine("Coming soon...");
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


        Make % of goal reached. Including if over the goal. Play with colors.
         */
    }



}
