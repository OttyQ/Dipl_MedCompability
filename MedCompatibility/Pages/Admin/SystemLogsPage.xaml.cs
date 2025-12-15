using MedCompatibility.ViewModels.Admin;

namespace MedCompatibility.Pages.Admin;

public partial class SystemLogsPage : ContentPage
{
    private readonly SystemLogsViewModel _viewModel;

    public SystemLogsPage(SystemLogsViewModel vm)
    {
        InitializeComponent();
        BindingContext = _viewModel = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Автоматическая загрузка при открытии
        _viewModel.LoadLogsCommand.Execute(null);
    }

    // Обработчик кнопки "Назад"
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}