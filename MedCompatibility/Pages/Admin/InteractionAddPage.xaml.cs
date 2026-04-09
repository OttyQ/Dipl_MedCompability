namespace MedCompatibility.Pages.Admin;
using MedCompatibility.ViewModels.Admin;

public partial class InteractionAddPage : ContentPage
{
    public InteractionAddPage(InteractionAddViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}