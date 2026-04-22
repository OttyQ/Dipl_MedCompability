using CommunityToolkit.Maui.Views;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class DebugLoginPopup : Popup
{
    public DebugLoginPopup()
    {
        InitializeComponent();
    }

    private void OnAdminClicked(object? sender, EventArgs e) => Close("Admin");

    private void OnDoctorClicked(object? sender, EventArgs e) => Close("Doctor");

    private void OnPatientClicked(object? sender, EventArgs e) => Close("Patient");

    private void OnCancelClicked(object? sender, EventArgs e) => Close(null);
}
