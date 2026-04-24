using CommunityToolkit.Maui.Views;
using MedCompatibility.Models;
using MedCompatibility.ViewModels;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class InteractionsDetailsPopup : Popup
{
    public InteractionsDetailsPopup(List<interaction> interactions, bool hasCritical, user patient = null, string doctorName = "", List<medicine> pastConflictingDrugs = null, medicine targetDrug = null, List<medicine> currentPrescriptions = null)
    {
        InitializeComponent();

        var vm = App.Current.Handler.MauiContext.Services.GetService<InteractionsDetailsPopupViewModel>();
        if (vm != null)
        {
            vm.Interactions = interactions;
            vm.Patient = patient;
            vm.DoctorName = doctorName;
            vm.PastConflictingDrugs = pastConflictingDrugs ?? new List<medicine>();
            vm.TargetDrug = targetDrug;
            vm.CurrentPrescriptions = currentPrescriptions ?? new List<medicine>();
            BindingContext = vm;
        }

        // Настройка заголовка
        if (hasCritical)
        {
            TitleLabel.Text = "⚠️ Критическое взаимодействие!";
            TitleLabel.TextColor = Color.FromArgb("#D32F2F");
            ContinueButton.BackgroundColor = Color.FromArgb("#D32F2F");
        }
        else
        {
            TitleLabel.Text = "⚠ Обнаружены взаимодействия";
            TitleLabel.TextColor = Color.FromArgb("#F9A825");
        }

        SubtitleLabel.Text = interactions.Count == 1
            ? "Найдено 1 взаимодействие"
            : $"Найдено {interactions.Count} взаимодействий";

        // Загрузка списка
        InteractionsList.ItemsSource = interactions;
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Close(false);
    }

    private void OnContinueClicked(object sender, EventArgs e)
    {
        Close(true);
    }
}