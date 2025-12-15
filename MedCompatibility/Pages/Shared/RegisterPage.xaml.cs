using MedCompatibility.ViewModels.Shared;

namespace MedCompatibility.Pages.Shared;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}