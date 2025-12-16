using CommunityToolkit.Maui.Views;
using MedCompatibility.Models;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class InteractionsDetailsPopup : Popup
{
    public InteractionsDetailsPopup(List<interaction> interactions, bool hasCritical)
    {
        InitializeComponent();

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