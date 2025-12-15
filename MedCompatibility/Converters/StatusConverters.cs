using System.Globalization;

namespace MedCompatibility.Converters;

public class BoolToTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool?)value == true ? "АКТИВЕН" : "БЛОК";
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}

public class BoolToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Зеленый (Success) если true, Красный (Error) если false
        return (bool?)value == true ? Color.FromArgb("#66BB6A") : Color.FromArgb("#FF5252");
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}

public class RoleToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string role = value as string ?? "";
        return role.ToLower() switch
        {
            "admin" => Color.FromArgb("#FF7043"),   // Оранжевый
            "doctor" => Color.FromArgb("#42A5F5"),  // Синий
            "patient" => Color.FromArgb("#26A69A"), // Бирюзовый
            _ => Colors.Gray
        };
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}