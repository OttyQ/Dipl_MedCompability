using MedCompatibility.ViewModels.Patient;

namespace MedCompatibility.Pages.Patient;

public partial class HistoryPage : ContentPage
{
    private readonly HistoryViewModel _viewModel;

    public HistoryPage(HistoryViewModel vm)
    {
        InitializeComponent();
        BindingContext = _viewModel = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Загружаем данные каждый раз при открытии вкладки
        await _viewModel.LoadHistoryCommand.ExecuteAsync(null);
    }
}