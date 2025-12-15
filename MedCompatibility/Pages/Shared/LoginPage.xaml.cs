using MedCompatibility.ViewModels.Shared;
using LoginViewModel = MedCompatibility.ViewModels.Shared.LoginViewModel;

namespace MedCompatibility.Pages.Shared;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is LoginViewModel vm)
            await vm.OnAppearingAsync();
    }
}

