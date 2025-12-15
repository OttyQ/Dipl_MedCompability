using MedCompatibility.ViewModels.Doctor;

namespace MedCompatibility.Pages.Doctor;

public partial class DoctorPatientCardPage : ContentPage
{
    private readonly DoctorPatientCardViewModel _vm;

    public DoctorPatientCardPage(DoctorPatientCardViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadDataCommand.ExecuteAsync(null);
    }
}