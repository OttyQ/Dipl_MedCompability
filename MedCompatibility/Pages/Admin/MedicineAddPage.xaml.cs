using MedCompatibility.ViewModels.Admin;

namespace MedCompatibility.Pages.Admin;

public partial class MedicineAddPage : ContentPage
{
    private MedicineAddViewModel _viewModel;

    public MedicineAddPage(MedicineAddViewModel vm)
    {
        InitializeComponent();
        BindingContext = _viewModel = vm;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        bool isValid = true;
        
        ResetBorders();

        // Валидация
        if (string.IsNullOrWhiteSpace(_viewModel.NewMedicine.TradeName))
        {
            SetError(NameBorder);
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(_viewModel.NewMedicine.INN))
        {
            SetError(MnnBorder);
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(_viewModel.NewMedicine.Form))
        {
            SetError(FormBorder);
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(_viewModel.NewMedicine.GTIN))
        {
            SetError(GtinBorder);
            isValid = false;
        }

        if (_viewModel.SelectedManufacturer == null)
        {
            SetError(ManufacturerBorder);
            isValid = false;
        }

        if (!isValid)
        {
            ErrorLabel.IsVisible = true;
        }
        else
        {
            // Если все ок - сохраняем
            if (_viewModel.SaveCommand.CanExecute(null))
            {
                _viewModel.SaveCommand.Execute(null);
            }
        }
    }

    private void SetError(Border border)
    {
        if (border != null)
        {
            border.Stroke = Colors.Red;
        }
    }

    private void ResetBorders()
    {
        Color transparent = Colors.Transparent;
        
        NameBorder.Stroke = transparent;
        MnnBorder.Stroke = transparent;
        FormBorder.Stroke = transparent;
        GtinBorder.Stroke = transparent;
        ManufacturerBorder.Stroke = transparent;
        
        ErrorLabel.IsVisible = false;
    }
}
