using System.ComponentModel.DataAnnotations;

namespace CodingTracker.Golvi1124.Helpers;

public static class DisplayHelper
{
    public static string GetEnumDisplayName(Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute))
            as DisplayAttribute;
        return attribute == null ? value.ToString() : attribute.Name;
    }
}