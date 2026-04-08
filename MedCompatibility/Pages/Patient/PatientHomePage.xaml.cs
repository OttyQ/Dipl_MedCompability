using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedCompatibility.ViewModels.Patient;

namespace MedCompatibility.Pages.Patient;

public partial class PatientHomePage : ContentPage
{
    public PatientHomePage(PatientHomePageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is PatientHomePageViewModel vm)
            await vm.OnAppearingAsync();
    }
}