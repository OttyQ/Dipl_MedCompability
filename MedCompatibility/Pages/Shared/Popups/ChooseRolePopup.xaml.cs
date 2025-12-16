using CommunityToolkit.Maui.Views;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class ChooseRolePopup : Popup
{
    public ChooseRolePopup()
    {
        InitializeComponent();
    }

    void OnPatientClicked(object sender, EventArgs e) => Close("patient");
    void OnDoctorClicked(object sender, EventArgs e) => Close("doctor");
    void OnCancelClicked(object sender, EventArgs e) => Close(null);
}