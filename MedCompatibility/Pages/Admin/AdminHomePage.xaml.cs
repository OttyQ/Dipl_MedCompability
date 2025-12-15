using MedCompatibility.ViewModels.Admin;

namespace MedCompatibility.Pages.Admin;

public partial class AdminHomePage : ContentPage
{
    public AdminHomePage(AdminHomeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is AdminHomeViewModel vm)
            await vm.OnAppearingAsync();
    }
}