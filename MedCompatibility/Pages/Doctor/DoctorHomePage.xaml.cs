using MedCompatibility.ViewModels.Doctor;

namespace MedCompatibility.Pages.Doctor;

public partial class DoctorHomePage : ContentPage
{
    private readonly DoctorHomeViewModel _vm;

    public DoctorHomePage(DoctorHomeViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.OnAppearingAsync();
    }
}