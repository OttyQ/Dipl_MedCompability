using MedCompatibility.ViewModels.Admin;

namespace MedCompatibility.Pages.Admin;

public partial class MedicinesListPage : ContentPage
{
    private readonly MedicinesListViewModel _viewModel;

    public MedicinesListPage(MedicinesListViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }
}