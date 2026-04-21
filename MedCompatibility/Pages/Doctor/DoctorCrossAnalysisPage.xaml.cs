using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedCompatibility.ViewModels;
using MedCompatibility.ViewModels.Doctor;


namespace MedCompatibility.Pages.Doctor;


public partial class DoctorCrossAnalysisPage : ContentPage
{
    public DoctorCrossAnalysisPage(DoctorCrossAnalysisViewModel vm)
    {
        InitializeComponent();
        
        // Устанавливаем BindingContext, чтобы XAML "видел" свойства и команды во ViewModel
        BindingContext = vm;
    }

    // Здесь можно переопределить методы жизненного цикла страницы, если это необходимо
    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        // Например, если нужно что-то обновить при каждом открытии страницы, 
        // можно вызвать метод во ViewModel:
        // if (BindingContext is DoctorCrossAnalysisViewModel vm) { ... }
    }
}