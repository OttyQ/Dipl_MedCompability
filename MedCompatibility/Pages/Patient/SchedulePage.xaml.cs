using MedCompatibility.ViewModels.Patient;

namespace MedCompatibility.Pages.Patient;

public partial class SchedulePage : ContentPage
{
    public SchedulePage(ScheduleViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is ScheduleViewModel vm)
            await vm.InitializeAsync();
    }

    private void OnDatePickerSelected(object sender, DateChangedEventArgs e)
    {
        if (BindingContext is ScheduleViewModel vm)
            vm.SelectDateCommand.Execute(e.NewDate);
    }
}
