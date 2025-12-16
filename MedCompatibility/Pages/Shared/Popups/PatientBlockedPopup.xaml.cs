using CommunityToolkit.Maui.Views;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class PatientBlockedPopup : Popup
{
    public PatientBlockedPopup()
    {
        InitializeComponent();
    }

    private void OnOkClicked(object sender, EventArgs e)
    {
        Close(null);
    }
}