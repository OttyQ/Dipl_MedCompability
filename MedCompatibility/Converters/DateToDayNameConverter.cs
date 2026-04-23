using System.Globalization;

namespace MedCompatibility.Converters;

public class DateToDayNameConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is DateTime date)
            return date.ToString("ddd", new CultureInfo("ru-RU")).ToLower().TrimEnd('.');
        return "";
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
