using System.Reflection;
using MedCompatibility.Configuration;
using MedCompatibility.Models;
using MedCompatibility.Services;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MedCompatibility.Pages.Doctor;
using MedCompatibility.Pages.Patient;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.ViewModels.Admin;
using MedCompatibility.ViewModels.Doctor;
using MedCompatibility.ViewModels.Patient;
using MedCompatibility.ViewModels.Shared;
using UraniumUI;
using ZXing.Net.Maui.Controls;

namespace MedCompatibility;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        // 1) App + Fonts
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseUraniumUI()          
            .UseUraniumUIMaterial()  
            .UseBarcodeReader()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        
        var a = Assembly.GetExecutingAssembly();
        // Имя ресурса: "NamespaceПроекта.ИмяФайла"
        // Если проект MedCompatibility и файл в корне:
        using var stream = a.GetManifestResourceStream("MedCompatibility.appsettings.json");

        if (stream != null)
        {
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .AddEnvironmentVariables()
                .Build();

            builder.Configuration.AddConfiguration(config);
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("ОШИБКА: appsettings.json не найден в ресурсах!");
        }

        builder.Services.Configure<DatabaseSettings>(
            builder.Configuration.GetSection("Database"));

        // 3) DB infrastructure
        builder.Services.AddSingleton<IConnectionStringFactory, ConnectionStringFactory>();

        builder.Services.AddDbContextFactory<DrugContext>((sp, options) =>
        {
            var factory = sp.GetRequiredService<IConnectionStringFactory>();
            var cs = factory.CreateMySqlConnectionString();
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 44));
            options.UseMySql(cs, serverVersion);
        });
        
        // 4) Domain services (лучше Singleton, если внутри нет состояния)
        builder.Services.AddSingleton<IAuthService, AuthService>();
        builder.Services.AddSingleton<IUserService, UserService>();
        builder.Services.AddSingleton<IDatabaseHealthService, DatabaseHealthService>();
        builder.Services.AddSingleton<ILoadingService, LoadingService>();
        builder.Services.AddSingleton<IMedicineService, MedicineService>();
        builder.Services.AddSingleton<IInteractionService, InteractionService>();
        builder.Services.AddSingleton<IUserSessionService, UserSessionService>();
        builder.Services.AddTransient<IScanService, ScanService>();
        builder.Services.AddSingleton<IPrescriptionService, PrescriptionService>();
        builder.Services.AddSingleton<IDoctorStatsService, DoctorStatsService>();
        

        // 5) ViewModels
        builder.Services.AddTransient<MedCompatibility.Pages.Shared.Popups.PatientSearchPopup>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<UsersListViewModel>();
        builder.Services.AddTransient<AdminHomeViewModel>();
        builder.Services.AddTransient<MedicinesListViewModel>();
        builder.Services.AddTransient<MedicineAddViewModel>();
        builder.Services.AddTransient<InteractionsListViewModel>();
        builder.Services.AddTransient<InteractionAddViewModel>();
        builder.Services.AddTransient<ScanPageViewModel>();
        builder.Services.AddTransient<HistoryViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<SystemLogsViewModel>();
        builder.Services.AddTransient<CompatibilityViewModel>();
        builder.Services.AddTransient<MedicineDetailsViewModel>();
        builder.Services.AddTransient<DoctorHomeViewModel>();
        builder.Services.AddTransient<DoctorPatientsViewModel>();
        


        // 6) Pages
        builder.Services.AddTransient<Pages.Shared.LoginPage>();
        builder.Services.AddTransient<Pages.Shared.RegisterPage>();

        builder.Services.AddTransient<ScanPage>();
        builder.Services.AddTransient<HistoryPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<CompatibilityPage>();
        builder.Services.AddTransient<MedicineDetailsPage>();

        builder.Services.AddTransient<Pages.Admin.AdminHomePage>();
        builder.Services.AddTransient<Pages.Admin.UsersListPage>();
        builder.Services.AddTransient<Pages.Admin.MedicinesListPage>();
        builder.Services.AddTransient<Pages.Admin.MedicineAddPage>();
        builder.Services.AddTransient<Pages.Admin.InteractionsListPage>();
        builder.Services.AddTransient<Pages.Admin.InteractionAddPage>();
        builder.Services.AddTransient<Pages.Admin.SystemLogsPage>();
        builder.Services.AddTransient<DoctorHomePage>();
        builder.Services.AddTransient<DoctorPatientsPage>();
        
        builder.Services.AddTransient<MedCompatibility.ViewModels.Doctor.DoctorPatientCardViewModel>();
        builder.Services.AddTransient<MedCompatibility.Pages.Doctor.DoctorPatientCardPage>();
        

        // 7) UI handlers (Entry borderless)
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.BackgroundTintList =
                Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
            handler.PlatformView.Background = null;
#elif WINDOWS
            handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
            handler.PlatformView.FocusVisualMargin = new Microsoft.UI.Xaml.Thickness(0);
#endif
        });

        return builder.Build();
    }
}
