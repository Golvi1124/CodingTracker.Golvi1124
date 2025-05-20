using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using static CodingTracker.Golvi1124.UI.Enums;

namespace CodingTracker.Golvi1124.UI;

internal static class UserInterface
{
    internal static void MainMenu()
    {
        var isMenuRunning = true;

        while (isMenuRunning)
        {
            var usersChoice = AnsiConsole.Prompt(
                   new SelectionPrompt<MainMenuChoices>()
                    .Title("What would you like to do?")
                    .AddChoices(
                       MainMenuChoices.AddRecord,
                       MainMenuChoices.ViewRecords,
                       MainMenuChoices.UpdateRecord,
                       MainMenuChoices.DeleteRecord,
                       MainMenuChoices.Quit)
                    );

            switch (usersChoice)
            {
                case MainMenuChoices.AddRecord:
                    AddRecord();
                    break;
                case MainMenuChoices.ViewRecords:
                    ViewRecords();
                    break;
                case MainMenuChoices.UpdateRecord:
                    UpdateRecord();
                    break;
                case MainMenuChoices.DeleteRecord:
                    DeleteRecord();
                    break;
                case MainMenuChoices.Quit:
                    System.Console.WriteLine("Goodbye");
                    isMenuRunning = false;
                    break;
            }
        }
    }

    private static void DeleteRecord()
    {

    }

    private static void UpdateRecord()
    {

    }

    private static void ViewRecords()
    {

    }

    private static void AddRecord()
    {

    }
}

