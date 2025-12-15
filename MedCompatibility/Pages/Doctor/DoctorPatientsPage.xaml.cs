using MedCompatibility.ViewModels.Doctor;

namespace MedCompatibility.Pages.Doctor;

public partial class DoctorPatientsPage : ContentPage
{
    private readonly DoctorPatientsViewModel _vm;

    public DoctorPatientsPage(DoctorPatientsViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_vm.LoadDataCommand.CanExecute(null))
            await _vm.LoadDataCommand.ExecuteAsync(null);
    }
}