using MedCompatibility.Services.Interfaces;
using MedCompatibility.ViewModels.Doctor;

namespace MedCompatibility.Pages.Doctor;

public partial class DoctorPatientCardPage : ContentPage
{
    private readonly ILoadingService _loadingService;

    public DoctorPatientCardPage(DoctorPatientCardViewModel vm, ILoadingService loadingService)
    {
        InitializeComponent();
        BindingContext = vm;
        _loadingService = loadingService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Небольшая задержка чтобы не конфликтовать с LoadDataAsync при первом открытии
        await Task.Delay(150);
        _loadingService.Hide();
    }
}