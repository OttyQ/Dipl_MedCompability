using MedCompatibility.ViewModels.Patient;

namespace MedCompatibility.Pages.Patient;

public partial class MedicineDetailsPage : ContentPage
{
    public MedicineDetailsPage(MedicineDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}