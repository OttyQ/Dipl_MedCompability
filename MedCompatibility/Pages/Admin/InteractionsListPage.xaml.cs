using MedCompatibility.ViewModels.Admin;

namespace MedCompatibility.Pages.Admin;

public partial class InteractionsListPage : ContentPage
{
    private readonly InteractionsListViewModel _viewModel;

    public InteractionsListPage(InteractionsListViewModel vm)
    {
        InitializeComponent();
        BindingContext = _viewModel = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadDataCommand.ExecuteAsync(null);
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}