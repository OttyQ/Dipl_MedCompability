using CommunityToolkit.Maui.Views;
using MedCompatibility.Models;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class AddManufacturerPopup : Popup
{
    public AddManufacturerPopup()
    {
        InitializeComponent();
        CountryPicker.SelectedIndex = 0; // РБ по умолчанию
        
        // Сразу блокируем кнопку при старте
        UpdateCreateButtonState();
    }
    
    // Вызывается при изменении текста названия
    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateCreateButtonState();
    }

    private void UpdateCreateButtonState()
    {
        // Кнопка активна, только если название не пустое
        bool isValid = !string.IsNullOrWhiteSpace(NameEntry.Text);
        
        CreateBtn.IsEnabled = isValid;
        // Визуально показываем доступность (0.5 - бледно, 1.0 - ярко)
        CreateBtn.Opacity = isValid ? 1.0 : 0.5; 
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text)) return;

        var result = new manufacturer
        {
            Name = NameEntry.Text,
            Country = CountryPicker.SelectedItem?.ToString(),
            City = CityEntry.Text,
            Description = DescEntry.Text
        };

        Close(result);
    }

    private void OnCancelClicked(object sender, EventArgs e) => Close(null);
}