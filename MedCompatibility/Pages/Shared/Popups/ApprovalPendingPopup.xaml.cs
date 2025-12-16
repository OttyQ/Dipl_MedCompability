using CommunityToolkit.Maui.Views;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class ApprovalPendingPopup : Popup
{
    public ApprovalPendingPopup()
    {
        InitializeComponent();
    }

    void OnOkClicked(object sender, EventArgs e) => Close(true);
}