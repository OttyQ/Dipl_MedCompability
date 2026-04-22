using MedCompatibility.ViewModels.Doctor;

namespace MedCompatibility.Pages.Doctor;

public partial class PrescriptionEditPage : ContentPage
{
    // Флаг для предотвращения рекурсии при программном изменении текста
    private bool _isFormatting;

    public PrescriptionEditPage(PrescriptionEditViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    /// <summary>
    /// Обработчик автоформатирования даты в формате ДД.ММ.ГГГГ.
    /// Автоматически вставляет точки-разделители при вводе цифр
    /// и корректно устанавливает позицию курсора.
    /// </summary>
    private void OnDateEntryTextChanged(object? sender, TextChangedEventArgs e)
    {
        if (_isFormatting || sender is not Entry entry)
            return;

        var oldText = e.OldTextValue ?? "";
        var newText = e.NewTextValue ?? "";

        // Если пользователь удаляет символы — не вмешиваемся
        if (newText.Length <= oldText.Length)
            return;

        // Извлекаем только цифры
        var digits = new string(newText.Where(char.IsDigit).ToArray());
        if (digits.Length > 8)
            digits = digits[..8];

        // Формируем строку с точками
        string formatted;
        if (digits.Length >= 5)
            formatted = $"{digits[..2]}.{digits[2..4]}.{digits[4..]}";
        else if (digits.Length >= 3)
            formatted = $"{digits[..2]}.{digits[2..]}";
        else
            formatted = digits;

        // Если форматированный текст совпадает — ничего не делаем
        if (formatted == newText)
            return;

        _isFormatting = true;
        entry.Text = formatted;

        // На Android установка CursorPosition сразу после Text не работает,
        // т.к. EditText обрабатывает изменения асинхронно.
        // Откладываем установку курсора через Dispatcher.
        var pos = formatted.Length;
        Dispatcher.Dispatch(() =>
        {
            entry.CursorPosition = pos;
            _isFormatting = false;
        });
    }

    private void OnStartDateSelected(object? sender, DateChangedEventArgs e)
    {
        if (BindingContext is PrescriptionEditViewModel vm)
        {
            vm.StartDate = e.NewDate.ToString("dd.MM.yyyy");
        }
    }

    private void OnEndDateSelected(object? sender, DateChangedEventArgs e)
    {
        if (BindingContext is PrescriptionEditViewModel vm)
        {
            vm.EndDate = e.NewDate.ToString("dd.MM.yyyy");
        }
    }
}