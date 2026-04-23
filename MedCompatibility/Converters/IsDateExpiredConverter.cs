using System.Globalization;
using Microsoft.Maui.Controls;
using System;

namespace MedCompatibility.Converters;

public class IsDateExpiredConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is DateTime endDate)
            return endDate.Date < DateTime.Today;
        return false;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
