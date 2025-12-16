using MedCompatibility.Pages.Admin;
using MedCompatibility.Pages.Doctor;
using MedCompatibility.Pages.Patient;

namespace MedCompatibility;
using MedCompatibility.Pages.Shared;
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute("UsersList", typeof(Pages.Admin.UsersListPage));
        Routing.RegisterRoute(nameof(Pages.Admin.MedicinesListPage), typeof(Pages.Admin.MedicinesListPage));
        Routing.RegisterRoute(nameof(Pages.Admin.MedicineAddPage), typeof(Pages.Admin.MedicineAddPage));
        Routing.RegisterRoute(nameof(CodeScannerPage), typeof(CodeScannerPage));
        Routing.RegisterRoute(nameof(InteractionsListPage), typeof(InteractionsListPage));
        Routing.RegisterRoute(nameof(InteractionAddPage), typeof(InteractionAddPage));
        Routing.RegisterRoute(nameof(SystemLogsPage), typeof(SystemLogsPage));
        Routing.RegisterRoute(nameof(CompatibilityPage), typeof(CompatibilityPage));
        Routing.RegisterRoute(nameof(MedicineDetailsPage), typeof(MedicineDetailsPage));
        Routing.RegisterRoute(nameof(DoctorHomePage), typeof(DoctorHomePage));
        Routing.RegisterRoute(nameof(DoctorPatientsPage), typeof(DoctorPatientsPage));
        Routing.RegisterRoute(nameof(Pages.Doctor.DoctorPatientCardPage),
            typeof(Pages.Doctor.DoctorPatientCardPage));
        Routing.RegisterRoute(nameof(MedCompatibility.Pages.Doctor.DoctorPatientCardPage),
            typeof(MedCompatibility.Pages.Doctor.DoctorPatientCardPage));
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        Routing.RegisterRoute(nameof(PrescriptionEditPage), typeof(PrescriptionEditPage));
    }
}