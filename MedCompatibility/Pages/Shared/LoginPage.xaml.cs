using MedCompatibility.ViewModels.Shared;

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
        {
            // ключ: если вернулись на страницу — мгновенно гасим возможный "зависший" лоадер
            vm.CancelGoogleAuthUiFromPage();

            await vm.OnAppearingAsync();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        if (BindingContext is LoginViewModel vm)
        {
            // на всякий случай: при уходе со страницы тоже не оставляем лоадер висеть
            vm.CancelGoogleAuthUiFromPage();
        }
    }
}