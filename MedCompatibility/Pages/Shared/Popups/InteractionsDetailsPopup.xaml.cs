using CommunityToolkit.Maui.Views;
using MedCompatibility.Models;
using MedCompatibility.ViewModels;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class InteractionsDetailsPopup : Popup
{
    public InteractionsDetailsPopup(
        List<interaction> interactions,
        bool hasCritical,
        user patient = null,
        string doctorName = "",
        List<medicine> pastConflictingDrugs = null,
        medicine targetDrug = null,
        List<medicine> currentPrescriptions = null,
        Dictionary<int, (bool IsResidual, int DaysAgoEnded)> residualInfo = null)
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
            vm.ResidualInfo = residualInfo ?? new Dictionary<int, (bool IsResidual, int DaysAgoEnded)>();
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

        // Правка 3: строим обёртки ConflictCardModel для визуального разделения
        var cardModels = interactions.Select(i =>
        {
            bool isResidual = residualInfo != null && residualInfo.TryGetValue(i.InteractionId, out var meta) && meta.IsResidual;
            int daysAgo    = isResidual ? residualInfo![i.InteractionId].DaysAgoEnded : 0;
            return new ConflictCardModel { Interaction = i, IsResidual = isResidual, DaysAgoEnded = daysAgo };
        }).ToList();

        InteractionsList.ItemsSource = cardModels;
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