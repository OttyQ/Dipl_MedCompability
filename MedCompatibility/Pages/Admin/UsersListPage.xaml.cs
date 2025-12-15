namespace MedCompatibility.Pages.Admin;
using MedCompatibility.ViewModels.Admin;

public partial class UsersListPage : ContentPage
{
    private readonly UsersListViewModel _vm;
    
    public UsersListPage(UsersListViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Используем правильное имя команды из ViewModel
        if (_vm.LoadDataCommand.CanExecute(null))
        {
            _vm.LoadDataCommand.Execute(null);
        }
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    
    
}