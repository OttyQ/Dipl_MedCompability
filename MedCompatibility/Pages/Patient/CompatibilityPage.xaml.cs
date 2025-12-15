using MedCompatibility.ViewModels.Patient;

namespace MedCompatibility.Pages.Patient;

public partial class CompatibilityPage : ContentPage
{
    public CompatibilityPage(CompatibilityViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}