using MedCompatibility.ViewModels.Doctor;

namespace MedCompatibility.Pages.Doctor;

public partial class DoctorHomePage : ContentPage
{

    public DoctorHomePage(DoctorHomeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is DoctorHomeViewModel vm)
            await vm.OnAppearingAsync();
    }
}