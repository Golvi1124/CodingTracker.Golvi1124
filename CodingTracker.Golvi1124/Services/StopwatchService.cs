using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Spectre.Console;

namespace CodingTracker.Golvi1124.Services;

internal class StopwatchService
{
    internal (DateTime StartTime, DateTime EndTime, TimeSpan Duration) RunStopwatch()
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[green]Press [bold]Enter[/] to start the stopwatch...[/]");
        Console.ReadLine();

        var startTime = DateTime.Now;
        var stopwatch = Stopwatch.StartNew();

        AnsiConsole.MarkupLine("[yellow]Stopwatch started! Press [bold]Enter[/] again to stop.[/]\n");

        AnsiConsole.Live(new Markup(""))
            .Start(ctx =>
            {
                while (!Console.KeyAvailable)
                {
                    ctx.UpdateTarget(new Markup($"[blue]Elapsed time:[/] {stopwatch.Elapsed:hh\\:mm\\:ss}"));
                    Thread.Sleep(1000);
                }
            });

        Console.ReadLine(); // Consume the enter key
        stopwatch.Stop();
        var endTime = DateTime.Now;
        var duration = stopwatch.Elapsed;

        AnsiConsole.MarkupLine($"\n[bold green]Stopped! Total time: {duration}[/]");
        return (startTime, endTime, duration);
    }
}
