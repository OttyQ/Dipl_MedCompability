using MedCompatibility.ViewModels.Patient;

namespace MedCompatibility.Pages.Patient;

public partial class CompatibilityPage : ContentPage
{
    public CompatibilityPage(CompatibilityViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        
    }
    
    private async void OnBackClicked(object sender, EventArgs e)
    {
        // 1. Анимация нажатия (вдавливание и возврат)
        if (sender is View view)
        {
            await view.ScaleTo(0.85, 100, Easing.CubicOut); // Сжимаем за 100 мс
            await view.ScaleTo(1.0, 100, Easing.CubicIn);   // Возвращаем обратно
        }

        // 2. Переход назад
        await Shell.Current.GoToAsync("..");
    }
}