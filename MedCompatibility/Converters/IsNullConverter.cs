using System.Globalization;

namespace MedCompatibility.Converters;

public class IsNullConverter : IValueConverter
{
    // Возвращает True, если значение NULL
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value == null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}