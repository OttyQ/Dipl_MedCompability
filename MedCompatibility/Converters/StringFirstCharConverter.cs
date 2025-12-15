using System.Globalization;

namespace MedCompatibility.Converters;

public class StringFirstCharConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Проверяем, что пришла строка и она не пустая
        if (value is string text && !string.IsNullOrWhiteSpace(text))
        {
            // Возвращаем первый символ в верхнем регистре
            return text[0].ToString().ToUpper();
        }

        // Если пришло null или пустота — возвращаем заглушку (например, знак вопроса или иконку)
        return "?"; 
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}