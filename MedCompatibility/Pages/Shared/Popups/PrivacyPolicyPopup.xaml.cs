using CommunityToolkit.Maui.Views;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class PrivacyPolicyPopup : Popup
{
    public PrivacyPolicyPopup()
    {
        InitializeComponent();
    }

    void OnCloseClicked(object sender, EventArgs e) => Close(true);
}
