using System.Globalization;
using MedCompatibility.Models;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;
using System;

namespace MedCompatibility.Converters;

public class DayTypeToColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is DayType type)
        {
            return type switch
            {
                DayType.ActiveFuture => Color.FromArgb("#00796B"),
                DayType.ActivePast => Color.FromArgb("#80CBC4"),
                DayType.Expired => Color.FromArgb("#FFE082"),
                _ => Colors.Transparent
            };
        }
        return Colors.Transparent;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
