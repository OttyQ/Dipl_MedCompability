using MedCompatibility.ViewModels.Doctor;

namespace MedCompatibility.Pages.Doctor;

public partial class DoctorPatientCardPage : ContentPage
{
    public DoctorPatientCardPage(DoctorPatientCardViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}