using MedCompatibility.ViewModels.Doctor;

namespace MedCompatibility.Pages.Doctor;

public partial class PrescriptionEditPage : ContentPage
{
    public PrescriptionEditPage(PrescriptionEditViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}