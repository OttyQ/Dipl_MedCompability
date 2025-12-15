using MedCompatibility.ViewModels.Patient;

namespace MedCompatibility.Pages.Patient;

public partial class ScanPage : ContentPage
{
    public ScanPage(ScanPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}