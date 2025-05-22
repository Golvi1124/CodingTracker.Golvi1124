using System.ComponentModel.DataAnnotations;

namespace CodingTracker.Golvi1124.Helpers;

public static class Extras
{
    public static string GetEnumDisplayName(Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute))
            as DisplayAttribute;
        return attribute == null ? value.ToString() : attribute.Name;
    }

    internal static bool AskSortDirection()
    {
        Console.Write("Sort records descending? (y/n): ");
        string input = Console.ReadLine()?.Trim().ToLower();

        return input == "y" || input == "yes";
    }
}