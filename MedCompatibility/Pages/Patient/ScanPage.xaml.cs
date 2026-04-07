using MedCompatibility.ViewModels.Patient;

namespace MedCompatibility.Pages.Patient;

public partial class ScanPage : ContentPage
{
    public ScanPage(ScanPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    
    // Вызывается каждый раз, когда мы переходим на эту вкладку
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        
        // Проверяем, не сменился ли аккаунт
        if (BindingContext is ScanPageViewModel vm)
        {
            vm.CheckAndClearSessionState();
        }
    }
}