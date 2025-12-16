This file is a merged representation of the entire codebase, combined into a single document by Repomix.

# File Summary

## Purpose
This file contains a packed representation of the entire repository's contents.
It is designed to be easily consumable by AI systems for analysis, code review,
or other automated processes.

## File Format
The content is organized as follows:
1. This summary section
2. Repository information
3. Directory structure
4. Repository files (if enabled)
5. Multiple file entries, each consisting of:
  a. A header with the file path (## File: path/to/file)
  b. The full contents of the file in a code block

## Usage Guidelines
- This file should be treated as read-only. Any changes should be made to the
  original repository files, not this packed version.
- When processing this file, use the file path to distinguish
  between different files in the repository.
- Be aware that this file may contain sensitive information. Handle it with
  the same level of security as you would the original repository.

## Notes
- Some files may have been excluded based on .gitignore rules and Repomix's configuration
- Binary files are not included in this packed representation. Please refer to the Repository Structure section for a complete list of file paths, including binary files
- Files matching patterns in .gitignore are excluded
- Files matching default ignore patterns are excluded
- Files are sorted by Git change count (files with more changes are at the bottom)

# Directory Structure
```
App.xaml
App.xaml.cs
appsettings.json
AppShell.xaml
AppShell.xaml.cs
Configuration/ConnectionStringFactory.cs
Configuration/DatabaseSettings.cs
Converters/IsNullConverter.cs
Converters/StatusConverters.cs
Converters/StringFirstCharConverter.cs
MainPage.xaml
MainPage.xaml.cs
MauiProgram.cs
MedCompatibility.csproj
Models/activesubstance.cs
Models/analysis.cs
Models/doctor_patient.cs
Models/DrugContext.cs
Models/interaction.cs
Models/interactiontype.cs
Models/manufacturer.cs
Models/medicine.cs
Models/prescription.cs
Models/risklevel.cs
Models/role.cs
Models/scan.cs
Models/user.cs
Pages/Admin/AdminHomePage.xaml
Pages/Admin/AdminHomePage.xaml.cs
Pages/Admin/InteractionAddPage.xaml
Pages/Admin/InteractionAddPage.xaml.cs
Pages/Admin/InteractionsListPage.xaml
Pages/Admin/InteractionsListPage.xaml.cs
Pages/Admin/MedicineAddPage.xaml
Pages/Admin/MedicineAddPage.xaml.cs
Pages/Admin/MedicinesListPage.xaml
Pages/Admin/MedicinesListPage.xaml.cs
Pages/Admin/SystemLogsPage.xaml
Pages/Admin/SystemLogsPage.xaml.cs
Pages/Admin/UsersListPage.xaml
Pages/Admin/UsersListPage.xaml.cs
Pages/Doctor/DoctorHomePage.xaml
Pages/Doctor/DoctorHomePage.xaml.cs
Pages/Doctor/DoctorPatientCardPage.xaml
Pages/Doctor/DoctorPatientCardPage.xaml.cs
Pages/Doctor/DoctorPatientsPage.xaml
Pages/Doctor/DoctorPatientsPage.xaml.cs
Pages/Patient/CompatibilityPage.xaml
Pages/Patient/CompatibilityPage.xaml.cs
Pages/Patient/HistoryPage.xaml
Pages/Patient/HistoryPage.xaml.cs
Pages/Patient/MedicineDetailsPage.xaml
Pages/Patient/MedicineDetailsPage.xaml.cs
Pages/Patient/ProfilePage.xaml
Pages/Patient/ProfilePage.xaml.cs
Pages/Patient/ScanPage.xaml
Pages/Patient/ScanPage.xaml.cs
Pages/Shared/CodeScannerPage.xaml
Pages/Shared/CodeScannerPage.xaml.cs
Pages/Shared/LoginPage.xaml
Pages/Shared/LoginPage.xaml.cs
Pages/Shared/Popups/AddManufacturerPopup.xaml
Pages/Shared/Popups/AddManufacturerPopup.xaml.cs
Pages/Shared/Popups/ApprovalPendingPopup.xaml
Pages/Shared/Popups/ApprovalPendingPopup.xaml.cs
Pages/Shared/Popups/ChooseRolePopup.xaml
Pages/Shared/Popups/ChooseRolePopup.xaml.cs
Pages/Shared/Popups/ConfirmPopup.xaml
Pages/Shared/Popups/ConfirmPopup.xaml.cs
Pages/Shared/Popups/DbUnavailablePopup.xaml
Pages/Shared/Popups/DbUnavailablePopup.xaml.cs
Pages/Shared/Popups/LoadingPopup.xaml
Pages/Shared/Popups/LoadingPopup.xaml.cs
Pages/Shared/Popups/MedicineSelectionPopup.xaml
Pages/Shared/Popups/MedicineSelectionPopup.xaml.cs
Pages/Shared/Popups/PatientBlockedPopup.xaml
Pages/Shared/Popups/PatientBlockedPopup.xaml.cs
Pages/Shared/Popups/PatientSearchPopup.xaml
Pages/Shared/Popups/PatientSearchPopup.xaml.cs
Pages/Shared/Popups/SelectSubstancePopup.xaml
Pages/Shared/Popups/SelectSubstancePopup.xaml.cs
Pages/Shared/RegisterPage.xaml
Pages/Shared/RegisterPage.xaml.cs
Platforms/Android/AndroidManifest.xml
Platforms/Android/MainActivity.cs
Platforms/Android/MainApplication.cs
Platforms/Android/MedCompatAuthCallbackActivity.cs
Platforms/Android/Resources/values/colors.xml
Platforms/Windows/app.manifest
Platforms/Windows/App.xaml
Platforms/Windows/App.xaml.cs
Platforms/Windows/Package.appxmanifest
Properties/launchSettings.json
Resources/AppIcon/appicon.svg
Resources/AppIcon/appiconfg.svg
Resources/Fonts/OpenSans-Regular.ttf
Resources/Fonts/OpenSans-Semibold.ttf
Resources/Images/dotnet_bot.png
Resources/Raw/AboutAssets.txt
Resources/Splash/splash.svg
Resources/Styles/Colors.xaml
Resources/Styles/Styles.xaml
Services/AuthService.cs
Services/DatabaseHealthService.cs
Services/InteractionService.cs
Services/Interfaces/IAuthService.cs
Services/Interfaces/IDatabaseHealthService.cs
Services/Interfaces/IInteractionService.cs
Services/Interfaces/ILoadingService.cs
Services/Interfaces/IMedicineService.cs
Services/Interfaces/IPrescriptionService.cs
Services/Interfaces/IScanService.cs
Services/Interfaces/IUserService.cs
Services/Interfaces/IUserSessionService.cs
Services/LoadingService.cs
Services/MedicineService.cs
Services/PrescriptionService.cs
Services/ScanService.cs
Services/UserService.cs
Services/UserSessionService.cs
ViewModels/Admin/AdminHomeViewModel.cs
ViewModels/Admin/InteractionAddViewModel.cs
ViewModels/Admin/InteractionsListViewModel.cs
ViewModels/Admin/MedicineAddViewModel.cs
ViewModels/Admin/MedicinesListViewModel.cs
ViewModels/Admin/SystemLogsViewModel.cs
ViewModels/Admin/UsersListViewModel.cs
ViewModels/Doctor/DoctorHomeViewModel.cs
ViewModels/Doctor/DoctorPatientCardViewModel.cs
ViewModels/Doctor/DoctorPatientsViewModel.cs
ViewModels/Patient/CompatibilityViewModel.cs
ViewModels/Patient/HistoryViewModel.cs
ViewModels/Patient/MedicineDetailsViewModel.cs
ViewModels/Patient/ProfileViewModel.cs
ViewModels/Patient/ScanPageViewModel.cs
ViewModels/Shared/GoogleOAuthTest.cs
ViewModels/Shared/LoginViewModel.cs
ViewModels/Shared/RegisterViewModel.cs
```

# Files

## File: App.xaml
```
<?xml version="1.0" encoding="UTF-8" ?>
<Application
    x:Class="MedCompatibility.App"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:local="clr-namespace:MedCompatibility.Converters"
    xmlns:m="clr-namespace:UraniumUI.Material.Resources;assembly=UraniumUI.Material"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">
    <Application.Resources>
        <ResourceDictionary>

            <ResourceDictionary.MergedDictionaries>
                <m:StyleResource />
                <!--  базовые стили Uranium Material  -->
            </ResourceDictionary.MergedDictionaries>

            <!--  ==================== ЦВЕТОВАЯ ПАЛИТРА (Medical Theme) ====================  -->

            <!--  Основные медицинские цвета  -->
            <Color x:Key="Primary">#00796B</Color>
            <!--  Бирюзовый (основной)  -->
            <Color x:Key="PrimaryDark">#004D40</Color>
            <!--  Темнее для нажатий  -->
            <Color x:Key="PrimaryLight">#B2DFDB</Color>
            <!--  Светлый для фонов  -->
            <Color x:Key="Secondary">#0097A7</Color>
            <!--  Акцент  -->

            <!--  Фоны и поверхности  -->
            <Color x:Key="AppBackground">#F5F8FA</Color>
            <!--  Нейтральный светло-серый  -->
            <Color x:Key="Surface">#FFFFFF</Color>
            <!--  Белый для поверхностей (используется Shell/AppShell и старыми страницами)  -->
            <Color x:Key="CardSurface">#FFFFFF</Color>
            <!--  Белый для карточек  -->
            <Color x:Key="SectionBackground">#FAFBFC</Color>
            <!--  Еле заметный серый для секций  -->

            <!--  Текст  -->
            <Color x:Key="TextPrimary">#263238</Color>
            <!--  Основной темный  -->
            <Color x:Key="TextSecondary">#78909C</Color>
            <!--  Серый для вспомогательного  -->
            <Color x:Key="TextPlaceholder">#B0BEC5</Color>
            <!--  Placeholder для input  -->
            <Color x:Key="TextOnPrimary">#FFFFFF</Color>
            <!--  Белый на кнопках  -->

            <!--  Границы и разделители  -->
            <Color x:Key="BorderLight">#E0E5E9</Color>
            <Color x:Key="BorderMedium">#CFD8DC</Color>

            <!--  Статусные цвета  -->
            <Color x:Key="Success">#66BB6A</Color>
            <Color x:Key="Error">#EF5350</Color>
            <Color x:Key="Warning">#FFA726</Color>
            <Color x:Key="Info">#42A5F5</Color>

            <!--  ==================== ГРАДИЕНТ ДЛЯ ФОНА СТРАНИЦ ====================  -->
            <LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0" x:Key="PageBackgroundGradient">
                <GradientStop Color="#E8F5F3" Offset="0.0" />
                <!--  Светлый бирюзовый  -->
                <GradientStop Color="#F5F8FA" Offset="0.4" />
                <GradientStop Color="#FFFFFF" Offset="1.0" />
            </LinearGradientBrush>

            <!--  ==================== БАЗОВЫЕ СТИЛИ СТРАНИЦ ====================  -->

            <Style ApplyToDerivedTypes="True" TargetType="ContentPage">
                <Setter Property="Background" Value="{StaticResource PageBackgroundGradient}" />
                <Setter Property="Padding" Value="0" />
            </Style>

            <!--  ==================== ТИПОГРАФИКА ====================  -->

            <!--  Главный заголовок страницы  -->
            <Style TargetType="Label" x:Key="PageTitle">
                <Setter Property="FontSize" Value="26" />
                <Setter Property="FontAttributes" Value="Bold" />
                <Setter Property="FontFamily" Value="OpenSansSemibold" />
                <Setter Property="TextColor" Value="{StaticResource TextPrimary}" />
                <Setter Property="Margin" Value="0" />
            </Style>

            <!--  Заголовок секции  -->
            <Style TargetType="Label" x:Key="SectionTitle">
                <Setter Property="FontSize" Value="18" />
                <Setter Property="FontAttributes" Value="Bold" />
                <Setter Property="TextColor" Value="{StaticResource TextPrimary}" />
                <Setter Property="Margin" Value="0,0,0,10" />
            </Style>

            <!--  Подзаголовок / описание  -->
            <Style TargetType="Label" x:Key="Subtitle">
                <Setter Property="FontSize" Value="14" />
                <Setter Property="TextColor" Value="{StaticResource TextSecondary}" />
                <Setter Property="LineHeight" Value="1.4" />
            </Style>

            <!--  Обычный текст  -->
            <Style TargetType="Label" x:Key="BodyText">
                <Setter Property="FontSize" Value="15" />
                <Setter Property="TextColor" Value="{StaticResource TextPrimary}" />
            </Style>

            <!--  Подпись/caption  -->
            <Style TargetType="Label" x:Key="Caption">
                <Setter Property="FontSize" Value="12" />
                <Setter Property="TextColor" Value="{StaticResource TextSecondary}" />
            </Style>

            <!--  ==================== КАРТОЧКИ ====================  -->

            <!--  Основная карточка (Frame)  -->
            <Style TargetType="Frame" x:Key="MedCard">
                <Setter Property="BackgroundColor" Value="{StaticResource CardSurface}" />
                <Setter Property="BorderColor" Value="Transparent" />
                <Setter Property="CornerRadius" Value="16" />
                <Setter Property="Padding" Value="16" />
                <Setter Property="Margin" Value="0,0,0,12" />
                <Setter Property="HasShadow" Value="False" />
                <Setter Property="Shadow">
                    <Shadow
                        Brush="#90A4AE"
                        Offset="0,4"
                        Opacity="0.08"
                        Radius="12" />
                </Setter>
            </Style>

            <!--  Карточка для форм ввода (с большими отступами)  -->
            <Style
                BasedOn="{StaticResource MedCard}"
                TargetType="Frame"
                x:Key="MedFormCard">
                <Setter Property="Padding" Value="20" />
                <Setter Property="MaximumWidthRequest" Value="600" />
                <Setter Property="HorizontalOptions" Value="Center" />
            </Style>

            <!--  Карточка в списке (меньше отступы)  -->
            <Style
                BasedOn="{StaticResource MedCard}"
                TargetType="Frame"
                x:Key="MedListCard">
                <Setter Property="Padding" Value="14" />
                <Setter Property="Margin" Value="0,0,0,8" />
            </Style>

            <!--  ==================== ПОЛЯ ВВОДА ====================  -->

            <!--  Контейнер поля (Border)  -->
            <Style TargetType="Border" x:Key="MedInputContainer">
                <Setter Property="Stroke" Value="{StaticResource BorderLight}" />
                <Setter Property="StrokeThickness" Value="1" />
                <Setter Property="StrokeShape" Value="RoundRectangle 12" />
                <Setter Property="BackgroundColor" Value="#FAFAFA" />
                <Setter Property="Padding" Value="14,0" />
                <Setter Property="HeightRequest" Value="48" />
                <Setter Property="Margin" Value="0,0,0,12" />
            </Style>

            <!--  Entry (само поле)  -->
            <Style TargetType="Entry">
                <Setter Property="TextColor" Value="{StaticResource TextPrimary}" />
                <Setter Property="PlaceholderColor" Value="{StaticResource TextPlaceholder}" />
                <Setter Property="BackgroundColor" Value="Transparent" />
                <Setter Property="FontSize" Value="15" />
                <Setter Property="VerticalOptions" Value="Center" />
            </Style>

            <!--  Editor (многострочный текст)  -->
            <Style TargetType="Editor">
                <Setter Property="TextColor" Value="{StaticResource TextPrimary}" />
                <Setter Property="BackgroundColor" Value="#FAFAFA" />
                <Setter Property="PlaceholderColor" Value="{StaticResource TextPlaceholder}" />
                <Setter Property="FontSize" Value="15" />
            </Style>

            <!--  Picker  -->
            <Style TargetType="Picker">
                <Setter Property="TextColor" Value="{StaticResource TextPrimary}" />
                <Setter Property="TitleColor" Value="{StaticResource TextSecondary}" />
                <Setter Property="BackgroundColor" Value="Transparent" />
                <Setter Property="FontSize" Value="15" />
            </Style>

            <!--  ==================== КНОПКИ ====================  -->

            <!--  Основная кнопка (Primary)  -->
            <Style TargetType="Button" x:Key="PrimaryButton">
                <Setter Property="BackgroundColor" Value="{StaticResource Primary}" />
                <Setter Property="TextColor" Value="{StaticResource TextOnPrimary}" />
                <Setter Property="FontAttributes" Value="Bold" />
                <Setter Property="FontSize" Value="16" />
                <Setter Property="CornerRadius" Value="12" />
                <Setter Property="HeightRequest" Value="50" />
                <Setter Property="Margin" Value="0,4" />
                <Setter Property="Shadow">
                    <Shadow
                        Brush="{StaticResource Primary}"
                        Offset="0,4"
                        Opacity="0.25"
                        Radius="10" />
                </Setter>
                <Setter Property="VisualStateManager.VisualStateGroups">
                    <VisualStateGroupList>
                        <VisualStateGroup x:Name="CommonStates">
                            <VisualState x:Name="Normal" />
                            <VisualState x:Name="Pressed">
                                <VisualState.Setters>
                                    <Setter Property="BackgroundColor" Value="{StaticResource PrimaryDark}" />
                                    <Setter Property="Scale" Value="0.98" />
                                </VisualState.Setters>
                            </VisualState>
                        </VisualStateGroup>
                    </VisualStateGroupList>
                </Setter>
            </Style>

            <!--  Вторичная кнопка (Outline)  -->
            <Style TargetType="Button" x:Key="SecondaryButton">
                <Setter Property="BackgroundColor" Value="Transparent" />
                <Setter Property="TextColor" Value="{StaticResource Primary}" />
                <Setter Property="BorderColor" Value="{StaticResource Primary}" />
                <Setter Property="BorderWidth" Value="2" />
                <Setter Property="FontSize" Value="16" />
                <Setter Property="CornerRadius" Value="12" />
                <Setter Property="HeightRequest" Value="50" />
                <Setter Property="Margin" Value="0,4" />
                <Setter Property="VisualStateManager.VisualStateGroups">
                    <VisualStateGroupList>
                        <VisualStateGroup x:Name="CommonStates">
                            <VisualState x:Name="Normal" />
                            <VisualState x:Name="Pressed">
                                <VisualState.Setters>
                                    <Setter Property="BackgroundColor" Value="{StaticResource PrimaryLight}" />
                                    <Setter Property="Opacity" Value="0.9" />
                                </VisualState.Setters>
                            </VisualState>
                        </VisualStateGroup>
                    </VisualStateGroupList>
                </Setter>
            </Style>

            <!--  Текстовая кнопка (без фона)  -->
            <Style TargetType="Button" x:Key="TextButton">
                <Setter Property="BackgroundColor" Value="Transparent" />
                <Setter Property="TextColor" Value="{StaticResource TextSecondary}" />
                <Setter Property="FontSize" Value="14" />
                <Setter Property="Padding" Value="8,6" />
            </Style>

            <!--  Кнопка "Назад" в хедере  -->
            <Style TargetType="Border" x:Key="BackButton">
                <Setter Property="StrokeShape" Value="RoundRectangle 12" />
                <Setter Property="BackgroundColor" Value="{StaticResource CardSurface}" />
                <Setter Property="StrokeThickness" Value="0" />
                <Setter Property="HeightRequest" Value="42" />
                <Setter Property="WidthRequest" Value="42" />
                <Setter Property="Padding" Value="0" />
                <Setter Property="Shadow">
                    <Shadow
                        Brush="#000000"
                        Offset="0,2"
                        Opacity="0.08"
                        Radius="6" />
                </Setter>
            </Style>

            <!--  ==================== HEADER СТРАНИЦЫ ====================  -->

            <!--  Стиль для Grid-хедера с кнопкой "Назад"  -->
            <Style TargetType="Grid" x:Key="PageHeader">
                <Setter Property="HeightRequest" Value="60" />
                <Setter Property="Padding" Value="16,10" />
                <Setter Property="BackgroundColor" Value="Transparent" />
            </Style>

            <!--  ==================== СПИСКИ ====================  -->

            <Style TargetType="CollectionView">
                <Setter Property="BackgroundColor" Value="Transparent" />
            </Style>

            <!--  Разделитель в списке  -->
            <Style TargetType="BoxView" x:Key="ListSeparator">
                <Setter Property="HeightRequest" Value="1" />
                <Setter Property="Color" Value="{StaticResource BorderLight}" />
                <Setter Property="Margin" Value="0,8" />
            </Style>

            <!--  ==================== БЕЙДЖИ / МЕТКИ СТАТУСА ====================  -->

            <Style TargetType="Border" x:Key="StatusBadge">
                <Setter Property="StrokeShape" Value="RoundRectangle 8" />
                <Setter Property="StrokeThickness" Value="0" />
                <Setter Property="Padding" Value="10,4" />
                <Setter Property="HorizontalOptions" Value="Start" />
            </Style>



            <!--  ===== Modern surfaces (Admin) =====  -->

            <Style TargetType="Border" x:Key="ElevatedCard">
                <Setter Property="BackgroundColor" Value="{StaticResource Surface}" />
                <Setter Property="Stroke" Value="{StaticResource BorderLight}" />
                <Setter Property="StrokeThickness" Value="1" />
                <Setter Property="StrokeShape" Value="RoundRectangle 18" />
                <Setter Property="Padding" Value="16" />
                <Setter Property="Shadow">
                    <Shadow
                        Brush="#000000"
                        Offset="0,10"
                        Opacity="0.06"
                        Radius="22" />
                </Setter>
            </Style>

            <Style TargetType="Label" x:Key="StatValue">
                <Setter Property="FontSize" Value="28" />
                <Setter Property="FontAttributes" Value="Bold" />
                <Setter Property="TextColor" Value="{StaticResource TextPrimary}" />
            </Style>

            <Style TargetType="Label" x:Key="StatCaption">
                <Setter Property="FontSize" Value="12" />
                <Setter Property="TextColor" Value="{StaticResource TextSecondary}" />
            </Style>

            <Style
                BasedOn="{StaticResource ElevatedCard}"
                TargetType="Border"
                x:Key="ActionTile">
                <Setter Property="Padding" Value="14" />
            </Style>

            <Style
                BasedOn="{StaticResource ElevatedCard}"
                TargetType="Border"
                x:Key="ActionRow">
                <Setter Property="Padding" Value="14" />
            </Style>

            <Style TargetType="Label" x:Key="Chevron">
                <Setter Property="Text" Value="›" />
                <Setter Property="FontSize" Value="20" />
                <Setter Property="TextColor" Value="{StaticResource TextSecondary}" />
                <Setter Property="VerticalOptions" Value="Center" />
            </Style>

            <Style TargetType="Border" x:Key="ActionIconCircle">
                <Setter Property="StrokeThickness" Value="0" />
                <Setter Property="StrokeShape" Value="RoundRectangle 14" />
                <Setter Property="HeightRequest" Value="44" />
                <Setter Property="WidthRequest" Value="44" />
                <Setter Property="Padding" Value="0" />
            </Style>

            <LinearGradientBrush EndPoint="1,1" StartPoint="0,0" x:Key="HeaderGradient">
                <GradientStop Color="#D9F4EE" Offset="0.0" />
                <GradientStop Color="#E8F5F3" Offset="0.45" />
                <GradientStop Color="#F5F8FA" Offset="1.0" />
            </LinearGradientBrush>
            <!--  ==================== КОНВЕРТЕРЫ ====================  -->

            <local:BoolToTextConverter x:Key="BoolToTextConverter" />
            <local:BoolToColorConverter x:Key="BoolToColorConverter" />
            <local:IsNullConverter x:Key="IsNullConverter" />
            <local:RoleToColorConverter x:Key="RoleToColorConverter" />
            <local:StringFirstCharConverter x:Key="StringFirstCharConverter" />



            <!--  Modern dashboard tokens  -->
            <Thickness x:Key="SpacePage">20</Thickness>
            <Thickness x:Key="SpaceCard">16</Thickness>

            <Style TargetType="Border" x:Key="AdminCard">
                <Setter Property="BackgroundColor" Value="{StaticResource Surface}" />
                <Setter Property="Stroke" Value="{StaticResource BorderLight}" />
                <Setter Property="StrokeThickness" Value="1" />
                <Setter Property="StrokeShape" Value="RoundRectangle 14" />
                <Setter Property="Padding" Value="{StaticResource SpaceCard}" />
                <Setter Property="Shadow">
                    <Shadow
                        Brush="#000000"
                        Offset="0,14"
                        Opacity="0.06"
                        Radius="26" />
                </Setter>
            </Style>

            <Style TargetType="Label" x:Key="AdminStatNumber">
                <Setter Property="FontSize" Value="32" />
                <Setter Property="FontAttributes" Value="Bold" />
                <Setter Property="TextColor" Value="{StaticResource TextPrimary}" />
            </Style>

            <Style TargetType="Label" x:Key="AdminStatLabel">
                <Setter Property="FontSize" Value="12" />
                <Setter Property="TextColor" Value="{StaticResource TextSecondary}" />
            </Style>


            <!--  ==================== BACKWARD COMPATIBILITY (алиасы для старого XAML) ====================  -->

            <!--  Старые стили заголовков  -->
            <Style TargetType="Label" x:Key="HeaderLabel">
                <Setter Property="TextColor" Value="{StaticResource TextPrimary}" />
                <Setter Property="FontSize" Value="28" />
                <Setter Property="FontAttributes" Value="Bold" />
                <Setter Property="FontFamily" Value="OpenSansSemibold" />
            </Style>

            <Style TargetType="Label" x:Key="SubHeaderLabel">
                <Setter Property="TextColor" Value="{StaticResource TextSecondary}" />
                <Setter Property="FontSize" Value="16" />
            </Style>

            <!--  Старая карточка CardFrame (используется в LoginPage, DoctorHomePage и др.)  -->
            <Style TargetType="Frame" x:Key="CardFrame">
                <Setter Property="BackgroundColor" Value="{StaticResource CardSurface}" />
                <Setter Property="CornerRadius" Value="24" />
                <Setter Property="BorderColor" Value="Transparent" />
                <Setter Property="Padding" Value="30" />
                <Setter Property="MaximumWidthRequest" Value="420" />
                <Setter Property="HorizontalOptions" Value="Center" />
                <Setter Property="HasShadow" Value="False" />
                <Setter Property="Shadow">
                    <Shadow
                        Brush="#90A4AE"
                        Offset="0,10"
                        Opacity="0.15"
                        Radius="30" />
                </Setter>
            </Style>

            <!--  Старая рамка InputFrame для полей ввода  -->
            <Style TargetType="Border" x:Key="InputFrame">
                <Setter Property="Stroke" Value="#E0E0E0" />
                <Setter Property="StrokeThickness" Value="1" />
                <Setter Property="StrokeShape" Value="RoundRectangle 12" />
                <Setter Property="BackgroundColor" Value="#FAFAFA" />
                <Setter Property="Padding" Value="15,2" />
                <Setter Property="HeightRequest" Value="52" />
                <Setter Property="VisualStateManager.VisualStateGroups">
                    <VisualStateGroupList>
                        <VisualStateGroup x:Name="CommonStates">
                            <VisualState x:Name="Normal" />
                            <VisualState x:Name="PointerOver">
                                <VisualState.Setters>
                                    <Setter Property="Stroke" Value="#B0BEC5" />
                                    <Setter Property="BackgroundColor" Value="#FFFFFF" />
                                </VisualState.Setters>
                            </VisualState>
                        </VisualStateGroup>
                    </VisualStateGroupList>
                </Setter>
            </Style>

        </ResourceDictionary>
    </Application.Resources>
</Application>
```

## File: App.xaml.cs
```csharp
namespace MedCompatibility;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
```

## File: appsettings.json
```json
{
  "Database": {
    "Cloud": {
      "Host": "bcntjqiycg3zborqfadx-mysql.services.clever-cloud.com",
      "Port": 3306,
      "Name": "bcntjqiycg3zborqfadx",
      "User": "urwqn3ohyosxyles",
      "Password": "Lu30DXwV4TIawVruZxFw"
    },
    "Local": {
      "Host": "127.0.0.1",
      "Port": 3306,
      "Name": "med_compat_db",
      "User": "root",
      "Password": "root167"
    }
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.EntityFrameworkCore.Database.Command": "Warning"
    }
  }
}
```

## File: AppShell.xaml
```
<?xml version="1.0" encoding="UTF-8" ?>
<Shell
    x:Class="MedCompatibility.AppShell"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:shared="clr-namespace:MedCompatibility.Pages.Shared"
    xmlns:patient="clr-namespace:MedCompatibility.Pages.Patient" 
    xmlns:admin="clr-namespace:MedCompatibility.Pages.Admin"
    xmlns:doctor="clr-namespace:MedCompatibility.Pages.Doctor"
    Shell.FlyoutBehavior="Disabled"
    Title="MedCompatibility"
    
    Shell.BackgroundColor="{StaticResource Surface}"
    Shell.ForegroundColor="{StaticResource TextPrimary}"
    Shell.TitleColor="{StaticResource TextPrimary}"
    Shell.DisabledColor="#B4FFFFFF"
    Shell.UnselectedColor="{StaticResource TextSecondary}"
    Shell.TabBarBackgroundColor="{StaticResource Surface}"
    Shell.TabBarForegroundColor="{StaticResource Primary}"
    Shell.TabBarUnselectedColor="{StaticResource TextSecondary}"
    Shell.TabBarTitleColor="{StaticResource Primary}">

    <Shell.Resources>
        <Style x:Key="BaseStyle" TargetType="Element">
            <Setter Property="Shell.BackgroundColor" Value="{StaticResource Surface}" /> 
            <Setter Property="Shell.ForegroundColor" Value="{StaticResource TextPrimary}" />
            <Setter Property="Shell.TitleColor" Value="{StaticResource TextPrimary}" />
            <Setter Property="Shell.DisabledColor" Value="#B4FFFFFF" />
            <Setter Property="Shell.UnselectedColor" Value="{StaticResource TextSecondary}" />
            <Setter Property="Shell.TabBarBackgroundColor" Value="{StaticResource Surface}" />
            <Setter Property="Shell.TabBarForegroundColor" Value="{StaticResource Primary}"/>
            <Setter Property="Shell.TabBarUnselectedColor" Value="{StaticResource TextSecondary}"/>
            <Setter Property="Shell.TabBarTitleColor" Value="{StaticResource Primary}"/>
        </Style>
    </Shell.Resources>

    <!-- 1. Экран входа -->
    <ShellContent
        Route="Login"
        ContentTemplate="{DataTemplate shared:LoginPage}" 
        Shell.NavBarIsVisible="False"
        Shell.TabBarIsVisible="False" />

    <!-- 2. Зона Пациента -->
    <TabBar Route="Patient" Shell.NavBarIsVisible="False">
        
        <!-- Используем patient:HistoryPage -->
        <ShellContent Title="История" Icon="icon_history.png"
                      ContentTemplate="{DataTemplate patient:HistoryPage}" />
        <!-- НОВАЯ ВКЛАДКА -->
        <ShellContent Title="Проверка" Icon="icon_check.png" 
                      ContentTemplate="{DataTemplate patient:CompatibilityPage}" />
        <!-- Используем patient:ScanPage -->
        <ShellContent Title="СКАНЕР" Icon="icon_qr.png"
                      ContentTemplate="{DataTemplate patient:ScanPage}" />

        <!-- Используем patient:ProfilePage -->
        <ShellContent Title="Профиль" Icon="icon_profile.png"
                      ContentTemplate="{DataTemplate patient:ProfilePage}" />
                      
    </TabBar>
    
    <!-- 3. Зона Админа -->
    <ShellContent
        Route="Admin"
        ContentTemplate="{DataTemplate admin:AdminHomePage}"
        Shell.NavBarIsVisible="False" 
        Shell.TabBarIsVisible="False"/> 
    
    <ShellContent
        Route="Doctor"
        ContentTemplate="{DataTemplate doctor:DoctorHomePage}"
        Shell.NavBarIsVisible="False" 
        Shell.TabBarIsVisible="False"/> 

</Shell>
```

## File: AppShell.xaml.cs
```csharp
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
    }
}
```

## File: Configuration/ConnectionStringFactory.cs
```csharp
using MySqlConnector;

namespace MedCompatibility.Configuration;
using Microsoft.Extensions.Options;

public interface IConnectionStringFactory
{
    string CreateMySqlConnectionString();
}


public class ConnectionStringFactory : IConnectionStringFactory
{
    private readonly DatabaseSettings _settings;
    
    // Флаг: какую базу используем сейчас. По умолчанию - Облако.
    public static bool UseLocalDatabase { get; set; } = false; 

    public ConnectionStringFactory(IOptions<DatabaseSettings> settings)
    {
        _settings = settings.Value;
    }

    public string CreateMySqlConnectionString()
    {
        // Выбираем конфиг в зависимости от флага
        var config = UseLocalDatabase ? _settings.Local : _settings.Cloud;

        var builder = new MySqlConnectionStringBuilder
        {
            Server = config.Host,
            Port = (uint)config.Port,
            UserID = config.User,
            Password = config.Password,
            Database = config.Name,
            SslMode = MySqlSslMode.Required,
            Pooling = false,
            // Для локальной можно поменьше, для облака - побольше
            ConnectionTimeout = UseLocalDatabase ? 10u : 20u 
        };

        return builder.ConnectionString;
    }
}
```

## File: Configuration/DatabaseSettings.cs
```csharp
namespace MedCompatibility.Configuration;

public class ConnectionOptions
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; } = 3306;
    public string Name { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class DatabaseSettings
{
    public ConnectionOptions Cloud { get; set; } = new();
    public ConnectionOptions Local { get; set; } = new();
}
```

## File: Converters/IsNullConverter.cs
```csharp
using System.Globalization;

namespace MedCompatibility.Converters;

public class IsNullConverter : IValueConverter
{
    // Возвращает True, если значение NULL
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value == null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```

## File: Converters/StatusConverters.cs
```csharp
using System.Globalization;

namespace MedCompatibility.Converters;

public class BoolToTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool?)value == true ? "АКТИВЕН" : "БЛОК";
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}

public class BoolToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Зеленый (Success) если true, Красный (Error) если false
        return (bool?)value == true ? Color.FromArgb("#66BB6A") : Color.FromArgb("#FF5252");
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}

public class RoleToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string role = value as string ?? "";
        return role.ToLower() switch
        {
            "admin" => Color.FromArgb("#FF7043"),   // Оранжевый
            "doctor" => Color.FromArgb("#42A5F5"),  // Синий
            "patient" => Color.FromArgb("#26A69A"), // Бирюзовый
            _ => Colors.Gray
        };
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}
```

## File: Converters/StringFirstCharConverter.cs
```csharp
using System.Globalization;

namespace MedCompatibility.Converters;

public class StringFirstCharConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Проверяем, что пришла строка и она не пустая
        if (value is string text && !string.IsNullOrWhiteSpace(text))
        {
            // Возвращаем первый символ в верхнем регистре
            return text[0].ToString().ToUpper();
        }

        // Если пришло null или пустота — возвращаем заглушку (например, знак вопроса или иконку)
        return "?"; 
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```

## File: MainPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MedCompatibility.MainPage">

    <ScrollView>
        <VerticalStackLayout
            Padding="30,0"
            Spacing="25">
            <Image
                Source="dotnet_bot.png"
                HeightRequest="185"
                Aspect="AspectFit"
                SemanticProperties.Description="dot net bot in a race car number eight" />

            <Label
                Text="Hello, World!"
                Style="{StaticResource Headline}"
                SemanticProperties.HeadingLevel="Level1" />

            <Label
                Text="Welcome to &#10;.NET Multi-platform App UI"
                Style="{StaticResource SubHeadline}"
                SemanticProperties.HeadingLevel="Level2"
                SemanticProperties.Description="Welcome to dot net Multi platform App U I" />

            <Button
                x:Name="CounterBtn"
                Text="Click me" 
                SemanticProperties.Hint="Counts the number of times you click"
                Clicked="OnCounterClicked"
                HorizontalOptions="Fill" />
        </VerticalStackLayout>
    </ScrollView>

</ContentPage>
```

## File: MainPage.xaml.cs
```csharp
namespace MedCompatibility;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}
```

## File: MauiProgram.cs
```csharp
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
```

## File: MedCompatibility.csproj
```
<Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
        <TargetFrameworks>net8.0-android;net8.0-windows10.0.19041.0</TargetFrameworks>
        <TargetFrameworks Condition="$([MSBuild]::IsOSPlatform('windows'))">$(TargetFrameworks);net8.0-windows10.0.19041.0</TargetFrameworks>
        <AndroidSdkDirectory>C:\Users\xxpri\AppData\Local\Android\Sdk</AndroidSdkDirectory>
        <!-- Uncomment to also build the tizen app. You will need to install tizen by following this: https://github.com/Samsung/Tizen.NET -->
        <!-- <TargetFrameworks>$(TargetFrameworks);net8.0-tizen</TargetFrameworks> -->

        <!-- Note for MacCatalyst:
        The default runtime is maccatalyst-x64, except in Release config, in which case the default is maccatalyst-x64;maccatalyst-arm64.
        When specifying both architectures, use the plural <RuntimeIdentifiers> instead of the singular <RuntimeIdentifier>.
        The Mac App Store will NOT accept apps with ONLY maccatalyst-arm64 indicated;
        either BOTH runtimes must be indicated or ONLY macatalyst-x64. -->
        <!-- For example: <RuntimeIdentifiers>maccatalyst-x64;maccatalyst-arm64</RuntimeIdentifiers> -->

        <OutputType>Exe</OutputType>
        <RootNamespace>MedCompatibility</RootNamespace>
        <UseMaui>true</UseMaui>
        <SingleProject>true</SingleProject>
        <ImplicitUsings>enable</ImplicitUsings>
        <Nullable>enable</Nullable>

        <!-- Display name -->
        <ApplicationTitle>MedCompatibility</ApplicationTitle>

        <!-- App Identifier -->
        <ApplicationId>com.companyname.medcompatibility</ApplicationId>

        <!-- Versions -->
        <ApplicationDisplayVersion>1.0</ApplicationDisplayVersion>
        <ApplicationVersion>1</ApplicationVersion>
        
        <SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'android'">21.0</SupportedOSPlatformVersion>
        <SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'windows'">10.0.17763.0</SupportedOSPlatformVersion>
        <TargetPlatformMinVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'windows'">10.0.17763.0</TargetPlatformMinVersion>
    </PropertyGroup>

    <ItemGroup>
        <!-- App Icon -->
        <MauiIcon Include="Resources\AppIcon\appicon.svg" ForegroundFile="Resources\AppIcon\appiconfg.svg" Color="#512BD4" />

        <!-- Splash Screen -->
        <MauiSplashScreen Include="Resources\Splash\splash.svg" Color="#512BD4" BaseSize="128,128" />

        <!-- Images -->
        <MauiImage Include="Resources\Images\*" />
        <MauiImage Update="Resources\Images\dotnet_bot.png" Resize="True" BaseSize="300,185" />

        <!-- Custom Fonts -->
        <MauiFont Include="Resources\Fonts\*" />

        <!-- Raw Assets (also remove the "Resources\Raw" prefix) -->
        <MauiAsset Include="Resources\Raw\**" LogicalName="%(RecursiveDir)%(Filename)%(Extension)" />
    </ItemGroup>

    <ItemGroup>
        <EmbeddedResource Include="appsettings.json" CopyToOutputDirectory="Always" />
        <PackageReference Include="CommunityToolkit.Maui" Version="9.1.1" />
        <PackageReference Include="CommunityToolkit.Mvvm" Version="8.4.0" />
        <PackageReference Include="Microsoft.Extensions.Configuration.EnvironmentVariables" Version="8.0.0" />
        <PackageReference Include="Microsoft.Extensions.Options.ConfigurationExtensions" Version="8.0.0" />
        <PackageReference Include="UraniumUI.Material" Version="2.12.1" />
        <PackageReference Include="ZXing.Net.Maui.Controls" Version="0.4.0" />
    </ItemGroup>
    
    <ItemGroup>
        <PackageReference Include="BCrypt.Net-Next" Version="4.0.3" />

        <!-- EF Core 9 -->
        <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.8">
            <PrivateAssets>all</PrivateAssets>
            <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        </PackageReference>

        <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.8">
            <PrivateAssets>all</PrivateAssets>
            <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        </PackageReference>

        <PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="9.0.0" />

        <!-- MAUI и прочее -->
        <PackageReference Include="Microsoft.Maui.Controls" Version="$(MauiVersion)" />
        <PackageReference Include="Microsoft.Maui.Controls.Compatibility" Version="$(MauiVersion)" />
        <PackageReference Include="Microsoft.Extensions.Logging.Debug" Version="8.0.1" />
        <PackageReference Include="ZXing.Net.Maui" Version="0.4.0" />
        <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="8.0.0" />
    </ItemGroup>
    
    <ItemGroup>
      <MauiXaml Update="Pages\Shared\Popups\DbUnavailablePopup.xaml">
        <SubType>Designer</SubType>
      </MauiXaml>
      <MauiXaml Update="Pages\Patient\CompatibilityPage.xaml">
        <SubType>Designer</SubType>
      </MauiXaml>
      <MauiXaml Update="Pages\Doctor\DoctorPatientCardPage.xaml">
        <SubType>Designer</SubType>
      </MauiXaml>
    </ItemGroup>
    
    <ItemGroup>
      <Compile Update="Pages\Shared\Popups\DbUnavailablePopup.xaml.cs">
        <DependentUpon>DbUnavailablePopup.xaml</DependentUpon>
        <SubType>Code</SubType>
      </Compile>
      <Compile Update="Pages\Patient\CompatibilityPage.xaml.cs">
        <DependentUpon>CompatibilityPage.xaml</DependentUpon>
        <SubType>Code</SubType>
      </Compile>
      <Compile Update="Pages\Doctor\DoctorPatientCardPage.xaml.cs">
        <DependentUpon>DoctorPatientCardPage.xaml</DependentUpon>
        <SubType>Code</SubType>
      </Compile>
    </ItemGroup>

</Project>
```

## File: Models/activesubstance.cs
```csharp
using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class activesubstance
{
    public int SubstanceId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<interaction> interactionSubstanceId1Navigations { get; set; } = new List<interaction>();

    public virtual ICollection<interaction> interactionSubstanceId2Navigations { get; set; } = new List<interaction>();

    public virtual ICollection<medicine> Medicines { get; set; } = new List<medicine>();
}
```

## File: Models/analysis.cs
```csharp
using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class analysis
{
    public int AnalysisId { get; set; }

    public int UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual user User { get; set; } = null!;

    public virtual ICollection<interaction> Interactions { get; set; } = new List<interaction>();
}
```

## File: Models/doctor_patient.cs
```csharp
using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class doctor_patient
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public int PatientId { get; set; }

    public DateTime? AddedAt { get; set; }

    public virtual user Doctor { get; set; } = null!;

    public virtual user Patient { get; set; } = null!;
}
```

## File: Models/DrugContext.cs
```csharp
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Models;

public partial class DrugContext : DbContext
{
    public DrugContext(DbContextOptions<DrugContext> options)
        : base(options)
    {
    }

    public virtual DbSet<activesubstance> activesubstances { get; set; }

    public virtual DbSet<analysis> analyses { get; set; }

    public virtual DbSet<interaction> interactions { get; set; }

    public virtual DbSet<interactiontype> interactiontypes { get; set; }

    public virtual DbSet<manufacturer> manufacturers { get; set; }

    public virtual DbSet<medicine> medicines { get; set; }

    public virtual DbSet<prescription> prescriptions { get; set; }

    public virtual DbSet<risklevel> risklevels { get; set; }

    public virtual DbSet<role> roles { get; set; }

    public virtual DbSet<scan> scans { get; set; }

    public virtual DbSet<user> users { get; set; }
    
    public virtual DbSet<doctor_patient> doctor_patient { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<activesubstance>(entity =>
        {
            entity.HasKey(e => e.SubstanceId).HasName("PRIMARY");

            entity.ToTable("activesubstance");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<analysis>(entity =>
        {
            entity.HasKey(e => e.AnalysisId).HasName("PRIMARY");

            entity.ToTable("analysis");

            entity.HasIndex(e => e.UserId, "FK_Analysis_User");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.analyses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Analysis_User");

            entity.HasMany(d => d.Interactions).WithMany(p => p.Analyses)
                .UsingEntity<Dictionary<string, object>>(
                    "analysisresult",
                    r => r.HasOne<interaction>().WithMany()
                        .HasForeignKey("InteractionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AR_Interaction"),
                    l => l.HasOne<analysis>().WithMany()
                        .HasForeignKey("AnalysisId")
                        .HasConstraintName("FK_AR_Analysis"),
                    j =>
                    {
                        j.HasKey("AnalysisId", "InteractionId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("analysisresult");
                        j.HasIndex(new[] { "InteractionId" }, "FK_AR_Interaction");
                    });
        });

        modelBuilder.Entity<interaction>(entity =>
        {
            entity.HasKey(e => e.InteractionId).HasName("PRIMARY");

            entity.ToTable("interaction");

            entity.HasIndex(e => e.RiskLevelId, "FK_Interaction_Risk");

            entity.HasIndex(e => e.SubstanceId2, "FK_Interaction_Sub2");

            entity.HasIndex(e => e.InteractionTypeId, "FK_Interaction_Type");

            entity.HasIndex(e => new { e.SubstanceId1, e.SubstanceId2 }, "UK_Interaction_Pair").IsUnique();

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Recommendation).HasColumnType("text");

            entity.HasOne(d => d.InteractionType).WithMany(p => p.interactions)
                .HasForeignKey(d => d.InteractionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interaction_Type");

            entity.HasOne(d => d.RiskLevel).WithMany(p => p.interactions)
                .HasForeignKey(d => d.RiskLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interaction_Risk");

            entity.HasOne(d => d.SubstanceId1Navigation).WithMany(p => p.interactionSubstanceId1Navigations)
                .HasForeignKey(d => d.SubstanceId1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interaction_Sub1");

            entity.HasOne(d => d.SubstanceId2Navigation).WithMany(p => p.interactionSubstanceId2Navigations)
                .HasForeignKey(d => d.SubstanceId2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Interaction_Sub2");
        });

        modelBuilder.Entity<interactiontype>(entity =>
        {
            entity.HasKey(e => e.InteractionTypeId).HasName("PRIMARY");

            entity.ToTable("interactiontype");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("PRIMARY");

            entity.ToTable("manufacturer");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasDefaultValueSql("'Республика Беларусь'");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<medicine>(entity =>
        {
            entity.HasKey(e => e.MedicineId).HasName("PRIMARY");

            entity.ToTable("medicine");

            entity.HasIndex(e => e.ManufacturerId, "FK_Medicine_Manufacturer");

            entity.HasIndex(e => e.GTIN, "GTIN").IsUnique();

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Form).HasMaxLength(50);
            entity.Property(e => e.GTIN).HasMaxLength(14);
            entity.Property(e => e.INN).HasMaxLength(200);
            entity.Property(e => e.TradeName).HasMaxLength(200);

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.medicines)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medicine_Manufacturer");

            entity.HasMany(d => d.Substances).WithMany(p => p.Medicines)
                .UsingEntity<Dictionary<string, object>>(
                    "medicinesubstance",
                    r => r.HasOne<activesubstance>().WithMany()
                        .HasForeignKey("SubstanceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_MS_Substance"),
                    l => l.HasOne<medicine>().WithMany()
                        .HasForeignKey("MedicineId")
                        .HasConstraintName("FK_MS_Medicine"),
                    j =>
                    {
                        j.HasKey("MedicineId", "SubstanceId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("medicinesubstance");
                        j.HasIndex(new[] { "SubstanceId" }, "FK_MS_Substance");
                    });
        });

        // ==========================================================
        // ОБНОВЛЕННАЯ СЕКЦИЯ PRESCRIPTION (ДАТЫ, ДОЗИРОВКА)
        // ==========================================================
        modelBuilder.Entity<prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PRIMARY");

            entity.ToTable("prescription");

            entity.HasIndex(e => e.DoctorId, "FK_Prescription_Doctor");
            entity.HasIndex(e => e.MedicineId, "FK_Prescription_Medicine");
            entity.HasIndex(e => new { e.PatientId, e.PrescribedAt }, "IX_Prescription_Patient_Date");

            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.PrescribedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            
            // --- НОВЫЕ ПОЛЯ ---
            entity.Property(e => e.StartDate).HasColumnType("datetime").HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.EndDate).HasColumnType("datetime").HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Dosage).HasMaxLength(100);
            // ------------------

            entity.HasOne(d => d.Doctor).WithMany(p => p.prescriptionDoctors)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Doctor");

            entity.HasOne(d => d.Medicine).WithMany(p => p.prescriptions)
                .HasForeignKey(d => d.MedicineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Medicine");

            entity.HasOne(d => d.Patient).WithMany(p => p.prescriptionPatients)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Patient");
        });

        modelBuilder.Entity<risklevel>(entity =>
        {
            entity.HasKey(e => e.RiskLevelId).HasName("PRIMARY");

            entity.ToTable("risklevel");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("role");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<scan>(entity =>
        {
            entity.HasKey(e => e.ScanId).HasName("PRIMARY");

            entity.ToTable("scan");

            entity.HasIndex(e => e.MedicineId, "FK_Scan_Medicine");

            entity.HasIndex(e => new { e.UserId, e.ScannedAt }, "IX_Scan_User_Date");

            entity.Property(e => e.ScannedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Medicine).WithMany(p => p.scans)
                .HasForeignKey(d => d.MedicineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Scan_Medicine");

            entity.HasOne(d => d.User).WithMany(p => p.scans)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Scan_User");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.RoleId, "FK_User_Role");

            entity.HasIndex(e => e.Login, "IX_User_Login").IsUnique();

            entity.HasIndex(e => new { e.LastName, e.FirstName, e.MiddleName }, "IX_User_Name");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IsApproved).HasDefaultValueSql("'0'");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);

            entity.HasOne(d => d.Role).WithMany(p => p.users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });
        
        // ==========================================================
        // НОВАЯ СЕКЦИЯ DOCTOR_PATIENT (МНОГИЕ-КО-МНОГИМ)
        // ==========================================================
        modelBuilder.Entity<doctor_patient>(entity =>
        {
            entity.HasKey(e => new { e.DoctorId, e.PatientId }).HasName("PRIMARY");

            entity.ToTable("doctor_patient");

            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Doctor).WithMany()
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DP_Doctor");

            entity.HasOne(d => d.Patient).WithMany()
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DP_Patient");
        });

        //фильтры для удаления
        modelBuilder.Entity<user>().HasQueryFilter(u => !u.IsDeleted);
        modelBuilder.Entity<medicine>().HasQueryFilter(m => !m.IsDeleted);
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
```

## File: Models/interaction.cs
```csharp
using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class interaction
{
    public int InteractionId { get; set; }

    public int SubstanceId1 { get; set; }

    public int SubstanceId2 { get; set; }

    public int InteractionTypeId { get; set; }

    public int RiskLevelId { get; set; }

    public string? Description { get; set; }

    public string? Recommendation { get; set; }

    public virtual interactiontype InteractionType { get; set; } = null!;

    public virtual risklevel RiskLevel { get; set; } = null!;

    public virtual activesubstance SubstanceId1Navigation { get; set; } = null!;

    public virtual activesubstance SubstanceId2Navigation { get; set; } = null!;

    public virtual ICollection<analysis> Analyses { get; set; } = new List<analysis>();
}
```

## File: Models/interactiontype.cs
```csharp
using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class interactiontype
{
    public int InteractionTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<interaction> interactions { get; set; } = new List<interaction>();
}
```

## File: Models/manufacturer.cs
```csharp
using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class manufacturer
{
    public int ManufacturerId { get; set; }

    public string Name { get; set; } = null!;

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<medicine> medicines { get; set; } = new List<medicine>();
}
```

## File: Models/medicine.cs
```csharp
using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class medicine
{
    public int MedicineId { get; set; }

    public string TradeName { get; set; } = null!;

    public string? INN { get; set; }

    public int ManufacturerId { get; set; }

    public string? Form { get; set; }

    public string GTIN { get; set; } = null!;

    public string? Description { get; set; }

    public virtual manufacturer Manufacturer { get; set; } = null!;
    
    public bool IsDeleted { get; set; }

    public virtual ICollection<prescription> prescriptions { get; set; } = new List<prescription>();

    public virtual ICollection<scan> scans { get; set; } = new List<scan>();

    public virtual ICollection<activesubstance> Substances { get; set; } = new List<activesubstance>();
}
```

## File: Models/prescription.cs
```csharp
using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class prescription
{
    public int PrescriptionId { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public int MedicineId { get; set; }

    public DateTime? PrescribedAt { get; set; }

    // --- НОВЫЕ ПОЛЯ ---
    // Используем DateTime (без ?) для дат, так как они обязательны для проверки пересечений
    public DateTime StartDate { get; set; } 

    public DateTime EndDate { get; set; }

    public string? Dosage { get; set; }
    // ------------------

    public string? Notes { get; set; }

    public virtual user Doctor { get; set; } = null!;

    public virtual medicine Medicine { get; set; } = null!;

    public virtual user Patient { get; set; } = null!;
}
```

## File: Models/risklevel.cs
```csharp
using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class risklevel
{
    public int RiskLevelId { get; set; }

    public string Name { get; set; } = null!;

    public sbyte Severity { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<interaction> interactions { get; set; } = new List<interaction>();
}
```

## File: Models/role.cs
```csharp
using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class role
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<user> users { get; set; } = new List<user>();
}
```

## File: Models/scan.cs
```csharp
using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class scan
{
    public int ScanId { get; set; }

    public int UserId { get; set; }

    public int MedicineId { get; set; }

    public DateTime? ScannedAt { get; set; }

    public virtual medicine Medicine { get; set; } = null!;

    public virtual user User { get; set; } = null!;
}
```

## File: Models/user.cs
```csharp
using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class user
{
    public int UserId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int RoleId { get; set; }

    public bool? IsApproved { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual role Role { get; set; } = null!;
    
    public bool IsDeleted { get; set; }

    public virtual ICollection<analysis> analyses { get; set; } = new List<analysis>();

    public virtual ICollection<prescription> prescriptionDoctors { get; set; } = new List<prescription>();

    public virtual ICollection<prescription> prescriptionPatients { get; set; } = new List<prescription>();

    public virtual ICollection<scan> scans { get; set; } = new List<scan>();
}
```

## File: Pages/Admin/AdminHomePage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage
    Shell.NavBarIsVisible="False"
    x:Class="MedCompatibility.Pages.Admin.AdminHomePage"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:material="http://schemas.enisn-projects.io/dotnet/maui/uraniumui/material"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">

    <ContentPage.Resources>
        <ResourceDictionary>

            <!--  Плитки действий  -->
            <Style TargetType="material:ButtonView" x:Key="ActionTile">
                <Setter Property="BackgroundColor" Value="{StaticResource Surface}" />
                <Setter Property="StrokeShape" Value="{RoundRectangle CornerRadius=16}" />
                <Setter Property="Stroke" Value="#E6EAF0" />
                <Setter Property="StrokeThickness" Value="1" />
                <Setter Property="Padding" Value="16" />

                <!--  Тень как в старом дизайне  -->
                <Setter Property="Shadow">
                    <Shadow
                        Brush="#90A4AE"
                        Offset="0,10"
                        Opacity="0.15"
                        Radius="30" />
                </Setter>
            </Style>

            <!--  Мягкие фоны под иконки (в стиле приложения)  -->
            <Color x:Key="IconBgPrimary">#2600796B</Color>
            <Color x:Key="IconBgSecondary">#260097A7</Color>
            <Color x:Key="IconBgWarning">#26F9A825</Color>
            <Color x:Key="IconBgNeutral">#2678909C</Color>

        </ResourceDictionary>
    </ContentPage.Resources>

    <Grid>

        <!--  Декоративный фон  -->
        <AbsoluteLayout InputTransparent="True">

            <!--  Верхнее бирюзовое пятно  -->
            <BoxView
                AbsoluteLayout.LayoutBounds="0.15,0.08,420,420"
                AbsoluteLayout.LayoutFlags="PositionProportional"
                Color="#1A00796B"
                CornerRadius="210"
                HeightRequest="420"
                WidthRequest="420" />

            <!--  Правое голубое пятно  -->
            <BoxView
                AbsoluteLayout.LayoutBounds="0.95,0.30,520,520"
                AbsoluteLayout.LayoutFlags="PositionProportional"
                Color="#140097A7"
                CornerRadius="260"
                HeightRequest="520"
                WidthRequest="520" />

            <!--  Нижнее нейтральное пятно  -->
            <BoxView
                AbsoluteLayout.LayoutBounds="0.35,0.98,620,620"
                AbsoluteLayout.LayoutFlags="PositionProportional"
                Color="#0F90A4AE"
                CornerRadius="310"
                HeightRequest="620"
                WidthRequest="620" />

        </AbsoluteLayout>

        <!--  Контент  -->
        <ScrollView>
            <VerticalStackLayout
                HorizontalOptions="Center"
                MaximumWidthRequest="900"
                Padding="20"
                Spacing="24">

                <!--  Шапка  -->
                <Grid ColumnDefinitions="*,Auto" ColumnSpacing="16">
                    <VerticalStackLayout Spacing="4">
                        <Label Style="{StaticResource HeaderLabel}" Text="Панель администратора" />
                        <Label Style="{StaticResource SubHeaderLabel}" Text="{Binding WelcomeMessage}" />
                    </VerticalStackLayout>

                    <Button
                        Command="{Binding LogoutCommand}"
                        Grid.Column="1"
                        Style="{StaticResource SecondaryButton}"
                        Text="Выйти"
                        VerticalOptions="Center" />
                </Grid>

                <!--  Статистика (в фирменных цветах приложения)  -->
                <Grid ColumnDefinitions="*,*" ColumnSpacing="12">

                    <Frame
                        BackgroundColor="{StaticResource Primary}"
                        CornerRadius="18"
                        HasShadow="True"
                        Padding="18">
                        <VerticalStackLayout Spacing="6">
                            <Label
                                FontSize="13"
                                Opacity="0.85"
                                Text="Пациенты"
                                TextColor="White" />
                            <Label
                                FontAttributes="Bold"
                                FontSize="36"
                                Text="{Binding PatientsCount}"
                                TextColor="White" />
                        </VerticalStackLayout>
                    </Frame>

                    <Frame
                        BackgroundColor="{StaticResource Secondary}"
                        CornerRadius="18"
                        Grid.Column="1"
                        HasShadow="True"
                        Padding="18">
                        <VerticalStackLayout Spacing="6">
                            <Label
                                FontSize="13"
                                Opacity="0.85"
                                Text="Врачи"
                                TextColor="White" />
                            <Label
                                FontAttributes="Bold"
                                FontSize="36"
                                Text="{Binding DoctorsCount}"
                                TextColor="White" />
                        </VerticalStackLayout>
                    </Frame>

                </Grid>

                <Label
                    FontAttributes="Bold"
                    FontSize="20"
                    Margin="0,8,0,0"
                    Text="Быстрые действия"
                    TextColor="{StaticResource TextPrimary}" />

                <!--  Действия (сетка)  -->
                <Grid
                    ColumnDefinitions="*,*"
                    ColumnSpacing="12"
                    RowDefinitions="Auto,Auto"
                    RowSpacing="12">

                    <!--  Пользователи  -->
                    <material:ButtonView
                        Grid.Column="0"
                        Grid.Row="0"
                        Style="{StaticResource ActionTile}"
                        TappedCommand="{Binding GoToUsersCommand}">
                        <Grid RowDefinitions="Auto,Auto,Auto" RowSpacing="12">

                            <Border
                                BackgroundColor="{StaticResource IconBgPrimary}"
                                HeightRequest="48"
                                HorizontalOptions="Start"
                                Stroke="Transparent"
                                StrokeShape="RoundRectangle 16"
                                WidthRequest="48">
                                <Label
                                    FontSize="24"
                                    HorizontalOptions="Center"
                                    Text="👤"
                                    VerticalOptions="Center" />
                            </Border>

                            <Label
                                FontAttributes="Bold"
                                FontSize="16"
                                Grid.Row="1"
                                Text="Пользователи"
                                TextColor="{StaticResource TextPrimary}" />

                            <Label
                                FontSize="13"
                                Grid.Row="2"
                                Opacity="0.9"
                                Text="Поиск, роли, статусы"
                                TextColor="{StaticResource TextSecondary}" />
                        </Grid>
                    </material:ButtonView>

                    <!--  Препараты  -->
                    <material:ButtonView
                        Grid.Column="1"
                        Grid.Row="0"
                        Style="{StaticResource ActionTile}"
                        TappedCommand="{Binding GoToMedicinesCommand}">
                        <Grid RowDefinitions="Auto,Auto,Auto" RowSpacing="12">

                            <Border
                                BackgroundColor="{StaticResource IconBgSecondary}"
                                HeightRequest="48"
                                HorizontalOptions="Start"
                                Stroke="Transparent"
                                StrokeShape="RoundRectangle 16"
                                WidthRequest="48">
                                <Label
                                    FontSize="24"
                                    HorizontalOptions="Center"
                                    Text="💊"
                                    VerticalOptions="Center" />
                            </Border>

                            <Label
                                FontAttributes="Bold"
                                FontSize="16"
                                Grid.Row="1"
                                Text="Препараты"
                                TextColor="{StaticResource TextPrimary}" />

                            <Label
                                FontSize="13"
                                Grid.Row="2"
                                Opacity="0.9"
                                Text="Каталог и производители"
                                TextColor="{StaticResource TextSecondary}" />
                        </Grid>
                    </material:ButtonView>

                    <!--  Взаимодействия  -->
                    <material:ButtonView
                        Grid.Column="0"
                        Grid.Row="1"
                        Style="{StaticResource ActionTile}"
                        TappedCommand="{Binding GoToConflictsCommand}">
                        <Grid RowDefinitions="Auto,Auto,Auto" RowSpacing="12">

                            <Border
                                BackgroundColor="{StaticResource IconBgWarning}"
                                HeightRequest="48"
                                HorizontalOptions="Start"
                                Stroke="Transparent"
                                StrokeShape="RoundRectangle 16"
                                WidthRequest="48">
                                <Label
                                    FontSize="24"
                                    HorizontalOptions="Center"
                                    Text="⚠"
                                    VerticalOptions="Center" />
                            </Border>

                            <Label
                                FontAttributes="Bold"
                                FontSize="16"
                                Grid.Row="1"
                                Text="Взаимодействия"
                                TextColor="{StaticResource TextPrimary}" />

                            <Label
                                FontSize="13"
                                Grid.Row="2"
                                Opacity="0.9"
                                Text="Типы и уровни риска"
                                TextColor="{StaticResource TextSecondary}" />
                        </Grid>
                    </material:ButtonView>

                    <!--  Система  -->
                    <material:ButtonView
                        Grid.Column="1"
                        Grid.Row="1"
                        Style="{StaticResource ActionTile}"
                        TappedCommand="{Binding GoToSystemCommand}">
                        <Grid RowDefinitions="Auto,Auto,Auto" RowSpacing="12">

                            <Border
                                BackgroundColor="{StaticResource IconBgNeutral}"
                                HeightRequest="48"
                                HorizontalOptions="Start"
                                Stroke="Transparent"
                                StrokeShape="RoundRectangle 16"
                                WidthRequest="48">
                                <Label
                                    FontSize="24"
                                    HorizontalOptions="Center"
                                    Text="🛠"
                                    VerticalOptions="Center" />
                            </Border>

                            <Label
                                FontAttributes="Bold"
                                FontSize="16"
                                Grid.Row="1"
                                Text="Система"
                                TextColor="{StaticResource TextPrimary}" />

                            <Label
                                FontSize="13"
                                Grid.Row="2"
                                Opacity="0.9"
                                Text="Логи и обслуживание"
                                TextColor="{StaticResource TextSecondary}" />
                        </Grid>
                    </material:ButtonView>

                </Grid>

            </VerticalStackLayout>
        </ScrollView>

    </Grid>
</ContentPage>
```

## File: Pages/Admin/AdminHomePage.xaml.cs
```csharp
using MedCompatibility.ViewModels.Admin;

namespace MedCompatibility.Pages.Admin;

public partial class AdminHomePage : ContentPage
{
    public AdminHomePage(AdminHomeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is AdminHomeViewModel vm)
            await vm.OnAppearingAsync();
    }
}
```

## File: Pages/Admin/InteractionAddPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vm="clr-namespace:MedCompatibility.ViewModels.Admin"
             xmlns:converters="clr-namespace:MedCompatibility.Converters"
             x:Class="MedCompatibility.Pages.Admin.InteractionAddPage"
             Title="{Binding PageTitle}"
             BackgroundColor="{StaticResource AppBackground}"
             Shell.NavBarIsVisible="False"
             Shell.TabBarIsVisible="False">

    <ContentPage.Resources>
        <ResourceDictionary>
            <converters:IsNullConverter x:Key="IsNullConverter"/>
        </ResourceDictionary>
    </ContentPage.Resources>

    <Grid RowDefinitions="Auto, *">
        <!-- ШАПКА -->
        <Grid Grid.Row="0" ColumnDefinitions="48, *, 48" HeightRequest="48" Margin="10,5">
            <Border StrokeShape="RoundRectangle 24" BackgroundColor="White" StrokeThickness="0" 
                    HeightRequest="48" WidthRequest="48" Padding="0" HorizontalOptions="Start">
                <Border.Shadow>
                    <Shadow Brush="Black" Offset="0,2" Radius="5" Opacity="0.1"/>
                </Border.Shadow>
                <Border.GestureRecognizers>
                    <TapGestureRecognizer Tapped="OnBackClicked"/>
                </Border.GestureRecognizers>
                <Label Text="←" FontSize="28" HorizontalOptions="Center" VerticalOptions="Center" TextColor="#333" Margin="0,0,0,2"/>
            </Border>
            
            <Label Grid.Column="1" Text="{Binding PageTitle}" 
                   FontSize="20" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}"
                   VerticalOptions="Center" HorizontalOptions="Center"/>
        </Grid>

        <!-- ФОРМА -->
        <ScrollView Grid.Row="1" Padding="15">
            <VerticalStackLayout Spacing="20">
                
                <!-- Блок 1: Участники конфликта -->
                <Border StrokeShape="RoundRectangle 16" BackgroundColor="White" StrokeThickness="0" Padding="20">
                    <Border.Shadow>
                        <Shadow Brush="Black" Offset="0,2" Radius="8" Opacity="0.05"/>
                    </Border.Shadow>
                    <VerticalStackLayout Spacing="15">
                        <Label Text="Конфликтующие вещества" FontAttributes="Bold" TextColor="{StaticResource Primary}" FontSize="16"/>

                        <!-- Вещество 1 -->
                        <VerticalStackLayout Spacing="5">
                            <Label Text="Вещество 1 *" FontSize="12" TextColor="{StaticResource TextSecondary}"/>
                            <Grid ColumnDefinitions="*, Auto" ColumnSpacing="10">
                                <Border StrokeShape="RoundRectangle 8" BackgroundColor="#F5F7FA" StrokeThickness="1" Stroke="Transparent" HeightRequest="44" Padding="10,0">
                                    <Label Text="{Binding Substance1.Name, TargetNullValue='Не выбрано'}" 
                                           TextColor="{StaticResource TextPrimary}" VerticalOptions="Center"/>
                                </Border>
                                <Button Grid.Column="1" Text="🔍" Command="{Binding SelectSubstance1Command}" 
                                        BackgroundColor="{StaticResource Primary}" TextColor="White" HeightRequest="44" WidthRequest="44" CornerRadius="10" Padding="0"/>
                            </Grid>
                        </VerticalStackLayout>

                        <!-- Вещество 2 -->
                        <VerticalStackLayout Spacing="5">
                            <Label Text="Вещество 2 *" FontSize="12" TextColor="{StaticResource TextSecondary}"/>
                            <Grid ColumnDefinitions="*, Auto" ColumnSpacing="10">
                                <Border StrokeShape="RoundRectangle 8" BackgroundColor="#F5F7FA" StrokeThickness="1" Stroke="Transparent" HeightRequest="44" Padding="10,0">
                                    <Label Text="{Binding Substance2.Name, TargetNullValue='Не выбрано'}" 
                                           TextColor="{StaticResource TextPrimary}" VerticalOptions="Center"/>
                                </Border>
                                <Button Grid.Column="1" Text="🔍" Command="{Binding SelectSubstance2Command}" 
                                        BackgroundColor="{StaticResource Primary}" TextColor="White" HeightRequest="44" WidthRequest="44" CornerRadius="10" Padding="0"/>
                            </Grid>
                        </VerticalStackLayout>
                    </VerticalStackLayout>
                </Border>

                <!-- Блок 2: Детали (ИСПРАВЛЕННЫЙ) -->
                <Border StrokeShape="RoundRectangle 16" BackgroundColor="White" StrokeThickness="0" Padding="20">
                    <Border.Shadow>
                        <Shadow Brush="Black" Offset="0,2" Radius="8" Opacity="0.05"/>
                    </Border.Shadow>
                    <VerticalStackLayout Spacing="15">
                        <Label Text="Параметры риска" FontAttributes="Bold" TextColor="{StaticResource Primary}" FontSize="16"/>

                        <!-- Риск -->
                        <VerticalStackLayout Spacing="5">
                            <Label Text="Уровень риска *" FontSize="12" TextColor="{StaticResource TextSecondary}"/>
                            <Border StrokeShape="RoundRectangle 8" BackgroundColor="#F5F7FA" StrokeThickness="1" Stroke="Transparent" 
                                    MinimumHeightRequest="50" Padding="0" VerticalOptions="Fill">
                                <Grid>
                                    <Picker ItemsSource="{Binding Risks}" 
                                            SelectedItem="{Binding SelectedRisk}" 
                                            ItemDisplayBinding="{Binding Name}"
                                            Title="Выберите риск" 
                                            TextColor="{StaticResource TextPrimary}" 
                                            TitleColor="#A0A0A0"
                                            VerticalOptions="Center" 
                                            HorizontalOptions="Fill" 
                                            Margin="10,0"/>
                                </Grid>
                            </Border>
                        </VerticalStackLayout>

                        <!-- Тип -->
                        <VerticalStackLayout Spacing="5">
                            <Label Text="Тип взаимодействия *" FontSize="12" TextColor="{StaticResource TextSecondary}"/>
                            <Border StrokeShape="RoundRectangle 8" BackgroundColor="#F5F7FA" StrokeThickness="1" Stroke="Transparent" 
                                    MinimumHeightRequest="50" Padding="0" VerticalOptions="Fill">
                                <Grid>
                                    <Picker ItemsSource="{Binding Types}" 
                                            SelectedItem="{Binding SelectedType}" 
                                            ItemDisplayBinding="{Binding Name}"
                                            Title="Выберите тип" 
                                            TextColor="{StaticResource TextPrimary}" 
                                            TitleColor="#A0A0A0"
                                            VerticalOptions="Center" 
                                            HorizontalOptions="Fill" 
                                            Margin="10,0"/>
                                </Grid>
                            </Border>
                        </VerticalStackLayout>
                    </VerticalStackLayout>
                </Border>

                <!-- Блок 3: Тексты -->
                <Border StrokeShape="RoundRectangle 16" BackgroundColor="White" StrokeThickness="0" Padding="20">
                    <Border.Shadow>
                        <Shadow Brush="Black" Offset="0,2" Radius="8" Opacity="0.05"/>
                    </Border.Shadow>
                    <VerticalStackLayout Spacing="15">
                        <Label Text="Описание" FontAttributes="Bold" TextColor="{StaticResource Primary}" FontSize="16"/>

                        <VerticalStackLayout Spacing="5">
                            <Label Text="Описание эффекта *" FontSize="12" TextColor="{StaticResource TextSecondary}"/>
                            <Border StrokeShape="RoundRectangle 10" BackgroundColor="#F5F7FA" StrokeThickness="0" HeightRequest="100" Padding="10">
                                <Editor Text="{Binding CurrentInteraction.Description}" 
                                        Placeholder="Что произойдет при смешивании?" 
                                        TextColor="{StaticResource TextPrimary}" 
                                        PlaceholderColor="#A0A0A0"
                                        AutoSize="TextChanges" 
                                        BackgroundColor="Transparent"/>
                            </Border>
                        </VerticalStackLayout>

                        <VerticalStackLayout Spacing="5">
                            <Label Text="Рекомендация врача" FontSize="12" TextColor="{StaticResource TextSecondary}"/>
                            <Border StrokeShape="RoundRectangle 10" BackgroundColor="#F5F7FA" StrokeThickness="0" HeightRequest="80" Padding="10">
                                <Editor Text="{Binding CurrentInteraction.Recommendation}" 
                                        Placeholder="Что делать пациенту?" 
                                        TextColor="{StaticResource TextPrimary}" 
                                        PlaceholderColor="#A0A0A0"
                                        AutoSize="TextChanges" 
                                        BackgroundColor="Transparent"/>
                            </Border>
                        </VerticalStackLayout>
                    </VerticalStackLayout>
                </Border>

                <Button Text="{Binding ButtonText}" Command="{Binding SaveCommand}"
                        BackgroundColor="{StaticResource Primary}" TextColor="White"
                        CornerRadius="25" HeightRequest="50" FontAttributes="Bold" Margin="0,10,0,30"/>

            </VerticalStackLayout>
        </ScrollView>
    </Grid>
</ContentPage>
```

## File: Pages/Admin/InteractionAddPage.xaml.cs
```csharp
namespace MedCompatibility.Pages.Admin;
using MedCompatibility.ViewModels.Admin;

public partial class InteractionAddPage : ContentPage
{
    public InteractionAddPage(InteractionAddViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnBackClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("..");
}
```

## File: Pages/Admin/InteractionsListPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vm="clr-namespace:MedCompatibility.ViewModels.Admin"
             xmlns:models="clr-namespace:MedCompatibility.Models"
             xmlns:converters="clr-namespace:MedCompatibility.Converters"
             x:Class="MedCompatibility.Pages.Admin.InteractionsListPage"
             Title="Конфликты лекарств"
             BackgroundColor="{StaticResource AppBackground}"
             Shell.NavBarIsVisible="False">

    <ContentPage.Resources>
        <ResourceDictionary>
            <converters:IsNullConverter x:Key="IsNullConverter"/>
        </ResourceDictionary>
    </ContentPage.Resources>

    <Grid RowDefinitions="Auto, *">
        
        <!-- 1. ШАПКА -->
        <Grid Grid.Row="0" ColumnDefinitions="48, *, 48" HeightRequest="48" Margin="10,10,10,5">
            <!-- Кнопка Назад (ИСПРАВЛЕНО: возвращаем Tapped="OnBackClicked") -->
            <Border StrokeShape="RoundRectangle 24" BackgroundColor="White" StrokeThickness="0" 
                    HeightRequest="48" WidthRequest="48" Padding="0" HorizontalOptions="Start">
                <Border.Shadow>
                    <Shadow Brush="Black" Offset="0,2" Radius="5" Opacity="0.1"/>
                </Border.Shadow>
                <Border.GestureRecognizers>
                    <TapGestureRecognizer Tapped="OnBackClicked"/>
                </Border.GestureRecognizers>
                <Label Text="←" FontSize="28" HorizontalOptions="Center" VerticalOptions="Center" TextColor="#333" Margin="0,0,0,2"/>
            </Border>
            
            <Label Grid.Column="1" Text="Взаимодействия" 
                   FontSize="20" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}"
                   VerticalOptions="Center" HorizontalOptions="Center"/>
        </Grid>

        <!-- 2. СПИСОК -->
        <RefreshView Grid.Row="1" Command="{Binding LoadDataCommand}" IsRefreshing="{Binding IsBusy}">
            
            <CollectionView ItemsSource="{Binding Interactions}"
                            HorizontalOptions="Center"
                            MaximumWidthRequest="800"
                            WidthRequest="{OnPlatform Android='-1', WinUI='800'}" 
                            SelectionMode="None">
                
                <CollectionView.Margin>
                    <OnPlatform x:TypeArguments="Thickness">
                        <On Platform="WinUI" Value="0,20" /> 
                        <On Platform="Android,iOS" Value="10,10" />
                    </OnPlatform>
                </CollectionView.Margin>

                <CollectionView.EmptyView>
                    <Label Text="Список взаимодействий пуст" TextColor="#999" HorizontalOptions="Center" VerticalOptions="Center"/>
                </CollectionView.EmptyView>
                
                <CollectionView.ItemTemplate>
                    <DataTemplate x:DataType="models:interaction">
                        <!-- Карточка -->
                        <Border StrokeShape="RoundRectangle 12" BackgroundColor="White" StrokeThickness="0" Margin="0,0,0,12" Padding="15">
                            
                            <!-- ИСПРАВЛЕНО: Добавляем жест редактирования СЮДА, на саму карточку -->
                            <Border.GestureRecognizers>
                                <TapGestureRecognizer 
                                    Command="{Binding Source={RelativeSource AncestorType={x:Type vm:InteractionsListViewModel}}, Path=EditInteractionCommand}"
                                    CommandParameter="{Binding .}"/>
                            </Border.GestureRecognizers>
                            
                            <Border.Shadow>
                                <Shadow Brush="Black" Offset="0,2" Radius="4" Opacity="0.05"/>
                            </Border.Shadow>
                            
                            <Grid RowDefinitions="Auto, Auto, Auto" RowSpacing="8">
                                <!-- Заголовок -->
                                <Label FontSize="16" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}" LineBreakMode="WordWrap">
                                    <Label.FormattedText>
                                        <FormattedString>
                                            <Span Text="{Binding SubstanceId1Navigation.Name}"/>
                                            <Span Text=" + " TextColor="#CCC"/>
                                            <Span Text="{Binding SubstanceId2Navigation.Name}"/>
                                        </FormattedString>
                                    </Label.FormattedText>
                                </Label>

                                <!-- Риск и Тип -->
                                <Grid Grid.Row="1" ColumnDefinitions="Auto, *, Auto">
                                    <!-- Бэйдж уровня риска -->
                                    <Border StrokeShape="RoundRectangle 6" StrokeThickness="0" Padding="8,4" VerticalOptions="Center">
                                        <Border.Style>
                                            <Style TargetType="Border">
                                                <Setter Property="BackgroundColor" Value="#E0F7FA"/>
                                                <Style.Triggers>
                                                    <DataTrigger TargetType="Border" Binding="{Binding RiskLevelId}" Value="3">
                                                        <Setter Property="BackgroundColor" Value="#FFEBEE"/>
                                                    </DataTrigger>
                                                    <DataTrigger TargetType="Border" Binding="{Binding RiskLevelId}" Value="2">
                                                        <Setter Property="BackgroundColor" Value="#FFF3E0"/>
                                                    </DataTrigger>
                                                </Style.Triggers>
                                            </Style>
                                        </Border.Style>
                                        
                                        <Label Text="{Binding RiskLevel.Name}" FontSize="11" FontAttributes="Bold">
                                            <Label.Style>
                                                <Style TargetType="Label">
                                                    <Setter Property="TextColor" Value="#006064"/>
                                                    <Style.Triggers>
                                                        <DataTrigger TargetType="Label" Binding="{Binding RiskLevelId}" Value="3">
                                                            <Setter Property="TextColor" Value="#C62828"/>
                                                        </DataTrigger>
                                                        <DataTrigger TargetType="Label" Binding="{Binding RiskLevelId}" Value="2">
                                                            <Setter Property="TextColor" Value="#EF6C00"/>
                                                        </DataTrigger>
                                                    </Style.Triggers>
                                                </Style>
                                            </Label.Style>
                                        </Label>
                                    </Border>

                                    <!-- Тип -->
                                    <Label Grid.Column="1" Text="{Binding InteractionType.Name}" 
                                           FontSize="12" TextColor="{StaticResource TextSecondary}" 
                                           VerticalOptions="Center" Margin="10,0,0,0"/>

                                    <!-- Удалить (кнопка перехватывает нажатие, чтобы не сработал Edit) -->
                                    <Button Grid.Column="2" Text="🗑" 
                                            TextColor="#FF5252" BackgroundColor="Transparent"
                                            FontSize="18" Padding="0" HeightRequest="30" WidthRequest="30"
                                            Command="{Binding Source={RelativeSource AncestorType={x:Type vm:InteractionsListViewModel}}, Path=DeleteInteractionCommand}"
                                            CommandParameter="{Binding .}"/>
                                </Grid>
                                
                                <!-- Описание -->
                                <Label Grid.Row="2" Text="{Binding Description}" 
                                       FontSize="13" TextColor="{StaticResource TextPrimary}" />
                            </Grid>
                        </Border>
                    </DataTemplate>
                </CollectionView.ItemTemplate>
            </CollectionView>
        </RefreshView>

        <!-- Кнопка Добавить (FAB) -->
        <Button Grid.Row="1" Text="+" 
                FontSize="30" TextColor="White" BackgroundColor="{StaticResource Primary}"
                CornerRadius="28" WidthRequest="56" HeightRequest="56"
                HorizontalOptions="End" VerticalOptions="End" Margin="20"
                Shadow="{Shadow Brush={StaticResource Primary}, Offset='0,4', Radius=10, Opacity=0.4}"
                Command="{Binding GoToAddInteractionCommand}"/>
    </Grid>
</ContentPage>
```

## File: Pages/Admin/InteractionsListPage.xaml.cs
```csharp
using MedCompatibility.ViewModels.Admin;

namespace MedCompatibility.Pages.Admin;

public partial class InteractionsListPage : ContentPage
{
    private readonly InteractionsListViewModel _viewModel;

    public InteractionsListPage(InteractionsListViewModel vm)
    {
        InitializeComponent();
        BindingContext = _viewModel = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadDataCommand.ExecuteAsync(null);
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
```

## File: Pages/Admin/MedicineAddPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:models="clr-namespace:MedCompatibility.Models"
             xmlns:vm="clr-namespace:MedCompatibility.ViewModels.Admin"
             xmlns:converters="clr-namespace:MedCompatibility.Converters"
             x:Class="MedCompatibility.Pages.Admin.MedicineAddPage"
             Title="Новое лекарство"
             BackgroundColor="{StaticResource AppBackground}"
             Shell.NavBarIsVisible="False">

    <ContentPage.Resources>
        <ResourceDictionary>
            <converters:IsNullConverter x:Key="IsNullConverter"/>
        </ResourceDictionary>
    </ContentPage.Resources>

    <Grid RowDefinitions="Auto, *">
        
        <!-- 1. ШАПКА -->
        <Grid ColumnDefinitions="48, *, 48" HeightRequest="48" Margin="10,5">
            <Border StrokeShape="RoundRectangle 24" BackgroundColor="White" StrokeThickness="0" 
                    HeightRequest="48" WidthRequest="48" Padding="0" HorizontalOptions="Start">
                <Border.Shadow>
                    <Shadow Brush="Black" Offset="0,2" Radius="5" Opacity="0.1"/>
                </Border.Shadow>
                <Border.GestureRecognizers>
                    <TapGestureRecognizer Tapped="OnBackClicked"/>
                </Border.GestureRecognizers>
                <Label Text="←" FontSize="28" HorizontalOptions="Center" VerticalOptions="Center" TextColor="#333" Margin="0,0,0,2"/>
            </Border>
            
            <Label Grid.Column="1" Text="Новое лекарство" 
                   FontSize="20" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}"
                   VerticalOptions="Center" HorizontalOptions="Center"/>
        </Grid>

        <!-- 2. ФОРМА (Скролл) -->
        <ScrollView Grid.Row="1" Padding="15">
            <VerticalStackLayout Spacing="20" HorizontalOptions="Fill" Margin="0"> 
                
                <!-- Блок 1: Основная информация -->
                <Border StrokeShape="RoundRectangle 16" BackgroundColor="White" StrokeThickness="0" Padding="20">
                    <Border.Shadow>
                        <Shadow Brush="Black" Offset="0,2" Radius="8" Opacity="0.05"/>
                    </Border.Shadow>
                    
                    <VerticalStackLayout Spacing="15">
                        <Label Text="Основная информация" FontAttributes="Bold" FontSize="16" TextColor="{StaticResource Primary}"/>
                        
                        <!-- Название -->
                        <VerticalStackLayout Spacing="5">
                            <Label Text="Торговое название *" FontSize="12" TextColor="{StaticResource TextSecondary}"/>
                            <Border x:Name="NameBorder" StrokeShape="RoundRectangle 8" BackgroundColor="#F5F7FA" StrokeThickness="1" Stroke="Transparent" HeightRequest="44" Padding="10,0">
                                <Entry Text="{Binding NewMedicine.TradeName}" Placeholder="Например: Терафлю" PlaceholderColor="{StaticResource TextSecondary}" TextColor="{StaticResource TextPrimary}" FontSize="14" VerticalOptions="Center"/>
                            </Border>
                        </VerticalStackLayout>

                        <!-- МНН -->
                        <VerticalStackLayout Spacing="5">
                            <Label Text="МНН (Международное название) *" FontSize="12" TextColor="{StaticResource TextSecondary}"/>
                            <Border x:Name="MnnBorder" StrokeShape="RoundRectangle 8" BackgroundColor="#F5F7FA" StrokeThickness="1" Stroke="Transparent" HeightRequest="44" Padding="10,0">
                                <Entry Text="{Binding NewMedicine.INN}" Placeholder="Например: Парацетамол + Фенилэфрин..." PlaceholderColor="{StaticResource TextSecondary}" TextColor="{StaticResource TextPrimary}" FontSize="14" VerticalOptions="Center"/>
                            </Border>
                        </VerticalStackLayout>

                        <!-- Форма выпуска -->
                        <VerticalStackLayout Spacing="5">
                            <Label Text="Форма выпуска *" FontSize="12" TextColor="{StaticResource TextSecondary}"/>
                            <Border x:Name="FormBorder" StrokeShape="RoundRectangle 8" BackgroundColor="#F5F7FA" StrokeThickness="1" Stroke="Transparent" HeightRequest="44" Padding="10,0">
                                <Entry Text="{Binding NewMedicine.Form}" Placeholder="Например: Порошок, Таблетки" PlaceholderColor="{StaticResource TextSecondary}" TextColor="{StaticResource TextPrimary}" FontSize="14" VerticalOptions="Center"/>
                            </Border>
                        </VerticalStackLayout>
                        
                        <!-- Описание / Инструкция -->
                        <VerticalStackLayout Spacing="5">
                            <Label Text="Описание / Инструкция" FontSize="12" TextColor="{StaticResource TextSecondary}"/>
                            <Border StrokeShape="RoundRectangle 10" 
                                    BackgroundColor="#F5F7FA" 
                                    StrokeThickness="0" 
                                    HeightRequest="100" 
                                    Padding="10">
                                <Editor Text="{Binding NewMedicine.Description}"
                                        Placeholder="Введите описание..."
                                        PlaceholderColor="{StaticResource TextSecondary}"
                                        TextColor="{StaticResource TextPrimary}"
                                        BackgroundColor="Transparent"
                                        AutoSize="TextChanges"/>
                            </Border>
                        </VerticalStackLayout>
                        
                    </VerticalStackLayout>
                </Border>

                <!-- Блок 2: Идентификация -->
                <Border StrokeShape="RoundRectangle 16" BackgroundColor="White" StrokeThickness="0" Padding="20">
                    <Border.Shadow>
                        <Shadow Brush="Black" Offset="0,2" Radius="8" Opacity="0.05"/>
                    </Border.Shadow>
                    
                    <VerticalStackLayout Spacing="15">
                        <Label Text="Идентификация" FontAttributes="Bold" FontSize="16" TextColor="{StaticResource Primary}"/>

                        <!-- GTIN + Сканер -->
                        <VerticalStackLayout Spacing="5">
                            <Label Text="Штрихкод (GTIN) *" FontSize="12" TextColor="{StaticResource TextSecondary}"/>
                            <Grid ColumnDefinitions="*, 50" ColumnSpacing="10">
                                <Border x:Name="GtinBorder" StrokeShape="RoundRectangle 8" BackgroundColor="#F5F7FA" StrokeThickness="1" Stroke="Transparent" HeightRequest="44" Padding="10,0">
                                    <Entry Text="{Binding NewMedicine.GTIN}" Placeholder="Сканируйте или введите" PlaceholderColor="{StaticResource TextSecondary}" TextColor="{StaticResource TextPrimary}" Keyboard="Numeric" FontSize="14" VerticalOptions="Center"/>
                                </Border>
                                
                                <Button Grid.Column="1" Text="📷" 
                                        FontSize="24"
                                        BackgroundColor="Transparent"
                                        TextColor="{StaticResource TextPrimary}"
                                        Command="{Binding ScanBarcodeCommand}"
                                        HeightRequest="44" WidthRequest="44"
                                        Padding="0" 
                                        VerticalOptions="Center"/>
                            </Grid>
                        </VerticalStackLayout>

                        <!-- Производитель -->
                        <VerticalStackLayout Spacing="5">
                            <Label Text="Производитель *" FontSize="12" TextColor="{StaticResource TextSecondary}" />

                            <Grid ColumnDefinitions="*, 50" ColumnSpacing="10">
                                <!-- Контейнер ввода -->
                                <Border x:Name="ManufacturerBorder" 
                                        StrokeShape="RoundRectangle 8"
                                        BackgroundColor="#F5F7FA"
                                        StrokeThickness="1" 
                                        Stroke="Transparent"
                                        Padding="10,5"
                                        MinimumHeightRequest="50"
                                        VerticalOptions="Fill">

                                    <Grid>
                                        <!-- Текст выбранного -->
                                        <Label Text="{Binding SelectedManufacturer.Name}"
                                               TextColor="{StaticResource TextPrimary}"
                                               FontSize="13"
                                               VerticalOptions="Center"
                                               LineBreakMode="WordWrap"
                                               MaxLines="2" />

                                        <!-- Плейсхолдер -->
                                        <Label Text="Выберите завод"
                                               TextColor="{StaticResource TextSecondary}"
                                               FontSize="14"
                                               VerticalOptions="Center"
                                               IsVisible="{Binding SelectedManufacturer, Converter={StaticResource IsNullConverter}}" />

                                        <!-- Прозрачный Picker -->
                                        <Picker ItemsSource="{Binding Manufacturers}"
                                                SelectedItem="{Binding SelectedManufacturer}"
                                                ItemDisplayBinding="{Binding Name}"
                                                Opacity="0"
                                                VerticalOptions="Fill"
                                                HorizontalOptions="Fill" />
                                    </Grid>
                                </Border>

                                <!-- Кнопка добавления -->
                                <Button Grid.Column="1" Text="+" FontSize="28" TextColor="{StaticResource Primary}"
                                        BackgroundColor="Transparent" Padding="0"
                                        HeightRequest="50" WidthRequest="50"
                                        VerticalOptions="Center"
                                        Command="{Binding AddManufacturerCommand}" />
                            </Grid>
                        </VerticalStackLayout>
                    </VerticalStackLayout>
                </Border>

                <!-- Блок 3: Состав -->
                <Border StrokeShape="RoundRectangle 16" BackgroundColor="White" StrokeThickness="0" Padding="20">
                    <Border.Shadow>
                        <Shadow Brush="Black" Offset="0,2" Radius="8" Opacity="0.05"/>
                    </Border.Shadow>
                    
                    <VerticalStackLayout Spacing="15">
                        <Grid ColumnDefinitions="*, Auto">
                            <Label Text="Активные вещества" FontAttributes="Bold" FontSize="16" TextColor="{StaticResource Primary}" VerticalOptions="Center"/>
                            <Button Grid.Column="1" Text="+ Добавить" FontSize="12" HeightRequest="30" Padding="10,0" CornerRadius="15"
                                    BackgroundColor="{StaticResource Primary}" TextColor="White"
                                    Command="{Binding AddSubstanceCommand}"/>
                        </Grid>

                        <FlexLayout Wrap="Wrap" JustifyContent="Start" AlignItems="Start" Direction="Row">
                            <BindableLayout.ItemsSource>
                                <Binding Path="AddedSubstances"/>
                            </BindableLayout.ItemsSource>
                            <BindableLayout.ItemTemplate>
                                <DataTemplate x:DataType="models:activesubstance">
                                    <Border StrokeShape="RoundRectangle 14" BackgroundColor="#E3F2FD" StrokeThickness="0" Padding="10,6" Margin="0,0,8,8">
                                        <HorizontalStackLayout Spacing="6">
                                            <Label Text="{Binding Name}" FontSize="13" TextColor="#1565C0" VerticalOptions="Center"/>
                                            <Label Text="✕" FontSize="12" TextColor="#1565C0" FontAttributes="Bold" VerticalOptions="Center">
                                                <Label.GestureRecognizers>
                                                    <TapGestureRecognizer Command="{Binding Source={RelativeSource AncestorType={x:Type vm:MedicineAddViewModel}}, Path=RemoveSubstanceCommand}"
                                                                          CommandParameter="{Binding .}"/>
                                                </Label.GestureRecognizers>
                                            </Label>
                                        </HorizontalStackLayout>
                                    </Border>
                                </DataTemplate>
                            </BindableLayout.ItemTemplate>
                        </FlexLayout>
                        
                        <!-- Плейсхолдер для списка веществ -->
                        <Label Text="Нет добавленных веществ" FontSize="12" TextColor="#999" HorizontalOptions="Center" IsVisible="False">
                            <Label.Triggers>
                                <DataTrigger TargetType="Label" Binding="{Binding AddedSubstances.Count}" Value="0">
                                    <Setter Property="IsVisible" Value="True"/>
                                </DataTrigger>
                            </Label.Triggers>
                        </Label>
                    </VerticalStackLayout>
                </Border>

                <!-- Сообщение об ошибке -->
                <Label x:Name="ErrorLabel" 
                       Text="Заполните все обязательные поля" 
                       TextColor="#FF5252" 
                       FontSize="14" 
                       HorizontalOptions="Center" 
                       IsVisible="False"
                       Margin="0,5"/>

                <!-- Кнопка Сохранить (Clicked вместо Command для UI-валидации) -->
                <Button Text="Сохранить лекарство" 
                        BackgroundColor="{StaticResource Primary}" TextColor="White"
                        CornerRadius="10" HeightRequest="50" FontSize="16" FontAttributes="Bold"
                        Clicked="OnSaveClicked"
                        Margin="0,0,0,30"
                        Shadow="{Shadow Brush={StaticResource Primary}, Offset='0,4', Radius=8, Opacity=0.3}"/>

            </VerticalStackLayout>
        </ScrollView>
    </Grid>
</ContentPage>
```

## File: Pages/Admin/MedicineAddPage.xaml.cs
```csharp
using MedCompatibility.ViewModels.Admin;

namespace MedCompatibility.Pages.Admin;

public partial class MedicineAddPage : ContentPage
{
    private MedicineAddViewModel _viewModel;

    public MedicineAddPage(MedicineAddViewModel vm)
    {
        InitializeComponent();
        BindingContext = _viewModel = vm;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        bool isValid = true;
        
        ResetBorders();

        // Валидация
        if (string.IsNullOrWhiteSpace(_viewModel.NewMedicine.TradeName))
        {
            SetError(NameBorder);
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(_viewModel.NewMedicine.INN))
        {
            SetError(MnnBorder);
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(_viewModel.NewMedicine.Form))
        {
            SetError(FormBorder);
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(_viewModel.NewMedicine.GTIN))
        {
            SetError(GtinBorder);
            isValid = false;
        }

        if (_viewModel.SelectedManufacturer == null)
        {
            SetError(ManufacturerBorder);
            isValid = false;
        }

        if (!isValid)
        {
            ErrorLabel.IsVisible = true;
        }
        else
        {
            // Если все ок - сохраняем
            if (_viewModel.SaveCommand.CanExecute(null))
            {
                _viewModel.SaveCommand.Execute(null);
            }
        }
    }

    private void SetError(Border border)
    {
        if (border != null)
        {
            border.Stroke = Colors.Red;
        }
    }

    private void ResetBorders()
    {
        Color transparent = Colors.Transparent;
        
        NameBorder.Stroke = transparent;
        MnnBorder.Stroke = transparent;
        FormBorder.Stroke = transparent;
        GtinBorder.Stroke = transparent;
        ManufacturerBorder.Stroke = transparent;
        
        ErrorLabel.IsVisible = false;
    }
}
```

## File: Pages/Admin/MedicinesListPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:models="clr-namespace:MedCompatibility.Models"
             xmlns:vm="clr-namespace:MedCompatibility.ViewModels.Admin"
             x:Class="MedCompatibility.Pages.Admin.MedicinesListPage"
             Title="Справочник лекарств"
             BackgroundColor="{StaticResource AppBackground}"
             Shell.NavBarIsVisible="False">

    <Grid>
        <!-- Основной контент -->
        <Grid RowDefinitions="Auto, *" Padding="10">
            
            <!-- ГЛАВНЫЙ КОНТЕЙНЕР (Адаптивный) -->
            <VerticalStackLayout Spacing="15" 
                                 HorizontalOptions="Fill" 
                                 WidthRequest="{OnPlatform WinUI='800', Default='-1'}">
                
                <VerticalStackLayout.HorizontalOptions>
                     <OnPlatform x:TypeArguments="LayoutOptions">
                         <On Platform="WinUI" Value="Center" />
                         <On Platform="Android,iOS" Value="Fill" />
                     </OnPlatform>
                </VerticalStackLayout.HorizontalOptions>

                <!-- 1. ШАПКА -->
                <Grid ColumnDefinitions="48, *, 48" HeightRequest="48" Margin="0,0,0,5">
                    <!-- Кнопка Назад -->
                    <Border StrokeShape="RoundRectangle 24" BackgroundColor="White" StrokeThickness="0" 
                            HeightRequest="48" WidthRequest="48" Padding="0" HorizontalOptions="Start">
                        <Border.Shadow>
                            <Shadow Brush="Black" Offset="0,2" Radius="5" Opacity="0.1"/>
                        </Border.Shadow>
                        <Border.GestureRecognizers>
                            <TapGestureRecognizer Tapped="OnBackClicked"/>
                        </Border.GestureRecognizers>
                        <Label Text="←" FontSize="28" HorizontalOptions="Center" VerticalOptions="Center" TextColor="#333" Margin="0,0,0,2"/>
                    </Border>
                    
                    <!-- Заголовок -->
                    <Label Grid.Column="1" Text="Лекарства" 
                           FontSize="20" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}"
                           VerticalOptions="Center" HorizontalOptions="Center"/>
                </Grid>

                <!-- 2. ПАНЕЛЬ ФИЛЬТРОВ -->
                <Border StrokeShape="RoundRectangle 16" BackgroundColor="White" StrokeThickness="0" Padding="16" HorizontalOptions="Fill">
                    <Border.Shadow>
                        <Shadow Brush="Black" Offset="0,4" Radius="10" Opacity="0.05"/>
                    </Border.Shadow>
                    
                    <VerticalStackLayout Spacing="12">
                        <!-- Поиск -->
                        <VerticalStackLayout Spacing="4">
                            <Label Text="Поиск" FontSize="12" TextColor="{StaticResource TextSecondary}" FontAttributes="Bold"/>
                            <Border StrokeShape="RoundRectangle 10" BackgroundColor="#F5F7FA" StrokeThickness="0" HeightRequest="44" Padding="10,0">
                                <Entry Placeholder="Название, МНН или GTIN" Text="{Binding SearchText}"
                                       TextColor="{StaticResource TextPrimary}" PlaceholderColor="#A0A0A0"
                                       FontSize="14" VerticalOptions="Center" BackgroundColor="Transparent"
                                       ReturnCommand="{Binding LoadDataCommand}"/>
                            </Border>
                        </VerticalStackLayout>

                        <!-- Фильтр Производителя -->
                        <VerticalStackLayout Spacing="4">
                            <Label Text="Производитель" FontSize="12" TextColor="{StaticResource TextSecondary}" FontAttributes="Bold"/>
                            <Border StrokeShape="RoundRectangle 10" BackgroundColor="#F5F7FA" StrokeThickness="0" HeightRequest="44" Padding="5,0">
                                <Picker ItemsSource="{Binding Manufacturers}" SelectedItem="{Binding SelectedManufacturer}"
                                        TextColor="{StaticResource TextPrimary}" TitleColor="#A0A0A0"
                                        FontSize="14" VerticalOptions="Center" BackgroundColor="Transparent"/>
                            </Border>
                        </VerticalStackLayout>

                        <!-- Кнопки -->
                        <Grid ColumnDefinitions="Auto, *" ColumnSpacing="10" Margin="0,5,0,0">
                            <Button Text="Сброс" TextColor="#FF5252" BackgroundColor="Transparent"
                                    FontSize="13" FontAttributes="Bold" Command="{Binding ResetFiltersCommand}"
                                    HeightRequest="44" HorizontalOptions="Start" Padding="0"/>

                            <Button Grid.Column="1" Text="Найти" 
                                    BackgroundColor="{StaticResource Primary}" TextColor="White"
                                    CornerRadius="10" HeightRequest="44" FontSize="14" FontAttributes="Bold"
                                    Command="{Binding LoadDataCommand}"/>
                        </Grid>
                    </VerticalStackLayout>
                </Border>
            </VerticalStackLayout>

            <!-- 3. СПИСОК -->
            <RefreshView Grid.Row="1" Command="{Binding RefreshDataCommand}" IsRefreshing="{Binding IsBusy}" Margin="0,15,0,0">
                <CollectionView ItemsSource="{Binding Medicines}" 
                                HorizontalOptions="Fill" 
                                WidthRequest="{OnPlatform WinUI='800', Default='-1'}">
                     <CollectionView.HorizontalOptions>
                         <OnPlatform x:TypeArguments="LayoutOptions">
                             <On Platform="WinUI" Value="Center" />
                             <On Platform="Android,iOS" Value="Fill" />
                         </OnPlatform>
                    </CollectionView.HorizontalOptions>
                    
                    <CollectionView.EmptyView>
                        <Label Text="Лекарства не найдены" HorizontalOptions="Center" VerticalOptions="Center" TextColor="#999"/>
                    </CollectionView.EmptyView>

                    <CollectionView.ItemTemplate>
                        <DataTemplate x:DataType="models:medicine">
                            <Border StrokeShape="RoundRectangle 12" BackgroundColor="White" StrokeThickness="0" Margin="0,0,0,10" Padding="12">
                                <Border.Shadow>
                                    <Shadow Brush="Black" Offset="0,2" Radius="4" Opacity="0.05"/>
                                </Border.Shadow>
                                <!-- ДОБАВИТЬ ЭТОТ БЛОК -->
                                <Border.GestureRecognizers>
                                    <TapGestureRecognizer 
                                        Command="{Binding Source={RelativeSource AncestorType={x:Type vm:MedicinesListViewModel}}, Path=EditMedicineCommand}"
                                        CommandParameter="{Binding .}"/>
                                </Border.GestureRecognizers>
                                <!-- КОНЕЦ БЛОКА -->
                                <Grid ColumnDefinitions="40, *, Auto" ColumnSpacing="12">
                                    
                                    <!-- Иконка -->
                                    <Frame HeightRequest="40" WidthRequest="40" CornerRadius="10"
                                           BackgroundColor="#E8F5E9" Padding="0" BorderColor="Transparent" 
                                           HorizontalOptions="Start" VerticalOptions="Start">
                                        <Label Text="💊" FontSize="18" HorizontalOptions="Center" VerticalOptions="Center"/>
                                    </Frame>

                                    <!-- Инфо -->
                                    <VerticalStackLayout Grid.Column="1" Spacing="2">
                                        <Label Text="{Binding TradeName}" FontAttributes="Bold" FontSize="15" 
                                               TextColor="{StaticResource TextPrimary}" LineBreakMode="TailTruncation"/>
                                        
                                        <!-- МНН + Форма -->
                                        <Label FontSize="12" TextColor="{StaticResource TextSecondary}" LineBreakMode="TailTruncation">
                                            <Label.FormattedText>
                                                <FormattedString>
                                                    <Span Text="{Binding INN}" />
                                                    <Span Text=", " />
                                                    <Span Text="{Binding Form}" />
                                                </FormattedString>
                                            </Label.FormattedText>
                                        </Label>

                                        <!-- GTIN + Производитель (мелким серым) -->
                                        <Label FontSize="11" TextColor="#9E9E9E" Margin="0,2,0,0" LineBreakMode="TailTruncation">
                                            <Label.FormattedText>
                                                <FormattedString>
                                                    <Span Text="GTIN: "/>
                                                    <Span Text="{Binding GTIN}"/>
                                                    <Span Text=" • "/>
                                                    <Span Text="{Binding Manufacturer.Name}"/>
                                                </FormattedString>
                                            </Label.FormattedText>
                                        </Label>
                                    </VerticalStackLayout>

                                    <!-- Кнопка Удалить -->
                                    <Button Grid.Column="2" Text="🗑" 
                                            TextColor="#FF5252" BackgroundColor="Transparent"
                                            FontSize="18" HeightRequest="40" WidthRequest="40" Padding="0" VerticalOptions="Center"
                                            Command="{Binding Source={RelativeSource AncestorType={x:Type vm:MedicinesListViewModel}}, Path=DeleteMedicineCommand}"
                                            CommandParameter="{Binding .}"/>
                                </Grid>
                            </Border>
                        </DataTemplate>
                    </CollectionView.ItemTemplate>
                </CollectionView>
            </RefreshView>
        </Grid>
        
        <!-- КНОПКА ДОБАВИТЬ (FAB) - Справа внизу -->
        <Button Text="+" 
                FontSize="30" 
                TextColor="White"
                BackgroundColor="{StaticResource Primary}"
                CornerRadius="28"
                WidthRequest="56" HeightRequest="56"
                HorizontalOptions="End" VerticalOptions="End"
                Margin="20"
                Padding="0"
                Shadow="{Shadow Brush={StaticResource Primary}, Offset='0,4', Radius=10, Opacity=0.4}"
                Command="{Binding GoToAddMedicineCommand}" /> 
                <!-- Команду GoToAddMedicineCommand добавим позже -->
    </Grid>
</ContentPage>
```

## File: Pages/Admin/MedicinesListPage.xaml.cs
```csharp
using MedCompatibility.ViewModels.Admin;

namespace MedCompatibility.Pages.Admin;

public partial class MedicinesListPage : ContentPage
{
    private readonly MedicinesListViewModel _viewModel;

    public MedicinesListPage(MedicinesListViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
```

## File: Pages/Admin/SystemLogsPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vm="clr-namespace:MedCompatibility.ViewModels.Admin"
             xmlns:models="clr-namespace:MedCompatibility.Models"
             x:Class="MedCompatibility.Pages.Admin.SystemLogsPage"
             Title="Системные логи"
             BackgroundColor="{StaticResource AppBackground}"
             Shell.NavBarIsVisible="False">

    <Grid>
        <!-- Основной контент с отступами -->
        <Grid RowDefinitions="Auto, *" Padding="10">
            
            <!-- ВЕРХНЯЯ ЧАСТЬ (Адаптивная ширина) -->
            <VerticalStackLayout Spacing="15" HorizontalOptions="Fill" 
                                 WidthRequest="{OnPlatform WinUI='800', Default='-1'}">
                <VerticalStackLayout.HorizontalOptions>
                     <OnPlatform x:TypeArguments="LayoutOptions">
                         <On Platform="WinUI" Value="Center" />
                         <On Platform="Android,iOS" Value="Fill" />
                     </OnPlatform>
                </VerticalStackLayout.HorizontalOptions>

                <!-- 1. ШАПКА -->
                <Grid ColumnDefinitions="48, *, 48" HeightRequest="48" Margin="0,0,0,5">
                    <!-- Кнопка Назад -->
                    <Border StrokeShape="RoundRectangle 24" BackgroundColor="White" StrokeThickness="0" 
                            HeightRequest="48" WidthRequest="48" Padding="0" HorizontalOptions="Start">
                        <Border.Shadow>
                            <Shadow Brush="Black" Offset="0,2" Radius="5" Opacity="0.1"/>
                        </Border.Shadow>
                        <Border.GestureRecognizers>
                            <TapGestureRecognizer Tapped="OnBackClicked"/>
                        </Border.GestureRecognizers>
                        <Label Text="←" FontSize="28" HorizontalOptions="Center" VerticalOptions="Center" TextColor="#333" Margin="0,0,0,2"/>
                    </Border>
                    
                    <!-- Заголовок -->
                    <Label Grid.Column="1" Text="История активности" 
                           FontSize="20" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}"
                           VerticalOptions="Center" HorizontalOptions="Center"/>
                </Grid>

                <!-- 2. ИНФО-ПАНЕЛЬ (Статус БД) -->
                <Border StrokeShape="RoundRectangle 16" BackgroundColor="White" StrokeThickness="0" Padding="16" HorizontalOptions="Fill">
                    <Border.Shadow>
                        <Shadow Brush="Black" Offset="0,4" Radius="10" Opacity="0.05"/>
                    </Border.Shadow>
                    
                    <Grid ColumnDefinitions="*, Auto">
                        <VerticalStackLayout Spacing="2">
                            <Label Text="Статус системы" FontSize="12" TextColor="{StaticResource TextSecondary}" FontAttributes="Bold"/>
                            <Label Text="Мониторинг базы данных и действий пользователей" FontSize="11" TextColor="#9E9E9E"/>
                        </VerticalStackLayout>

                        <!-- Индикатор БД -->
                        <Border Grid.Column="1" StrokeShape="RoundRectangle 10" BackgroundColor="{Binding DbStatusColor}" 
                                StrokeThickness="0" Padding="12,6" VerticalOptions="Center">
                            <Label Text="{Binding DbStatusText}" TextColor="White" FontSize="12" FontAttributes="Bold"/>
                        </Border>
                    </Grid>
                </Border>
            </VerticalStackLayout>

            <!-- 3. СПИСОК ЛОГОВ -->
            <RefreshView Grid.Row="1" Command="{Binding LoadLogsCommand}" IsRefreshing="{Binding IsBusy}" Margin="0,15,0,0">
                <CollectionView ItemsSource="{Binding Logs}"
                                HorizontalOptions="Fill" 
                                WidthRequest="{OnPlatform WinUI='800', Default='-1'}">
                     <CollectionView.HorizontalOptions>
                         <OnPlatform x:TypeArguments="LayoutOptions">
                             <On Platform="WinUI" Value="Center" />
                             <On Platform="Android,iOS" Value="Fill" />
                         </OnPlatform>
                    </CollectionView.HorizontalOptions>

                    <CollectionView.EmptyView>
                        <VerticalStackLayout Spacing="10" VerticalOptions="Center" HorizontalOptions="Center">
                            <Label Text="📭" FontSize="40" HorizontalOptions="Center"/>
                            <Label Text="Логов пока нет" TextColor="#999" HorizontalOptions="Center"/>
                        </VerticalStackLayout>
                    </CollectionView.EmptyView>

                    <CollectionView.ItemTemplate>
                        <DataTemplate x:DataType="models:scan">
                            <!-- Карточка лога -->
                            <Border StrokeShape="RoundRectangle 12" BackgroundColor="White" StrokeThickness="0" Margin="0,0,0,10" Padding="12">
                                <Border.Shadow>
                                    <Shadow Brush="Black" Offset="0,2" Radius="4" Opacity="0.05"/>
                                </Border.Shadow>
                                
                                <Grid ColumnDefinitions="40, *, Auto" ColumnSpacing="12">
                                    
                                    <!-- Иконка типа действия -->
                                    <Frame HeightRequest="40" WidthRequest="40" CornerRadius="10"
                                           BackgroundColor="#E3F2FD" Padding="0" BorderColor="Transparent" 
                                           HorizontalOptions="Start" VerticalOptions="Start">
                                        <Label Text="🔎" FontSize="18" HorizontalOptions="Center" VerticalOptions="Center"/>
                                    </Frame>

                                    <!-- Основная информация -->
                                    <VerticalStackLayout Grid.Column="1" Spacing="2" VerticalOptions="Center">
                                        <!-- Кто -->
                                        <Label Text="{Binding User.Login}" FontAttributes="Bold" FontSize="15" 
                                               TextColor="{StaticResource TextPrimary}" LineBreakMode="TailTruncation"/>
                                        
                                        <!-- Что сделал -->
                                        <Label FontSize="13" TextColor="{StaticResource TextSecondary}" LineBreakMode="TailTruncation">
                                            <Label.FormattedText>
                                                <FormattedString>
                                                    <Span Text="Сканировал: " />
                                                    <Span Text="{Binding Medicine.TradeName}" FontAttributes="Bold" TextColor="{StaticResource Primary}"/>
                                                </FormattedString>
                                            </Label.FormattedText>
                                        </Label>
                                    </VerticalStackLayout>

                                    <!-- Время -->
                                    <VerticalStackLayout Grid.Column="2" HorizontalOptions="End" VerticalOptions="Center" Spacing="0">
                                        <Label Text="{Binding ScannedAt, StringFormat='{0:HH:mm}'}" 
                                               FontSize="14" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}" HorizontalOptions="End"/>
                                        <Label Text="{Binding ScannedAt, StringFormat='{0:dd.MM}'}" 
                                               FontSize="11" TextColor="#9E9E9E" HorizontalOptions="End"/>
                                    </VerticalStackLayout>
                                </Grid>
                            </Border>
                        </DataTemplate>
                    </CollectionView.ItemTemplate>
                </CollectionView>
            </RefreshView>
        </Grid>
    </Grid>
</ContentPage>
```

## File: Pages/Admin/SystemLogsPage.xaml.cs
```csharp
using MedCompatibility.ViewModels.Admin;

namespace MedCompatibility.Pages.Admin;

public partial class SystemLogsPage : ContentPage
{
    private readonly SystemLogsViewModel _viewModel;

    public SystemLogsPage(SystemLogsViewModel vm)
    {
        InitializeComponent();
        BindingContext = _viewModel = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Автоматическая загрузка при открытии
        _viewModel.LoadLogsCommand.Execute(null);
    }

    // Обработчик кнопки "Назад"
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
```

## File: Pages/Admin/UsersListPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:models="clr-namespace:MedCompatibility.Models"
             xmlns:vm="clr-namespace:MedCompatibility.ViewModels.Admin"
             xmlns:converters="clr-namespace:MedCompatibility.Converters"
             x:Class="MedCompatibility.Pages.Admin.UsersListPage"
             Title="Пользователи"
             BackgroundColor="{StaticResource AppBackground}"
             Shell.NavBarIsVisible="False">

    <ContentPage.Resources>
        <ResourceDictionary>
            <converters:BoolToColorConverter x:Key="StatusColorConverter"/>
            <converters:BoolToTextConverter x:Key="StatusTextConverter"/>
            <converters:RoleToColorConverter x:Key="RoleColorConverter"/>
        </ResourceDictionary>
    </ContentPage.Resources>

    <Grid RowDefinitions="Auto, *" Padding="10">
        
        <!-- ГЛАВНЫЙ КОНТЕЙНЕР -->
        <VerticalStackLayout Spacing="15" 
                             HorizontalOptions="Fill" 
                             WidthRequest="{OnPlatform WinUI='800', Default='-1'}"> <!-- На WinUI 800px, на телефоне - во всю ширину -->
            
            <VerticalStackLayout.HorizontalOptions>
                 <OnPlatform x:TypeArguments="LayoutOptions">
                     <On Platform="WinUI" Value="Center" />
                     <On Platform="Android,iOS" Value="Fill" />
                 </OnPlatform>
            </VerticalStackLayout.HorizontalOptions>

            <!-- 1. ШАПКА (ИСПРАВЛЕНО: Честный Grid, ничего не наезжает) -->
            <Grid ColumnDefinitions="48, *, 48" HeightRequest="48" Margin="0,0,0,5">
                <!-- Кнопка Назад -->
                <Border StrokeShape="RoundRectangle 24" BackgroundColor="White" StrokeThickness="0" 
                        HeightRequest="48" WidthRequest="48" Padding="0" HorizontalOptions="Start">
                    <Border.Shadow>
                        <Shadow Brush="Black" Offset="0,2" Radius="5" Opacity="0.1"/>
                    </Border.Shadow>
                    <Border.GestureRecognizers>
                        <TapGestureRecognizer Tapped="OnBackClicked"/>
                    </Border.GestureRecognizers>
                    <Label Text="←" FontSize="28" HorizontalOptions="Center" VerticalOptions="Center" TextColor="#333" Margin="0,0,0,2"/>
                </Border>
                
                <!-- Заголовок (Строго по центру) -->
                <Label Grid.Column="1" Text="Пользователи" 
                       FontSize="20" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}"
                       VerticalOptions="Center" HorizontalOptions="Center"/>
            </Grid>

            <!-- 2. ПАНЕЛЬ ФИЛЬТРОВ (Растянута на Fill) -->
            <Border StrokeShape="RoundRectangle 16" BackgroundColor="White" StrokeThickness="0" Padding="16" HorizontalOptions="Fill">
                <Border.Shadow>
                    <Shadow Brush="Black" Offset="0,4" Radius="10" Opacity="0.05"/>
                </Border.Shadow>
                
                <VerticalStackLayout Spacing="12">
                    <VerticalStackLayout Spacing="4">
                        <Label Text="Поиск" FontSize="12" TextColor="{StaticResource TextSecondary}" FontAttributes="Bold"/>
                        <Border StrokeShape="RoundRectangle 10" BackgroundColor="#F5F7FA" StrokeThickness="0" HeightRequest="44" Padding="10,0">
                            <Entry Placeholder="ФИО или логин" Text="{Binding SearchText}"
                                   TextColor="{StaticResource TextPrimary}" PlaceholderColor="#A0A0A0"
                                   FontSize="14" VerticalOptions="Center" BackgroundColor="Transparent"/>
                        </Border>
                    </VerticalStackLayout>

                    <Grid ColumnDefinitions="*, *" ColumnSpacing="10">
                        <VerticalStackLayout Spacing="4">
                            <Label Text="Роль" FontSize="12" TextColor="{StaticResource TextSecondary}" FontAttributes="Bold"/>
                            <Border StrokeShape="RoundRectangle 10" BackgroundColor="#F5F7FA" StrokeThickness="0" HeightRequest="44" Padding="5,0">
                                <Picker ItemsSource="{Binding Roles}" SelectedItem="{Binding SelectedRole}"
                                        TextColor="{StaticResource TextPrimary}" TitleColor="#A0A0A0"
                                        FontSize="14" VerticalOptions="Center" BackgroundColor="Transparent"/>
                            </Border>
                        </VerticalStackLayout>

                        <VerticalStackLayout Grid.Column="1" Spacing="4">
                            <Label Text="Статус" FontSize="12" TextColor="{StaticResource TextSecondary}" FontAttributes="Bold"/>
                            <Border StrokeShape="RoundRectangle 10" BackgroundColor="#F5F7FA" StrokeThickness="0" HeightRequest="44" Padding="5,0">
                                <Picker ItemsSource="{Binding Statuses}" SelectedItem="{Binding SelectedStatus}"
                                        TextColor="{StaticResource TextPrimary}" TitleColor="#A0A0A0"
                                        FontSize="14" VerticalOptions="Center" BackgroundColor="Transparent"/>
                            </Border>
                        </VerticalStackLayout>
                    </Grid>

                    <Grid ColumnDefinitions="Auto, *" ColumnSpacing="10" Margin="0,5,0,0">
                        <Button Text="Сброс" TextColor="#FF5252" BackgroundColor="Transparent"
                                FontSize="13" FontAttributes="Bold" Command="{Binding ResetFiltersCommand}"
                                HeightRequest="44" HorizontalOptions="Start" Padding="0"/>

                        <Button Grid.Column="1" Text="Применить" 
                                BackgroundColor="{StaticResource Primary}" TextColor="White"
                                CornerRadius="10" HeightRequest="44" FontSize="14" FontAttributes="Bold"
                                Command="{Binding LoadDataCommand}"/>
                    </Grid>
                </VerticalStackLayout>
            </Border>
        </VerticalStackLayout>

        <!-- 3. СПИСОК -->
        <RefreshView Grid.Row="1" Command="{Binding LoadDataCommand}" IsRefreshing="{Binding IsBusy}" Margin="0,15,0,0">
            <CollectionView ItemsSource="{Binding Users}" 
                            HorizontalOptions="Fill" 
                            WidthRequest="{OnPlatform WinUI='800', Default='-1'}">
                 <CollectionView.HorizontalOptions>
                     <OnPlatform x:TypeArguments="LayoutOptions">
                         <On Platform="WinUI" Value="Center" />
                         <On Platform="Android,iOS" Value="Fill" />
                     </OnPlatform>
                </CollectionView.HorizontalOptions>
                
                <CollectionView.EmptyView>
                    <Label Text="Пользователи не найдены" HorizontalOptions="Center" VerticalOptions="Center" TextColor="#999"/>
                </CollectionView.EmptyView>

                <CollectionView.ItemTemplate>
                    <DataTemplate x:DataType="models:user">
                        <Border StrokeShape="RoundRectangle 12" BackgroundColor="White" StrokeThickness="0" Margin="0,0,0,10" Padding="12">
                            <Border.Shadow>
                                <Shadow Brush="Black" Offset="0,2" Radius="4" Opacity="0.05"/>
                            </Border.Shadow>
                            
                            <!-- Grid для карточки -->
                            <Grid ColumnDefinitions="40, *, Auto, Auto" ColumnSpacing="10">
                                
                                <!-- Аватар (Уменьшен шрифт до 12, чтобы влезало 'MobU') -->
                                <Grid WidthRequest="40" HeightRequest="40">
                                    <Ellipse Fill="{Binding Role.Name, Converter={StaticResource RoleColorConverter}}" Aspect="Fill"/>
                                    <Label Text="{Binding Login, StringFormat='{0:F1}'}" 
                                           TextColor="White" FontSize="14" FontAttributes="Bold"
                                           HorizontalOptions="Center" VerticalOptions="Center"/>
                                </Grid>

                                <VerticalStackLayout Grid.Column="1" Spacing="2" VerticalOptions="Center">
                                    <Label FontAttributes="Bold" FontSize="14" TextColor="{StaticResource TextPrimary}" LineBreakMode="TailTruncation">
                                        <Label.FormattedText>
                                            <FormattedString>
                                                <Span Text="{Binding LastName}"/>
                                                <Span Text=" "/>
                                                <Span Text="{Binding FirstName}"/>
                                            </FormattedString>
                                        </Label.FormattedText>
                                    </Label>
                                    <Label Text="{Binding Role.Name}" FontSize="11" TextColor="{StaticResource TextSecondary}"/>
                                </VerticalStackLayout>

                                <Button Grid.Column="2"
                                        Text="{Binding IsApproved, Converter={StaticResource StatusTextConverter}}"
                                        FontSize="10" HeightRequest="28" Padding="10,0" CornerRadius="14"
                                        BackgroundColor="{Binding IsApproved, Converter={StaticResource StatusColorConverter}}"
                                        TextColor="White" FontAttributes="Bold" VerticalOptions="Center"
                                        Command="{Binding Source={RelativeSource AncestorType={x:Type vm:UsersListViewModel}}, Path=ToggleStatusCommand}"
                                        CommandParameter="{Binding .}"/>

                                <Button Grid.Column="3" Text="🗑" 
                                        TextColor="#FF5252" BackgroundColor="Transparent"
                                        FontSize="18" HeightRequest="36" WidthRequest="36" Padding="0" VerticalOptions="Center"
                                        Command="{Binding Source={RelativeSource AncestorType={x:Type vm:UsersListViewModel}}, Path=DeleteUserCommand}"
                                        CommandParameter="{Binding .}"/>
                            </Grid>
                        </Border>
                    </DataTemplate>
                </CollectionView.ItemTemplate>
            </CollectionView>
        </RefreshView>
    </Grid>
</ContentPage>
```

## File: Pages/Admin/UsersListPage.xaml.cs
```csharp
namespace MedCompatibility.Pages.Admin;
using MedCompatibility.ViewModels.Admin;

public partial class UsersListPage : ContentPage
{
    private readonly UsersListViewModel _vm;
    
    public UsersListPage(UsersListViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Используем правильное имя команды из ViewModel
        if (_vm.LoadDataCommand.CanExecute(null))
        {
            _vm.LoadDataCommand.Execute(null);
        }
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    
    
}
```

## File: Pages/Doctor/DoctorHomePage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vm="clr-namespace:MedCompatibility.ViewModels.Doctor"
             x:Class="MedCompatibility.Pages.Doctor.DoctorHomePage"
             Title="Кабинет врача"
             BackgroundColor="{StaticResource Surface}"
             Shell.NavBarIsVisible="False">

    <ScrollView>
        <Grid Padding="20">
            <VerticalStackLayout Spacing="30"
                                 HorizontalOptions="Center"
                                 MaximumWidthRequest="800">

                <!-- 1) Шапка -->
                <Grid ColumnDefinitions="*,Auto">
                    <VerticalStackLayout Spacing="4">
                        <Label Text="Рабочее место" FontSize="14" TextColor="{StaticResource TextSecondary}"/>
                        <Label Text="{Binding WelcomeText}" 
                               FontSize="24" 
                               FontAttributes="Bold" 
                               TextColor="{StaticResource TextPrimary}"/>
                    </VerticalStackLayout>

                    <!-- Кнопка выхода -->
                    <Border Grid.Column="1"
                            StrokeShape="RoundRectangle 12"
                            StrokeThickness="1"
                            Stroke="#E6EAF0"
                            BackgroundColor="White"
                            Padding="14,8"
                            VerticalOptions="Start">
                        <Border.GestureRecognizers>
                            <TapGestureRecognizer Command="{Binding LogoutCommand}"/>
                        </Border.GestureRecognizers>

                        <HorizontalStackLayout Spacing="8" VerticalOptions="Center">
                            <Label Text="⎋" FontSize="16" TextColor="{StaticResource TextSecondary}" VerticalOptions="Center"/>
                            <Label Text="Выйти"
                                   FontSize="14"
                                   FontAttributes="Bold"
                                   TextColor="{StaticResource TextSecondary}"
                                   VerticalOptions="Center"/>
                        </HorizontalStackLayout>
                    </Border>
                </Grid>

                <!-- 2) Статистика -->
                <Frame Padding="30" Margin="0,10" CornerRadius="20" HasShadow="True" BorderColor="Transparent" BackgroundColor="White">
                    <Grid ColumnDefinitions="*,Auto,*">
                        <VerticalStackLayout Grid.Column="0" Spacing="5" HorizontalOptions="Center">
                            <Label Text="{Binding PatientsCount}"
                                   FontSize="36"
                                   FontAttributes="Bold"
                                   TextColor="{StaticResource Primary}"
                                   HorizontalOptions="Center"/>
                            <Label Text="Мои пациенты"
                                   FontSize="14"
                                   TextColor="{StaticResource TextSecondary}"
                                   HorizontalOptions="Center"/>
                        </VerticalStackLayout>

                        <BoxView Grid.Column="1"
                                 WidthRequest="1"
                                 Color="#E0E0E0"
                                 VerticalOptions="Fill"
                                 Margin="20,0"/>

                        <VerticalStackLayout Grid.Column="2" Spacing="5" HorizontalOptions="Center">
                            <Label Text="{Binding PrescriptionsCount}"
                                   FontSize="36"
                                   FontAttributes="Bold"
                                   TextColor="{StaticResource Secondary}"
                                   HorizontalOptions="Center"/>
                            <Label Text="Выписано рецептов"
                                   FontSize="14"
                                   TextColor="{StaticResource TextSecondary}"
                                   HorizontalOptions="Center"/>
                        </VerticalStackLayout>
                    </Grid>
                </Frame>

                <!-- 3) Меню -->
                <VerticalStackLayout Spacing="20" Margin="0,20,0,50">
                    <Label Text="Быстрый доступ"
                           FontSize="18"
                           TextColor="{StaticResource TextPrimary}"
                           FontAttributes="Bold"
                           Margin="5,0"/>

                    <Grid ColumnDefinitions="*,*"
                          RowDefinitions="170,170"
                          ColumnSpacing="15"
                          RowSpacing="15"
                          Padding="4"
                          MaximumWidthRequest="640" 
                          HorizontalOptions="Fill">

                        <!-- Плитка 1: Пациенты -->
                        <Grid Grid.Row="0" Grid.Column="0">
                            <Frame Style="{StaticResource CardFrame}" Padding="16" HasShadow="True" 
                                   BackgroundColor="White" VerticalOptions="Fill" HorizontalOptions="Fill">
                                <Grid RowDefinitions="Auto,Auto,*" RowSpacing="0">
                                    <Frame HeightRequest="40" WidthRequest="40" CornerRadius="12"
                                           BackgroundColor="#E3F2FD" Padding="0" BorderColor="Transparent" HorizontalOptions="Start">
                                        <Label Text="👥" FontSize="20" HorizontalOptions="Center" VerticalOptions="Center"/>
                                    </Frame>
                                    <Label Grid.Row="1" Text="Пациенты" FontAttributes="Bold" FontSize="15" 
                                           TextColor="{StaticResource TextPrimary}" Margin="0,10,0,2"/>
                                    <Label Grid.Row="2" Text="Поиск и назначения" FontSize="11" 
                                           TextColor="{StaticResource TextSecondary}" LineBreakMode="TailTruncation" MaxLines="2"/>
                                </Grid>
                            </Frame>
                            <Button BackgroundColor="Transparent" 
                                    Command="{Binding GoToPatientsCommand}"
                                    CornerRadius="12"
                                    BorderWidth="0"
                                    VerticalOptions="Fill"
                                    HorizontalOptions="Fill"/> 
                        </Grid>

                        <!-- Плитка 2: Справочник -->
                        <Grid Grid.Row="0" Grid.Column="1">
                            <Frame Style="{StaticResource CardFrame}" Padding="16" HasShadow="True" 
                                   BackgroundColor="White" VerticalOptions="Fill" HorizontalOptions="Fill">
                                <Grid RowDefinitions="Auto,Auto,*" RowSpacing="0">
                                    <Frame HeightRequest="40" WidthRequest="40" CornerRadius="12"
                                           BackgroundColor="#E8F5E9" Padding="0" BorderColor="Transparent" HorizontalOptions="Start">
                                        <Label Text="💊" FontSize="20" HorizontalOptions="Center" VerticalOptions="Center"/>
                                    </Frame>
                                    <Label Grid.Row="1" Text="Лекарства" FontAttributes="Bold" FontSize="15" 
                                           TextColor="{StaticResource TextPrimary}" Margin="0,10,0,2"/>
                                    <Label Grid.Row="2" Text="База препаратов" FontSize="11" 
                                           TextColor="{StaticResource TextSecondary}" LineBreakMode="TailTruncation" MaxLines="2"/>
                                </Grid>
                            </Frame>
                            <Button BackgroundColor="Transparent" 
                                    Command="{Binding GoToMedicinesCommand}"
                                    CornerRadius="12"
                                    BorderWidth="0"
                                    VerticalOptions="Fill"
                                    HorizontalOptions="Fill"/>
                        </Grid>

                        <!-- Плитка 3: Противопоказания -->
                        <Grid Grid.Row="1" Grid.Column="0">
                            <Frame Style="{StaticResource CardFrame}" Padding="16" HasShadow="True" 
                                   BackgroundColor="White" VerticalOptions="Fill" HorizontalOptions="Fill">
                                <Grid RowDefinitions="Auto,Auto,*" RowSpacing="0">
                                    <Frame HeightRequest="40" WidthRequest="40" CornerRadius="12"
                                           BackgroundColor="#FFF3E0" Padding="0" BorderColor="Transparent" HorizontalOptions="Start">
                                        <Label Text="⚡" FontSize="20" HorizontalOptions="Center" VerticalOptions="Center"/>
                                    </Frame>
                                    <Label Grid.Row="1" Text="Противопоказания" FontAttributes="Bold" FontSize="15" 
                                           TextColor="{StaticResource TextPrimary}" Margin="0,10,0,2"/>
                                    <Label Grid.Row="2" Text="Проверка совместимости" FontSize="11" 
                                           TextColor="{StaticResource TextSecondary}" LineBreakMode="TailTruncation" MaxLines="2"/>
                                </Grid>
                            </Frame>
                            <Button BackgroundColor="Transparent" 
                                    Command="{Binding GoToInteractionsCommand}"
                                    CornerRadius="12"
                                    BorderWidth="0"
                                    VerticalOptions="Fill"
                                    HorizontalOptions="Fill"/>
                        </Grid>

                        <!-- Плитка 4: Профиль -->
                        <Grid Grid.Row="1" Grid.Column="1">
                            <Frame Style="{StaticResource CardFrame}" Padding="16" HasShadow="True" 
                                   BackgroundColor="White" VerticalOptions="Fill" HorizontalOptions="Fill">
                                <Grid RowDefinitions="Auto,Auto,*" RowSpacing="0">
                                    <Frame HeightRequest="40" WidthRequest="40" CornerRadius="12"
                                           BackgroundColor="#F3E5F5" Padding="0" BorderColor="Transparent" HorizontalOptions="Start">
                                        <Label Text="👤" FontSize="20" HorizontalOptions="Center" VerticalOptions="Center"/>
                                    </Frame>
                                    <Label Grid.Row="1" Text="Профиль" FontAttributes="Bold" FontSize="15" 
                                           TextColor="{StaticResource TextPrimary}" Margin="0,10,0,2"/>
                                    <Label Grid.Row="2" Text="Настройки аккаунта" FontSize="11" 
                                           TextColor="{StaticResource TextSecondary}" LineBreakMode="TailTruncation" MaxLines="2"/>
                                </Grid>
                            </Frame>
                            <Button BackgroundColor="Transparent" 
                                    Command="{Binding GoToProfileCommand}"
                                    CornerRadius="12"
                                    BorderWidth="0"
                                    VerticalOptions="Fill"
                                    HorizontalOptions="Fill"/>
                        </Grid>

                    </Grid>
                </VerticalStackLayout>

            </VerticalStackLayout>
        </Grid>
    </ScrollView>
</ContentPage>
```

## File: Pages/Doctor/DoctorHomePage.xaml.cs
```csharp
using MedCompatibility.ViewModels.Doctor;

namespace MedCompatibility.Pages.Doctor;

public partial class DoctorHomePage : ContentPage
{
    private readonly DoctorHomeViewModel _vm;

    public DoctorHomePage(DoctorHomeViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.OnAppearingAsync();
    }
}
```

## File: Pages/Doctor/DoctorPatientCardPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vm="clr-namespace:MedCompatibility.ViewModels.Doctor"
             xmlns:models="clr-namespace:MedCompatibility.Models"
             x:Class="MedCompatibility.Pages.Doctor.DoctorPatientCardPage"
             Title="Карта пациента"
             BackgroundColor="{StaticResource AppBackground}"
             Shell.NavBarIsVisible="False">

    <!-- 2 строки: верх Auto, низ * (чтобы ничего не наезжало) -->
    <Grid RowDefinitions="Auto, *" Padding="10" RowSpacing="12">

        <!-- Верхняя часть (как на DoctorPatientsPage) -->
        <VerticalStackLayout Grid.Row="0"
                             Spacing="12"
                             HorizontalOptions="Fill"
                             WidthRequest="{OnPlatform WinUI='800', Default='-1'}">
            <VerticalStackLayout.HorizontalOptions>
                <OnPlatform x:TypeArguments="LayoutOptions">
                    <On Platform="WinUI" Value="Center" />
                    <On Platform="Android,iOS" Value="Fill" />
                </OnPlatform>
            </VerticalStackLayout.HorizontalOptions>

            <!-- ШАПКА: Назад / Заголовок / Выход -->
            <Grid ColumnDefinitions="48,*,48" HeightRequest="48">

                <Border StrokeShape="RoundRectangle 24"
                        BackgroundColor="White"
                        StrokeThickness="0"
                        HeightRequest="48"
                        WidthRequest="48"
                        Padding="0"
                        HorizontalOptions="Start">
                    <Border.Shadow>
                        <Shadow Brush="Black" Offset="0,2" Radius="5" Opacity="0.1"/>
                    </Border.Shadow>
                    <Border.GestureRecognizers>
                        <TapGestureRecognizer Command="{Binding GoBackCommand}" />
                    </Border.GestureRecognizers>
                    <Label Text="←"
                           FontSize="28"
                           HorizontalOptions="Center"
                           VerticalOptions="Center"
                           TextColor="#333"
                           Margin="0,0,0,2"/>
                </Border>

                <VerticalStackLayout Grid.Column="1"
                                     VerticalOptions="Center"
                                     HorizontalOptions="Center"
                                     Spacing="0">
                    <Label Text="Карта пациента"
                           FontSize="20"
                           FontAttributes="Bold"
                           TextColor="{StaticResource TextPrimary}"
                           HorizontalOptions="Center"/>
                    <Label Text="Назначения и совместимость"
                           FontSize="12"
                           TextColor="{StaticResource TextSecondary}"
                           HorizontalOptions="Center"/>
                </VerticalStackLayout>

                <Border Grid.Column="2"
                        StrokeShape="RoundRectangle 24"
                        BackgroundColor="White"
                        StrokeThickness="0"
                        HeightRequest="48"
                        WidthRequest="48"
                        Padding="0"
                        HorizontalOptions="End">
                    <Border.Shadow>
                        <Shadow Brush="Black" Offset="0,2" Radius="5" Opacity="0.1"/>
                    </Border.Shadow>
                    <Border.GestureRecognizers>
                        <TapGestureRecognizer Command="{Binding LogoutCommand}" />
                    </Border.GestureRecognizers>
                    <Label Text="⎋"
                           FontSize="20"
                           HorizontalOptions="Center"
                           VerticalOptions="Center"
                           TextColor="#D32F2F"/>
                </Border>
            </Grid>

            <!-- Карточка пациента -->
            <Border StrokeShape="RoundRectangle 16"
                    BackgroundColor="White"
                    StrokeThickness="0"
                    Padding="16">
                <Border.Shadow>
                    <Shadow Brush="Black" Offset="0,2" Radius="4" Opacity="0.05"/>
                </Border.Shadow>

                <VerticalStackLayout Spacing="4">
                    <Label Text="{Binding PatientFullName}"
                           FontSize="18"
                           FontAttributes="Bold"
                           TextColor="{StaticResource TextPrimary}"
                           LineBreakMode="TailTruncation"/>
                    <Label Text="{Binding PatientLogin}"
                           FontSize="12"
                           TextColor="{StaticResource TextSecondary}"/>
                </VerticalStackLayout>
            </Border>

            <!-- Кнопка добавления -->
            <Button Text="+ Добавить препарат"
                    Command="{Binding AddMedicineCommand}"
                    BackgroundColor="{StaticResource Primary}"
                    TextColor="White"
                    CornerRadius="10"
                    HeightRequest="44"
                    FontSize="14"
                    FontAttributes="Bold"/>
        </VerticalStackLayout>

        <!-- Низ: список назначений (без Margin-костылей) -->
        <RefreshView Grid.Row="1"
                     Command="{Binding LoadDataCommand}"
                     IsRefreshing="{Binding IsBusy}"
                     RefreshColor="{StaticResource Primary}">

            <CollectionView ItemsSource="{Binding Prescriptions}"
                            SelectionMode="None"
                            HorizontalOptions="Fill"
                            WidthRequest="{OnPlatform WinUI='800', Default='-1'}">

                <CollectionView.HorizontalOptions>
                    <OnPlatform x:TypeArguments="LayoutOptions">
                        <On Platform="WinUI" Value="Center" />
                        <On Platform="Android,iOS" Value="Fill" />
                    </OnPlatform>
                </CollectionView.HorizontalOptions>

                <CollectionView.ItemsLayout>
                    <LinearItemsLayout Orientation="Vertical" ItemSpacing="10"/>
                </CollectionView.ItemsLayout>

                <CollectionView.ItemTemplate>
                    <DataTemplate x:DataType="models:prescription">
                        <Border StrokeShape="RoundRectangle 12"
                                BackgroundColor="White"
                                StrokeThickness="0"
                                Padding="12">
                            <Border.Shadow>
                                <Shadow Brush="Black" Offset="0,2" Radius="4" Opacity="0.05"/>
                            </Border.Shadow>

                            <Grid RowDefinitions="Auto,Auto"
                                  ColumnDefinitions="*,Auto"
                                  RowSpacing="4">
                                <Label Grid.Row="0"
                                       Text="{Binding Medicine.TradeName}"
                                       FontSize="15"
                                       FontAttributes="Bold"
                                       TextColor="{StaticResource TextPrimary}"
                                       LineBreakMode="TailTruncation"/>

                                <Label Grid.Row="0" Grid.Column="1"
                                       Text="{Binding PrescribedAt, StringFormat='{0:dd.MM.yyyy HH:mm}'}"
                                       FontSize="11"
                                       TextColor="{StaticResource TextSecondary}"
                                       VerticalOptions="Center"/>

                                <Label Grid.Row="1"
                                       Text="{Binding Doctor.LastName, StringFormat='Врач: {0}'}"
                                       FontSize="11"
                                       TextColor="{StaticResource TextSecondary}"/>
                            </Grid>
                        </Border>
                    </DataTemplate>
                </CollectionView.ItemTemplate>

                <CollectionView.EmptyView>
                    <VerticalStackLayout VerticalOptions="Center" HorizontalOptions="Center" Spacing="10">
                        <Label Text="Назначений нет" FontSize="18" TextColor="#999" HorizontalOptions="Center"/>
                        <Label Text="Нажмите «+ Добавить препарат»" FontSize="12" TextColor="#BBB" HorizontalOptions="Center"/>
                    </VerticalStackLayout>
                </CollectionView.EmptyView>

            </CollectionView>
        </RefreshView>

    </Grid>
</ContentPage>
```

## File: Pages/Doctor/DoctorPatientCardPage.xaml.cs
```csharp
using MedCompatibility.ViewModels.Doctor;

namespace MedCompatibility.Pages.Doctor;

public partial class DoctorPatientCardPage : ContentPage
{
    private readonly DoctorPatientCardViewModel _vm;

    public DoctorPatientCardPage(DoctorPatientCardViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadDataCommand.ExecuteAsync(null);
    }
}
```

## File: Pages/Doctor/DoctorPatientsPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vm="clr-namespace:MedCompatibility.ViewModels.Doctor"
             xmlns:models="clr-namespace:MedCompatibility.Models"
             x:Class="MedCompatibility.Pages.Doctor.DoctorPatientsPage"
             Title="Мои пациенты"
             BackgroundColor="{StaticResource AppBackground}"
             Shell.NavBarIsVisible="False">

    <Grid RowDefinitions="Auto, *" Padding="10">

        <!-- КОНТЕЙНЕР ширины как в админке -->
        <VerticalStackLayout Spacing="12"
                             HorizontalOptions="Fill"
                             WidthRequest="{OnPlatform WinUI='800', Default='-1'}">
            <VerticalStackLayout.HorizontalOptions>
                <OnPlatform x:TypeArguments="LayoutOptions">
                    <On Platform="WinUI" Value="Center" />
                    <On Platform="Android,iOS" Value="Fill" />
                </OnPlatform>
            </VerticalStackLayout.HorizontalOptions>

            <!-- 1) ШАПКА: Назад / Заголовок / Выход -->
            <Grid ColumnDefinitions="48, *, 48" HeightRequest="48">
                <!-- Назад -->
                <Border StrokeShape="RoundRectangle 24"
                        BackgroundColor="White"
                        StrokeThickness="0"
                        HeightRequest="48"
                        WidthRequest="48"
                        Padding="0"
                        HorizontalOptions="Start">
                    <Border.Shadow>
                        <Shadow Brush="Black" Offset="0,2" Radius="5" Opacity="0.1"/>
                    </Border.Shadow>
                    <Border.GestureRecognizers>
                        <TapGestureRecognizer Command="{Binding GoBackCommand}" />
                    </Border.GestureRecognizers>
                    <Label Text="←"
                           FontSize="28"
                           HorizontalOptions="Center"
                           VerticalOptions="Center"
                           TextColor="#333"
                           Margin="0,0,0,2"/>
                </Border>

                <VerticalStackLayout Grid.Column="1" VerticalOptions="Center" HorizontalOptions="Center" Spacing="0">
                    <Label Text="Мои пациенты"
                           FontSize="20"
                           FontAttributes="Bold"
                           TextColor="{StaticResource TextPrimary}"
                           HorizontalOptions="Center"/>
                    <Label Text="Список наблюдения"
                           FontSize="12"
                           TextColor="{StaticResource TextSecondary}"
                           HorizontalOptions="Center"/>
                </VerticalStackLayout>

                <!-- Выход -->
                <Border Grid.Column="2"
                        StrokeShape="RoundRectangle 24"
                        BackgroundColor="White"
                        StrokeThickness="0"
                        HeightRequest="48"
                        WidthRequest="48"
                        Padding="0"
                        HorizontalOptions="End">
                    <Border.Shadow>
                        <Shadow Brush="Black" Offset="0,2" Radius="5" Opacity="0.1"/>
                    </Border.Shadow>
                    <Border.GestureRecognizers>
                        <TapGestureRecognizer Command="{Binding LogoutCommand}" />
                    </Border.GestureRecognizers>
                    <Label Text="⎋"
                           FontSize="20"
                           HorizontalOptions="Center"
                           VerticalOptions="Center"
                           TextColor="#D32F2F"/>
                </Border>
            </Grid>

            <!-- 2) Кнопка добавления -->
            <Grid ColumnDefinitions="*, Auto">
                <BoxView Color="Transparent"/>

                <Button Grid.Column="1"
                        Text="+ Добавить"
                        Command="{Binding AddPatientCommand}"
                        BackgroundColor="{StaticResource Primary}"
                        TextColor="White"
                        CornerRadius="10"
                        HeightRequest="40"
                        FontSize="14"
                        FontAttributes="Bold"
                        Padding="15,0"/>
            </Grid>

        </VerticalStackLayout>

        <!-- 3) Список -->
        <RefreshView Grid.Row="1"
                     Command="{Binding LoadDataCommand}"
                     IsRefreshing="{Binding IsLoading}"
                     Margin="0,10,0,0">

            <CollectionView ItemsSource="{Binding Patients}"
                            SelectionMode="None"
                            HorizontalOptions="Fill"
                            WidthRequest="{OnPlatform WinUI='800', Default='-1'}">

                <CollectionView.HorizontalOptions>
                    <OnPlatform x:TypeArguments="LayoutOptions">
                        <On Platform="WinUI" Value="Center" />
                        <On Platform="Android,iOS" Value="Fill" />
                    </OnPlatform>
                </CollectionView.HorizontalOptions>

                <CollectionView.ItemsLayout>
                    <LinearItemsLayout Orientation="Vertical" ItemSpacing="10"/>
                </CollectionView.ItemsLayout>

                <CollectionView.ItemTemplate>
                    <DataTemplate x:DataType="models:user">
                        <Border StrokeShape="RoundRectangle 12"
                                BackgroundColor="White"
                                StrokeThickness="0"
                                Padding="12"
                                HeightRequest="70">
                            <Border.Shadow>
                                <Shadow Brush="Black" Offset="0,2" Radius="4" Opacity="0.05"/>
                            </Border.Shadow>

                            <Grid ColumnDefinitions="40, *, Auto" ColumnSpacing="12">

                                <Frame Grid.Column="0"
                                       HeightRequest="40"
                                       WidthRequest="40"
                                       CornerRadius="20"
                                       Padding="0"
                                       BackgroundColor="#E3F2FD"
                                       BorderColor="Transparent"
                                       HasShadow="False">
                                    <Label Text="👤"
                                           HorizontalOptions="Center"
                                           VerticalOptions="Center"
                                           FontSize="16"
                                           TextColor="#1565C0"/>
                                </Frame>

                                <VerticalStackLayout Grid.Column="1" VerticalOptions="Center" Spacing="2">
                                    <Label FontSize="14"
                                           FontAttributes="Bold"
                                           TextColor="{StaticResource TextPrimary}"
                                           LineBreakMode="TailTruncation">
                                        <Label.FormattedText>
                                            <FormattedString>
                                                <Span Text="{Binding LastName}"/>
                                                <Span Text=" "/>
                                                <Span Text="{Binding FirstName}"/>
                                            </FormattedString>
                                        </Label.FormattedText>
                                    </Label>
                                    <Label Text="{Binding Login}" FontSize="11" TextColor="{StaticResource TextSecondary}"/>
                                </VerticalStackLayout>

                                <Label Grid.Column="2"
                                       Text="❯"
                                       TextColor="#CCCCCC"
                                       FontSize="14"
                                       VerticalOptions="Center"/>

                                <!-- Прозрачная кнопка поверх карточки -->
                                <Button Grid.ColumnSpan="3"
                                        Command="{Binding Source={RelativeSource AncestorType={x:Type vm:DoctorPatientsViewModel}}, Path=OpenPatientCommand}"
                                        CommandParameter="{Binding .}"
                                        BackgroundColor="Transparent"
                                        BorderWidth="0"
                                        Opacity="0.01"/>
                            </Grid>
                        </Border>
                    </DataTemplate>
                </CollectionView.ItemTemplate>

                <CollectionView.EmptyView>
                    <VerticalStackLayout VerticalOptions="Center" HorizontalOptions="Center" Spacing="10">
                        <Label Text="Нет пациентов" FontSize="18" TextColor="#999" HorizontalOptions="Center"/>
                        <Label Text="Нажмите «+ Добавить» сверху" FontSize="12" TextColor="#BBB" HorizontalOptions="Center"/>
                    </VerticalStackLayout>
                </CollectionView.EmptyView>

            </CollectionView>
        </RefreshView>

    </Grid>
</ContentPage>
```

## File: Pages/Doctor/DoctorPatientsPage.xaml.cs
```csharp
using MedCompatibility.ViewModels.Doctor;

namespace MedCompatibility.Pages.Doctor;

public partial class DoctorPatientsPage : ContentPage
{
    private readonly DoctorPatientsViewModel _vm;

    public DoctorPatientsPage(DoctorPatientsViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_vm.LoadDataCommand.CanExecute(null))
            await _vm.LoadDataCommand.ExecuteAsync(null);
    }
}
```

## File: Pages/Patient/CompatibilityPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vm="clr-namespace:MedCompatibility.ViewModels.Patient"
             xmlns:models="clr-namespace:MedCompatibility.Models"
             x:Class="MedCompatibility.Pages.Patient.CompatibilityPage"
             Title="Совместимость"
             BackgroundColor="{StaticResource Surface}">

    <Grid RowDefinitions="Auto, *">
        <!-- Шапка -->
        <Grid Grid.Row="0" HeightRequest="60" BackgroundColor="{StaticResource Surface}">
            <Label Text="Проверка совместимости" 
                   FontSize="20"
                   FontAttributes="Bold"
                   TextColor="{StaticResource TextPrimary}"
                   VerticalOptions="Center" 
                   HorizontalOptions="Center"/>
        </Grid>

        <ScrollView Grid.Row="1" Padding="20">
            <VerticalStackLayout Spacing="20">

                <!-- Блок выбора лекарств -->
                <Grid ColumnDefinitions="*, Auto, *" ColumnSpacing="10">
                    
                    <!-- Лекарство А -->
                    <Border Grid.Column="0" StrokeShape="RoundRectangle 10" 
                            Stroke="{StaticResource Primary}" StrokeThickness="2"
                            HeightRequest="120" BackgroundColor="White">
                        <Border.GestureRecognizers>
                            <TapGestureRecognizer Command="{Binding SelectMedicineACommand}"/>
                        </Border.GestureRecognizers>
                        
                        <VerticalStackLayout VerticalOptions="Center" HorizontalOptions="Center" Spacing="5">
                            <Label Text="💊" FontSize="30" HorizontalOptions="Center"/>
                            <Label Text="{Binding MedicineA.TradeName, TargetNullValue='Нажмите для выбора'}" 
                                   TextColor="{StaticResource TextPrimary}" 
                                   FontAttributes="Bold"
                                   HorizontalTextAlignment="Center"
                                   LineBreakMode="TailTruncation"/>
                            <Label Text="Лекарство 1" FontSize="10" TextColor="{StaticResource TextSecondary}" HorizontalOptions="Center"/>
                        </VerticalStackLayout>
                    </Border>

                    <!-- Иконка плюса -->
                    <Label Grid.Column="1" Text="+" FontSize="30" VerticalOptions="Center" HorizontalOptions="Center" TextColor="{StaticResource Primary}"/>

                    <!-- Лекарство Б -->
                    <Border Grid.Column="2" StrokeShape="RoundRectangle 10" 
                            Stroke="{StaticResource Primary}" StrokeThickness="2"
                            HeightRequest="120" BackgroundColor="White">
                        <Border.GestureRecognizers>
                            <TapGestureRecognizer Command="{Binding SelectMedicineBCommand}"/>
                        </Border.GestureRecognizers>
                        
                        <VerticalStackLayout VerticalOptions="Center" HorizontalOptions="Center" Spacing="5">
                            <Label Text="💊" FontSize="30" HorizontalOptions="Center"/>
                            <Label Text="{Binding MedicineB.TradeName, TargetNullValue='Нажмите для выбора'}" 
                                   TextColor="{StaticResource TextPrimary}" 
                                   FontAttributes="Bold"
                                   HorizontalTextAlignment="Center"
                                   LineBreakMode="TailTruncation"/>
                            <Label Text="Лекарство 2" FontSize="10" TextColor="{StaticResource TextSecondary}" HorizontalOptions="Center"/>
                        </VerticalStackLayout>
                    </Border>
                </Grid>

                <!-- Кнопки действия -->
                <Grid ColumnDefinitions="*, Auto" ColumnSpacing="10">
                    <Button Grid.Column="0" Text="Проверить" 
                            Command="{Binding CheckCommand}" 
                            BackgroundColor="{StaticResource Primary}"
                            TextColor="White"
                            CornerRadius="10"
                            FontAttributes="Bold"
                            HeightRequest="50"/>
                    
                    <Button Grid.Column="1" Text="🗑️" 
                            Command="{Binding ClearCommand}" 
                            BackgroundColor="{StaticResource Surface}" 
                            TextColor="Red"
                            BorderColor="Red"
                            BorderWidth="1"
                            CornerRadius="10"
                            WidthRequest="50"
                            HeightRequest="50"/>
                </Grid>

                <ActivityIndicator IsRunning="{Binding IsBusy}" Color="{StaticResource Primary}" />

                <!-- Статус -->
                <Label Text="{Binding StatusMessage}" 
                       TextColor="{StaticResource TextSecondary}" 
                       HorizontalTextAlignment="Center"
                       FontAttributes="Italic"/>

                <!-- Результаты -->
                <VerticalStackLayout IsVisible="{Binding HasConflicts}" Spacing="10">
                    <Label Text="Найденные взаимодействия:" 
                           FontSize="18" 
                           FontAttributes="Bold" 
                           TextColor="{StaticResource TextPrimary}"/>
                    
                    <CollectionView ItemsSource="{Binding FoundConflicts}">
                        <CollectionView.ItemTemplate>
                            <DataTemplate x:DataType="models:interaction">
                                <Border StrokeShape="RoundRectangle 10" StrokeThickness="0" 
                                        BackgroundColor="White" Margin="0,0,0,10" Padding="15">
                                    <Border.Shadow>
                                        <Shadow Brush="Black" Offset="0,2" Radius="5" Opacity="0.1"/>
                                    </Border.Shadow>

                                    <VerticalStackLayout Spacing="8">
                                        <!-- Заголовок с уровнем риска -->
                                        <Grid ColumnDefinitions="*, Auto">
                                            <Label Text="{Binding RiskLevel.Name}" 
                                                   TextColor="Red" FontAttributes="Bold" FontSize="16"/>
                                        </Grid>
                                        
                                        <!-- Вещества -->
                                         <Label>
                                            <Label.FormattedText>
                                                <FormattedString>
                                                    <Span Text="Вещества: " TextColor="{StaticResource TextSecondary}"/>
                                                    <Span Text="{Binding SubstanceId1Navigation.Name}" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}"/>
                                                    <Span Text=" ↔ " TextColor="{StaticResource TextSecondary}"/>
                                                    <Span Text="{Binding SubstanceId2Navigation.Name}" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}"/>
                                                </FormattedString>
                                            </Label.FormattedText>
                                        </Label>

                                        <BoxView HeightRequest="1" Color="{StaticResource Secondary}" Opacity="0.3"/>

                                        <!-- Описание -->
                                        <Label Text="{Binding Description}" TextColor="{StaticResource TextPrimary}"/>
                                        
                                        <!-- Рекомендация -->
                                        <Label Text="{Binding Recommendation, StringFormat='Рекомендация: {0}'}" 
                                               TextColor="{StaticResource Primary}">
                                            <Label.Triggers>
                                                <DataTrigger TargetType="Label" Binding="{Binding Recommendation}" Value="{x:Null}">
                                                    <Setter Property="IsVisible" Value="False"/>
                                                </DataTrigger>
                                                <DataTrigger TargetType="Label" Binding="{Binding Recommendation}" Value="">
                                                    <Setter Property="IsVisible" Value="False"/>
                                                </DataTrigger>
                                            </Label.Triggers>
                                        </Label>
                                    </VerticalStackLayout>
                                </Border>
                            </DataTemplate>
                        </CollectionView.ItemTemplate>
                    </CollectionView>
                </VerticalStackLayout>

            </VerticalStackLayout>
        </ScrollView>
    </Grid>
</ContentPage>
```

## File: Pages/Patient/CompatibilityPage.xaml.cs
```csharp
using MedCompatibility.ViewModels.Patient;

namespace MedCompatibility.Pages.Patient;

public partial class CompatibilityPage : ContentPage
{
    public CompatibilityPage(CompatibilityViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
```

## File: Pages/Patient/HistoryPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vm="clr-namespace:MedCompatibility.ViewModels.Patient"
             xmlns:models="clr-namespace:MedCompatibility.Models"
             x:Class="MedCompatibility.Pages.Patient.HistoryPage"
             Title="История"
             BackgroundColor="{StaticResource Surface}"
             Shell.NavBarIsVisible="False"> <!-- Скрываем стандартный бар -->

    <Grid RowDefinitions="Auto, *">
        
        <!-- 1. СВОЙ КРАСИВЫЙ ЗАГОЛОВОК -->
        <Grid Grid.Row="0" HeightRequest="60" BackgroundColor="{StaticResource Surface}" Padding="20,0">
            <Label Text="История проверок" 
                   TextColor="{StaticResource TextPrimary}" 
                   FontSize="22" 
                   FontAttributes="Bold" 
                   VerticalOptions="Center"/>
        </Grid>

        <!-- ВАРИАНТ ДЛЯ ПОЛЬЗОВАТЕЛЯ -->
        <RefreshView Grid.Row="1" IsVisible="{Binding IsUser}" 
                     Command="{Binding LoadHistoryCommand}" 
                     IsRefreshing="{Binding IsBusy}">
            
            <CollectionView ItemsSource="{Binding HistoryItems}" 
                            SelectionMode="None">
                
                <!-- Заглушка, если список пуст -->
                <CollectionView.EmptyView>
                    <VerticalStackLayout Spacing="10" VerticalOptions="Center" HorizontalOptions="Center">
                        <Label Text="📜" FontSize="50" HorizontalOptions="Center"/>
                        <Label Text="История пуста" 
                               FontSize="18" TextColor="{StaticResource TextPrimary}" HorizontalOptions="Center"/>
                        <Label Text="Здесь появятся ваши сканирования" 
                               FontSize="14" TextColor="{StaticResource TextSecondary}" HorizontalOptions="Center"/>
                    </VerticalStackLayout>
                </CollectionView.EmptyView>
                
                <CollectionView.ItemsLayout>
                    <LinearItemsLayout Orientation="Vertical" ItemSpacing="12"/>
                </CollectionView.ItemsLayout>
                
                <!-- Отступы списка -->
                <CollectionView.Header>
                    <BoxView HeightRequest="10" Color="Transparent"/>
                </CollectionView.Header>
                <CollectionView.Footer>
                    <BoxView HeightRequest="20" Color="Transparent"/>
                </CollectionView.Footer>

                <CollectionView.ItemTemplate>
                    <DataTemplate x:DataType="models:scan">
                        <!-- Карточка -->
                        <Border StrokeShape="RoundRectangle 16" BackgroundColor="White" StrokeThickness="0" Padding="15" Margin="15,0,15,0">
                            <Border.Shadow>
                                <Shadow Brush="Black" Offset="0,4" Radius="8" Opacity="0.05"/>
                            </Border.Shadow>
                            
                            <!-- ОБРАБОТЧИК НАЖАТИЯ -->
                            <Border.GestureRecognizers>
                                <TapGestureRecognizer Command="{Binding Source={RelativeSource AncestorType={x:Type vm:HistoryViewModel}}, Path=GoToDetailsCommand}" 
                                                      CommandParameter="{Binding .}"/>
                            </Border.GestureRecognizers>
                            
                            <Grid ColumnDefinitions="*, Auto" RowDefinitions="Auto, Auto" RowSpacing="5">
                                <!-- Название лекарства -->
                                <Label Text="{Binding Medicine.TradeName}" 
                                       FontAttributes="Bold" FontSize="17" TextColor="{StaticResource TextPrimary}" 
                                       LineBreakMode="TailTruncation"/>
                                
                                <!-- МНН (Состав) -->
                                <Label Grid.Row="1" Text="{Binding Medicine.INN}" 
                                       FontSize="13" TextColor="{StaticResource TextSecondary}" 
                                       LineBreakMode="TailTruncation" MaxLines="2"/>
                                
                                <!-- Дата и время (справа) -->
                                <VerticalStackLayout Grid.Column="1" Grid.RowSpan="2" VerticalOptions="Center" Spacing="2">
                                    <Label Text="{Binding ScannedAt, StringFormat='{0:HH:mm}'}" 
                                           HorizontalOptions="End" FontSize="14" FontAttributes="Bold" TextColor="{StaticResource Primary}"/>
                                    <Label Text="{Binding ScannedAt, StringFormat='{0:dd MMM}'}" 
                                           HorizontalOptions="End" FontSize="11" TextColor="#999"/>
                                </VerticalStackLayout>
                            </Grid>
                        </Border>
                    </DataTemplate>
                </CollectionView.ItemTemplate>
            </CollectionView>
        </RefreshView>

        <!-- ВАРИАНТ ДЛЯ ГОСТЯ -->
        <Grid Grid.Row="1" IsVisible="{Binding IsGuest}" RowDefinitions="*, Auto, *" RowSpacing="20" Padding="30" BackgroundColor="{StaticResource Surface}">
            <VerticalStackLayout Grid.Row="1" Spacing="20" VerticalOptions="Center">
                <Border StrokeShape="RoundRectangle 40" HeightRequest="80" WidthRequest="80" BackgroundColor="#E0F7FA" StrokeThickness="0" HorizontalOptions="Center">
                    <Label Text="🔒" FontSize="36" HorizontalOptions="Center" VerticalOptions="Center"/>
                </Border>
                
                <Label Text="История недоступна" 
                       FontSize="20" FontAttributes="Bold" HorizontalTextAlignment="Center" TextColor="{StaticResource TextPrimary}"/>
                
                <Label Text="Войдите в аккаунт, чтобы сохранять историю проверок и иметь доступ к ней с любого устройства." 
                       FontSize="15" HorizontalTextAlignment="Center" TextColor="{StaticResource TextSecondary}" LineHeight="1.2"/>
                
                <Button Text="Войти в аккаунт" 
                        Command="{Binding GoToLoginCommand}"
                        BackgroundColor="{StaticResource Primary}" TextColor="White"
                        CornerRadius="25" HeightRequest="50" FontAttributes="Bold" 
                        Shadow="{Shadow Brush={StaticResource Primary}, Offset='0,4', Radius=10, Opacity=0.4}"
                        Margin="0,20,0,0" WidthRequest="200"/>
            </VerticalStackLayout>
        </Grid>
    </Grid>
</ContentPage>
```

## File: Pages/Patient/HistoryPage.xaml.cs
```csharp
using MedCompatibility.ViewModels.Patient;

namespace MedCompatibility.Pages.Patient;

public partial class HistoryPage : ContentPage
{
    private readonly HistoryViewModel _viewModel;

    public HistoryPage(HistoryViewModel vm)
    {
        InitializeComponent();
        BindingContext = _viewModel = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Загружаем данные каждый раз при открытии вкладки
        await _viewModel.LoadHistoryCommand.ExecuteAsync(null);
    }
}
```

## File: Pages/Patient/MedicineDetailsPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vm="clr-namespace:MedCompatibility.ViewModels.Patient"
             x:Class="MedCompatibility.Pages.Patient.MedicineDetailsPage"
             Title="Детали"
             BackgroundColor="{StaticResource Surface}">

    <Grid RowDefinitions="Auto, *">
        <!-- Шапка -->
        <Grid Grid.Row="0" HeightRequest="60" Padding="15,0" BackgroundColor="{StaticResource Surface}">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            
            <Button Grid.Column="0" Text="❮ Назад" Command="{Binding GoBackCommand}" 
                    BackgroundColor="Transparent" TextColor="{StaticResource Primary}" 
                    Padding="0" HorizontalOptions="Start" HeightRequest="40"/>

            <Label Grid.Column="1" Text="Информация о препарате" 
                   VerticalOptions="Center" HorizontalOptions="Center" 
                   FontSize="18" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}"/>
        </Grid>

        <ScrollView Grid.Row="1" Padding="20">
            <VerticalStackLayout Spacing="20">
                
                <!-- Основная карточка -->
                <Border StrokeShape="RoundRectangle 20" BackgroundColor="White" Padding="20" StrokeThickness="0">
                    <Border.Shadow>
                        <Shadow Brush="Black" Offset="0,4" Radius="10" Opacity="0.1"/>
                    </Border.Shadow>
                    
                    <VerticalStackLayout Spacing="15">
                        <Label Text="💊" FontSize="50" HorizontalOptions="Center" TextColor="{StaticResource Primary}"/>
                        
                        <Label Text="{Binding SelectedMedicine.TradeName}" 
                               FontSize="24" FontAttributes="Bold" 
                               HorizontalOptions="Center" HorizontalTextAlignment="Center"
                               TextColor="{StaticResource TextPrimary}"/>
                        
                        <BoxView HeightRequest="1" Color="{StaticResource Secondary}" Opacity="0.2"/>

                        <!-- Детали -->
                        <Grid ColumnDefinitions="Auto, *" RowDefinitions="Auto, Auto, Auto, Auto" RowSpacing="10" ColumnSpacing="15">
                            
                            <!-- Производитель -->
                            <Label Grid.Row="0" Grid.Column="0" Text="Производитель:" FontAttributes="Bold" TextColor="{StaticResource TextSecondary}"/>
                            <Label Grid.Row="0" Grid.Column="1" Text="{Binding SelectedMedicine.Manufacturer.Name}" TextColor="{StaticResource TextPrimary}"/>

                            <!-- Форма -->
                            <Label Grid.Row="1" Grid.Column="0" Text="Форма выпуска:" FontAttributes="Bold" TextColor="{StaticResource TextSecondary}"/>
                            <Label Grid.Row="1" Grid.Column="1" Text="{Binding SelectedMedicine.Form}" TextColor="{StaticResource TextPrimary}"/>

                            <!-- Штрихкод -->
                            <Label Grid.Row="2" Grid.Column="0" Text="Штрихкод (GTIN):" FontAttributes="Bold" TextColor="{StaticResource TextSecondary}"/>
                            <Label Grid.Row="2" Grid.Column="1" Text="{Binding SelectedMedicine.GTIN}" TextColor="{StaticResource TextPrimary}" FontFamily="Monospace"/>

                             <!-- МНН -->
                            <Label Grid.Row="3" Grid.Column="0" Text="МНН:" FontAttributes="Bold" TextColor="{StaticResource TextSecondary}"/>
                            <Label Grid.Row="3" Grid.Column="1" Text="{Binding SelectedMedicine.INN}" TextColor="{StaticResource TextPrimary}"/>
                        </Grid>
                    </VerticalStackLayout>
                </Border>

                <!-- Состав -->
                <Border StrokeShape="RoundRectangle 20" BackgroundColor="White" Padding="20" StrokeThickness="0">
                    <Border.Shadow>
                         <Shadow Brush="Black" Offset="0,2" Radius="5" Opacity="0.1"/>
                    </Border.Shadow>
                    <VerticalStackLayout Spacing="10">
                        <Label Text="Активные вещества" FontAttributes="Bold" FontSize="16" TextColor="{StaticResource Primary}"/>
                        <Label Text="{Binding SubstancesText}" TextColor="{StaticResource TextPrimary}" LineBreakMode="WordWrap"/>
                    </VerticalStackLayout>
                </Border>

                <!-- Описание (с исправленными триггерами) -->
                <Border StrokeShape="RoundRectangle 20" BackgroundColor="White" Padding="20" StrokeThickness="0">
                    <Border.Triggers>
                        <!-- Скрываем блок, если описание null -->
                        <DataTrigger TargetType="Border" Binding="{Binding SelectedMedicine.Description}" Value="{x:Null}">
                            <Setter Property="IsVisible" Value="False"/>
                        </DataTrigger>
                        <!-- Скрываем блок, если описание пустое -->
                        <DataTrigger TargetType="Border" Binding="{Binding SelectedMedicine.Description}" Value="">
                            <Setter Property="IsVisible" Value="False"/>
                        </DataTrigger>
                    </Border.Triggers>

                    <Border.Shadow>
                         <Shadow Brush="Black" Offset="0,2" Radius="5" Opacity="0.1"/>
                    </Border.Shadow>
                    <VerticalStackLayout Spacing="10">
                        <Label Text="Описание" FontAttributes="Bold" FontSize="16" TextColor="{StaticResource Primary}"/>
                        <Label Text="{Binding SelectedMedicine.Description}" TextColor="{StaticResource TextPrimary}"/>
                    </VerticalStackLayout>
                </Border>

            </VerticalStackLayout>
        </ScrollView>
    </Grid>
</ContentPage>
```

## File: Pages/Patient/MedicineDetailsPage.xaml.cs
```csharp
using MedCompatibility.ViewModels.Patient;

namespace MedCompatibility.Pages.Patient;

public partial class MedicineDetailsPage : ContentPage
{
    public MedicineDetailsPage(MedicineDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
```

## File: Pages/Patient/ProfilePage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MedCompatibility.Pages.Patient.ProfilePage"
             BackgroundColor="{StaticResource Surface}"
             Title="Профиль">

    <Grid RowDefinitions="Auto, *">
        <!-- Шапка -->
        <Grid Grid.Row="0" HeightRequest="60" Padding="20,0" BackgroundColor="{StaticResource Surface}">
            <Label Text="Мой профиль" VerticalOptions="Center" FontSize="22" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}"/>
            
            <!-- Кнопка -->
            <Button Text="Выйти" 
                    Command="{Binding LogoutCommand}" 
                    IsVisible="{Binding IsUser}"
                    HorizontalOptions="End" 
                    VerticalOptions="Center"
                    HeightRequest="36"
                    Padding="15,0"
                    BackgroundColor="#FFEBEE" 
                    TextColor="#D32F2F"
                    CornerRadius="18"
                    FontSize="12"
                    FontAttributes="Bold"/>
        </Grid>

        <ScrollView Grid.Row="1" Padding="20">
            <VerticalStackLayout Spacing="30">
                
                <!-- Аватар -->
                <Border StrokeShape="RoundRectangle 50" 
                        HeightRequest="100" WidthRequest="100" 
                        HorizontalOptions="Center"
                        Stroke="{StaticResource Primary}" StrokeThickness="2"
                        BackgroundColor="White">
                    <Label Text="👤" FontSize="50" HorizontalOptions="Center" VerticalOptions="Center" TextColor="{StaticResource Primary}"/>
                </Border>

                <!-- Блок гост. -->
                <VerticalStackLayout IsVisible="{Binding IsGuest}" Spacing="20">
                    <Label Text="Вы вошли как Гость" HorizontalOptions="Center" FontSize="20" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}"/>
                    <Label Text="Зарегистрируйтесь, чтобы сохранять историю проверок и получать доступ ко всем функциям." 
                           HorizontalTextAlignment="Center" TextColor="{StaticResource TextSecondary}" FontSize="14"/>
                    <Button Text="Войти или Создать аккаунт" 
                            Command="{Binding GoToLoginCommand}" 
                            BackgroundColor="{StaticResource Primary}" 
                            TextColor="White"
                            CornerRadius="25"
                            HeightRequest="50"
                            FontAttributes="Bold"
                            Margin="20,10"/>
                </VerticalStackLayout>

                <!-- Блок польз. -->
                <VerticalStackLayout IsVisible="{Binding IsUser}" Spacing="20">
                    
                    <!-- Режим просм. -->
                    <VerticalStackLayout IsVisible="{Binding IsNotEditing}" Spacing="5">
                        <Label Text="{Binding FullName}" 
                               FontSize="22" FontAttributes="Bold" 
                               HorizontalOptions="Center" TextColor="{StaticResource TextPrimary}"/>
                        
                        <Label Text="{Binding RoleName}" 
                               FontSize="14" 
                               HorizontalOptions="Center" TextColor="{StaticResource TextSecondary}"/>

                        <!-- Кнопка редактир. -->
                        <Button Text="✏️ Редактировать данные" 
                                Command="{Binding StartEditingCommand}" 
                                Margin="0,20,0,0"
                                BackgroundColor="Transparent" 
                                TextColor="{StaticResource Primary}" 
                                FontAttributes="Bold"
                                FontSize="14"
                                HorizontalOptions="Center"/>
                    </VerticalStackLayout>

                    <!-- Режим редакт. -->
                    <Border IsVisible="{Binding IsEditing}" 
                            StrokeShape="RoundRectangle 15" 
                            BackgroundColor="White" 
                            Padding="20"
                            StrokeThickness="0">
                        <Border.Shadow>
                            <Shadow Brush="Black" Offset="0,2" Radius="10" Opacity="0.1"/>
                        </Border.Shadow>

                        <VerticalStackLayout Spacing="15">
                            <Label Text="Изменение данных" FontAttributes="Bold" FontSize="16" TextColor="{StaticResource TextPrimary}" Margin="0,0,0,10"/>
                            
                            <VerticalStackLayout Spacing="5">
                                <Label Text="Фамилия" FontSize="12" TextColor="{StaticResource TextSecondary}"/>
                                <Border Stroke="{StaticResource TextSecondary}" StrokeThickness="1" StrokeShape="RoundRectangle 8" HeightRequest="45" Padding="10,0">
                                    <Entry Placeholder="Фамилия" Text="{Binding EditLastName}" TextColor="{StaticResource TextPrimary}" VerticalOptions="Center"/>
                                </Border>
                            </VerticalStackLayout>

                            <VerticalStackLayout Spacing="5">
                                <Label Text="Имя" FontSize="12" TextColor="{StaticResource TextSecondary}"/>
                                <Border Stroke="{StaticResource TextSecondary}" StrokeThickness="1" StrokeShape="RoundRectangle 8" HeightRequest="45" Padding="10,0">
                                    <Entry Placeholder="Имя" Text="{Binding EditFirstName}" TextColor="{StaticResource TextPrimary}" VerticalOptions="Center"/>
                                </Border>
                            </VerticalStackLayout>

                            <VerticalStackLayout Spacing="5">
                                <Label Text="Отчество" FontSize="12" TextColor="{StaticResource TextSecondary}"/>
                                <Border Stroke="{StaticResource TextSecondary}" StrokeThickness="1" StrokeShape="RoundRectangle 8" HeightRequest="45" Padding="10,0">
                                    <Entry Placeholder="Отчество" Text="{Binding EditMiddleName}" TextColor="{StaticResource TextPrimary}" VerticalOptions="Center"/>
                                </Border>
                            </VerticalStackLayout>

                            <Grid ColumnDefinitions="*, *" ColumnSpacing="15" Margin="0,10,0,0">
                                <Button Grid.Column="0" Text="Отмена" Command="{Binding CancelEditingCommand}" 
                                        BackgroundColor="#F5F5F5" TextColor="{StaticResource TextPrimary}"
                                        CornerRadius="10"/>
                                <Button Grid.Column="1" Text="Сохранить" Command="{Binding SaveChangesCommand}" 
                                        BackgroundColor="{StaticResource Primary}" TextColor="White"
                                        CornerRadius="10"/>
                            </Grid>
                        </VerticalStackLayout>
                    </Border>
                    
                </VerticalStackLayout>

            </VerticalStackLayout>
        </ScrollView>
    </Grid>
</ContentPage>
```

## File: Pages/Patient/ProfilePage.xaml.cs
```csharp
using MedCompatibility.ViewModels.Patient;

namespace MedCompatibility.Pages.Patient;

public partial class ProfilePage : ContentPage
{
    private readonly ProfileViewModel _viewModel;

    public ProfilePage(ProfileViewModel vm)
    {
        InitializeComponent();
        BindingContext = _viewModel = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadProfileCommand.Execute(null);
    }
}
```

## File: Pages/Patient/ScanPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vm="clr-namespace:MedCompatibility.ViewModels.Patient"
             x:Class="MedCompatibility.Pages.Patient.ScanPage"
             Title="Проверка лекарств"
             BackgroundColor="{StaticResource AppBackground}">

    <ScrollView>
        <VerticalStackLayout Spacing="20" Padding="20">
            
            <!-- Заголовок -->
            <Label Text="Проверка совместимости" 
                   FontSize="22" FontAttributes="Bold" TextColor="{StaticResource Primary}" 
                   HorizontalOptions="Center"/>

            <!-- Поле поиска -->
            <Border StrokeShape="RoundRectangle 25" BackgroundColor="White" StrokeThickness="0" HeightRequest="50" Padding="15,0">
                <Border.Shadow>
                    <Shadow Brush="Black" Offset="0,4" Radius="10" Opacity="0.1"/>
                </Border.Shadow>
                <Grid ColumnDefinitions="*, Auto">
                    <Entry Placeholder="Введите название или штрихкод" 
                           Text="{Binding SearchQuery}"
                           TextColor="{StaticResource TextPrimary}"
                           VerticalOptions="Center" ReturnCommand="{Binding SearchCommand}"/>
                    
                    <ImageButton Grid.Column="1" Source="search_icon.png"  HeightRequest="24" WidthRequest="24"
                                 Command="{Binding SearchCommand}" VerticalOptions="Center">
                        <!-- Если нет иконки, можно текст -->
                    </ImageButton>
                </Grid>
            </Border>

            <!-- Кнопка сканера -->
            <Button Text="📷 Сканировать штрихкод" 
                    BackgroundColor="{StaticResource Primary}" TextColor="White"
                    CornerRadius="25" HeightRequest="50" FontAttributes="Bold"
                    Command="{Binding ScanBarcodeCommand}"/>

            <!-- Результат: Лекарство найдено -->
            <Border IsVisible="{Binding IsMedicineVisible}" StrokeShape="RoundRectangle 15" BackgroundColor="White" StrokeThickness="0" Padding="15">
                <VerticalStackLayout Spacing="10">
                    <Label Text="Результат:" TextColor="#999" FontSize="12"/>
                    <Label Text="{Binding FoundMedicine.TradeName}" FontSize="20" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}"/>
                    <Label Text="{Binding FoundMedicine.INN}" FontSize="14" TextColor="{StaticResource TextSecondary}"/>
                    
                    <BoxView HeightRequest="1" Color="#EEE" Margin="0,5"/>
                    
                    <Label Text="Состав:" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}"/>
                    <!-- Тут можно вывести список веществ через BindableLayout, если он подгружен -->
                    
                    <Label Text="✅ Лекарство распознано и добавлено в историю." TextColor="Green" FontSize="12"/>
                </VerticalStackLayout>
            </Border>

            <!-- Результат: Не найдено -->
            <Label IsVisible="{Binding IsNotFoundVisible}" 
                   Text="Лекарство не найдено в базе данных." 
                   TextColor="#FF5252" HorizontalOptions="Center"/>

        </VerticalStackLayout>
    </ScrollView>
</ContentPage>
```

## File: Pages/Patient/ScanPage.xaml.cs
```csharp
using MedCompatibility.ViewModels.Patient;

namespace MedCompatibility.Pages.Patient;

public partial class ScanPage : ContentPage
{
    public ScanPage(ScanPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
```

## File: Pages/Shared/CodeScannerPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:controls="clr-namespace:ZXing.Net.Maui.Controls;assembly=ZXing.Net.MAUI.Controls"
             x:Class="MedCompatibility.Pages.Shared.CodeScannerPage"
             Title="Сканер"
             Shell.TabBarIsVisible="False"
             BackgroundColor="Black">

    <Grid>
        <!-- Камера (на весь экран) -->
        <controls:CameraBarcodeReaderView 
            x:Name="BarcodeReader"
            BarcodesDetected="BarcodeReader_BarcodesDetected"
            IsDetecting="True"
            IsTorchOn="False" 
            Options="{Binding BarcodeOptions}"/>

        <!-- UI Наложения (Прицел) -->
        <Grid RowDefinitions="*, 300, *" ColumnDefinitions="*, 300, *">
            <!-- Полупрозрачное затемнение -->
            <BoxView Grid.Row="0" Grid.ColumnSpan="3" Color="#80000000"/>
            <BoxView Grid.Row="2" Grid.ColumnSpan="3" Color="#80000000"/>
            <BoxView Grid.Row="1" Grid.Column="0" Color="#80000000"/>
            <BoxView Grid.Row="1" Grid.Column="2" Color="#80000000"/>
            
            <!-- Рамка сканирования (Активная зона) -->
            <Border Grid.Row="1" Grid.Column="1" 
                    Stroke="{StaticResource Primary}" 
                    StrokeThickness="3"
                    BackgroundColor="Transparent"
                    StrokeShape="RoundRectangle 20"/>

            <!-- Подсказка сверху -->
            <Label Grid.Row="0" Grid.ColumnSpan="3" 
                   Text="Наведите камеру на штрихкод" 
                   TextColor="White" FontSize="16"
                   HorizontalOptions="Center" VerticalOptions="End" Margin="0,0,0,30"/>
            
            <!-- Кнопка Отмена снизу -->
            <Button Grid.Row="2" Grid.ColumnSpan="3"
                    Text="Отмена"
                    Clicked="OnCancelClicked"
                    VerticalOptions="Start" HorizontalOptions="Center" 
                    Margin="0,30,0,0"
                    BackgroundColor="{StaticResource Surface}" 
                    TextColor="{StaticResource TextPrimary}"
                    CornerRadius="20" HeightRequest="50" WidthRequest="150"/>
        </Grid>
    </Grid>
</ContentPage>
```

## File: Pages/Shared/CodeScannerPage.xaml.cs
```csharp
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls; // Убедись, что этот неймспейс есть для CameraBarcodeReaderView

namespace MedCompatibility.Pages.Shared;

public partial class CodeScannerPage : ContentPage
{
    public CodeScannerPage()
    {
        InitializeComponent();
        
        // Настраиваем опции сканера через код (или можно через Binding, как у тебя в XAML, но через код надежнее)
        BarcodeReader.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormat.Ean13 | BarcodeFormat.QrCode, 
            AutoRotate = true,
            Multiple = false
        };
    }

    // Обработчик события обнаружения (как в XAML: BarcodesDetected="BarcodeReader_BarcodesDetected")
    private void BarcodeReader_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        var first = e.Results?.FirstOrDefault();
        if (first is null) return;

        // Останавливаем, чтобы не спамить
        BarcodeReader.IsDetecting = false;

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            // Возвращаем результат вызывающей стороне
            var navigationParameter = new Dictionary<string, object>
            {
                { "ScannedCode", first.Value }
            };
            
            await Shell.Current.GoToAsync("..", navigationParameter);
        });
    }

    // Обработчик кнопки "Отмена" (как в XAML: Clicked="OnCancelClicked")
    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
```

## File: Pages/Shared/LoginPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage
    Shell.NavBarIsVisible="False"
    x:Class="MedCompatibility.Pages.Shared.LoginPage"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">

    <Grid>

        <!--  Фон (у Login своя раскладка пузырьков)  -->
        <AbsoluteLayout InputTransparent="True">
            <!--  Большой слева снизу  -->
            <BoxView
                AbsoluteLayout.LayoutBounds="0.05,0.80,680,680"
                AbsoluteLayout.LayoutFlags="PositionProportional"
                Color="#140097A7"
                CornerRadius="340"
                HeightRequest="680"
                WidthRequest="680" />

            <!--  Средний справа снизу  -->
            <BoxView
                AbsoluteLayout.LayoutBounds="0.95,0.92,460,460"
                AbsoluteLayout.LayoutFlags="PositionProportional"
                Color="#0F90A4AE"
                CornerRadius="230"
                HeightRequest="460"
                WidthRequest="460" />

            <!--  Маленький сверху  -->
            <BoxView
                AbsoluteLayout.LayoutBounds="0.52,0.08,260,260"
                AbsoluteLayout.LayoutFlags="PositionProportional"
                Color="#1A00796B"
                CornerRadius="130"
                HeightRequest="260"
                WidthRequest="260" />
        </AbsoluteLayout>

        <ScrollView VerticalScrollBarVisibility="Never">
            <VerticalStackLayout
                HorizontalOptions="Center"
                MaximumWidthRequest="440"
                Padding="20"
                Spacing="16"
                VerticalOptions="Center">

                <!--  Шапка: стикер + название + слоган (как на старом)  -->
                <VerticalStackLayout HorizontalOptions="Center" Spacing="8">

                    <Border
                        BackgroundColor="{StaticResource Surface}"
                        HeightRequest="54"
                        HorizontalOptions="Center"
                        Padding="10"
                        Stroke="#E6EAF0"
                        StrokeShape="RoundRectangle 999"
                        StrokeThickness="1"
                        WidthRequest="54">
                        <Border.Shadow>
                            <Shadow
                                Brush="#90A4AE"
                                Offset="0,8"
                                Opacity="0.10"
                                Radius="20" />
                        </Border.Shadow>

                        <Label
                            FontSize="26"
                            HorizontalOptions="Center"
                            Text="🩺"
                            VerticalOptions="Center" />
                    </Border>

                    <Label
                        FontAttributes="Bold"
                        FontSize="26"
                        HorizontalTextAlignment="Center"
                        Text="MedCompatibility"
                        TextColor="{StaticResource TextPrimary}" />

                    <Label
                        FontSize="13"
                        HorizontalTextAlignment="Center"
                        Text="Безопасность вашего здоровья"
                        TextColor="{StaticResource TextSecondary}" />

                </VerticalStackLayout>

                <!--  Карточка логина  -->
                <Frame
                    Padding="22"
                    Style="{StaticResource CardFrame}"
                    WidthRequest="380">

                    <VerticalStackLayout Spacing="14">

                        <VerticalStackLayout Spacing="6">
                            <Label
                                FontSize="12"
                                Text="Логин"
                                TextColor="{StaticResource TextSecondary}" />
                            <Border Style="{StaticResource InputFrame}">
                                <Entry
                                    Placeholder="Введите ваш логин"
                                    PlaceholderColor="{StaticResource TextPlaceholder}"
                                    Text="{Binding Login}"
                                    TextColor="{StaticResource TextPrimary}" />
                            </Border>
                        </VerticalStackLayout>

                        <VerticalStackLayout Spacing="6">
                            <Label
                                FontSize="12"
                                Text="Пароль"
                                TextColor="{StaticResource TextSecondary}" />
                            <Border Style="{StaticResource InputFrame}">
                                <Grid ColumnDefinitions="*,Auto">
                                    <Entry
                                        Grid.Column="0"
                                        IsPassword="{Binding IsPasswordHidden}"
                                        Placeholder="Введите ваш пароль"
                                        PlaceholderColor="{StaticResource TextPlaceholder}"
                                        Text="{Binding Password}"
                                        TextColor="{StaticResource TextPrimary}" />
                                    <Button
                                        BackgroundColor="Transparent"
                                        Command="{Binding TogglePasswordVisibilityCommand}"
                                        Grid.Column="1"
                                        HeightRequest="46"
                                        Padding="0"
                                        Text="{Binding EyeIconText}"
                                        TextColor="{StaticResource TextSecondary}"
                                        WidthRequest="46" />
                                </Grid>
                            </Border>
                        </VerticalStackLayout>

                        <Label
                            FontSize="13"
                            HorizontalTextAlignment="Center"
                            IsVisible="{Binding IsErrorVisible}"
                            Text="{Binding ErrorMessage}"
                            TextColor="{StaticResource Error}" />

                        <Button
                            Command="{Binding LoginCommand}"
                            Style="{StaticResource PrimaryButton}"
                            Text="Войти" />

                        <Button
                            Command="{Binding GoogleLoginCommand}"
                            Style="{StaticResource SecondaryButton}"
                            Text="Продолжить с Google" />

                        <!--  Разделитель как на старом ("Или")  -->
                        <Grid
                            ColumnDefinitions="*,Auto,*"
                            ColumnSpacing="12"
                            Margin="0,2,0,0">
                            <BoxView
                                Color="#E6EAF0"
                                HeightRequest="1"
                                VerticalOptions="Center" />
                            <Label
                                FontSize="12"
                                Grid.Column="1"
                                Text="Или"
                                TextColor="{StaticResource TextSecondary}"
                                VerticalOptions="Center" />
                            <BoxView
                                Color="#E6EAF0"
                                Grid.Column="2"
                                HeightRequest="1"
                                VerticalOptions="Center" />
                        </Grid>

                        <!--  Регистрация (явная, как кнопка)  -->
                        <Button
                            Command="{Binding GoToRegisterCommand}"
                            Style="{StaticResource SecondaryButton}"
                            Text="Создать аккаунт" />

                        <!--  Гость (тоже кликабельная кнопка-линк)  -->
                        <Button
                            Command="{Binding GuestLoginCommand}"
                            HorizontalOptions="Center"
                            Style="{StaticResource TextButton}"
                            Text="Продолжить без регистрации"
                            TextColor="{StaticResource TextSecondary}" />

                    </VerticalStackLayout>
                </Frame>

            </VerticalStackLayout>
        </ScrollView>

    </Grid>
</ContentPage>
```

## File: Pages/Shared/LoginPage.xaml.cs
```csharp
using MedCompatibility.ViewModels.Shared;

namespace MedCompatibility.Pages.Shared;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is LoginViewModel vm)
        {
            // ключ: если вернулись на страницу — мгновенно гасим возможный "зависший" лоадер
            vm.CancelGoogleAuthUiFromPage();

            await vm.OnAppearingAsync();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        if (BindingContext is LoginViewModel vm)
        {
            // на всякий случай: при уходе со страницы тоже не оставляем лоадер висеть
            vm.CancelGoogleAuthUiFromPage();
        }
    }
}
```

## File: Pages/Shared/Popups/AddManufacturerPopup.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<toolkit:Popup xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
               xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
               xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
               x:Class="MedCompatibility.Pages.Shared.Popups.AddManufacturerPopup"
               Color="Transparent"
               CanBeDismissedByTappingOutsideOfPopup="False">

    <Border StrokeShape="RoundRectangle 20"
            BackgroundColor="White" 
            Stroke="{StaticResource Primary}"
            StrokeThickness="1"
            Padding="0" 
            WidthRequest="320" 
            VerticalOptions="Center"
            Shadow="{Shadow Brush=Black, Offset='0,5', Radius=15, Opacity=0.2}">

        <VerticalStackLayout Spacing="0">
            
            <!-- Заголовок -->
            <Label Text="Новый производитель" 
                   FontAttributes="Bold" 
                   FontSize="18" 
                   HorizontalOptions="Center" 
                   TextColor="#1F2937"
                   Padding="20,20,20,10"/>

            <VerticalStackLayout Spacing="12" Padding="20">
                <!-- Название -->
                <Border StrokeShape="RoundRectangle 10" BackgroundColor="#F3F4F6" StrokeThickness="0" HeightRequest="48" Padding="12,0">
                    <Entry x:Name="NameEntry" 
                           Placeholder="Название завода *" 
                           TextChanged="OnTextChanged"
                           PlaceholderColor="#9CA3AF" 
                           TextColor="#1F2937" 
                           FontSize="14"
                           VerticalOptions="Center"/>
                </Border>

                <!-- Страна (ГЛАВНОЕ ИСПРАВЛЕНИЕ: Label + Прозрачный Picker) -->
                <Border StrokeShape="RoundRectangle 10" BackgroundColor="#F3F4F6" StrokeThickness="0" HeightRequest="48" Padding="12,0">
                    <Grid>
                        <!-- 1. Текст, который ВСЕГДА виден -->
                        <Label Text="{Binding Source={x:Reference CountryPicker}, Path=SelectedItem}"
                               TextColor="#1F2937"
                               FontSize="14"
                               VerticalOptions="Center"
                               HorizontalOptions="Start"
                               LineBreakMode="TailTruncation"
                               Margin="0,0,25,0"/>

                        <!-- 2. Иконка стрелочки -->
                        <Label Text="▼" TextColor="#6B7280" FontSize="10" HorizontalOptions="End" VerticalOptions="Center"/>

                        <!-- 3. Невидимый Picker, который ловит нажатия -->
                        <Picker x:Name="CountryPicker" 
                                Title="Выберите страну"
                                Opacity="0"
                                VerticalOptions="Fill" 
                                HorizontalOptions="Fill">
                            <Picker.ItemsSource>
                                <x:Array Type="{x:Type x:String}">
                                    <x:String>Республика Беларусь</x:String>
                                    <x:String>Россия</x:String>
                                    <x:String>Германия</x:String>
                                    <x:String>Индия</x:String>
                                    <x:String>Китай</x:String>
                                </x:Array>
                            </Picker.ItemsSource>
                        </Picker>
                    </Grid>
                </Border>

                <!-- Город -->
                <Border StrokeShape="RoundRectangle 10" BackgroundColor="#F3F4F6" StrokeThickness="0" HeightRequest="48" Padding="12,0">
                    <Entry x:Name="CityEntry" Placeholder="Город" PlaceholderColor="#9CA3AF" TextColor="#1F2937" FontSize="14" VerticalOptions="Center"/>
                </Border>

                <!-- Описание (ИСПРАВЛЕНИЕ: Явный белый фон для редактора) -->
                <Border StrokeShape="RoundRectangle 10" BackgroundColor="#F3F4F6" StrokeThickness="0" HeightRequest="80" Padding="12,8">
                    <Editor x:Name="DescEntry" 
                            Placeholder="Описание (опционально)" 
                            PlaceholderColor="#9CA3AF" 
                            TextColor="#1F2937" 
                            BackgroundColor="Transparent"
                            FontSize="14"
                            AutoSize="TextChanges"/>
                </Border>
            </VerticalStackLayout>

            <!-- Кнопки -->
            <Grid ColumnDefinitions="*, *" ColumnSpacing="12" Padding="20,0,20,20">
                <Button Grid.Column="0"
                        Text="Отмена" 
                        Clicked="OnCancelClicked" 
                        BackgroundColor="White" 
                        TextColor="#4B5563"
                        BorderColor="#D1D5DB"
                        BorderWidth="1"
                        CornerRadius="8"
                        HeightRequest="44"
                        FontSize="14"/>
                
                <Button x:Name="CreateBtn"
                        Grid.Column="1"
                        Text="Создать" 
                        Clicked="OnSaveClicked" 
                        BackgroundColor="{StaticResource Primary}" 
                        TextColor="White"
                        CornerRadius="8"
                        HeightRequest="44"
                        FontSize="14"
                        FontAttributes="Bold"
                        IsEnabled="False" 
                        Opacity="0.5"/>
            </Grid>
        </VerticalStackLayout>
    </Border>
</toolkit:Popup>
```

## File: Pages/Shared/Popups/AddManufacturerPopup.xaml.cs
```csharp
using CommunityToolkit.Maui.Views;
using MedCompatibility.Models;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class AddManufacturerPopup : Popup
{
    public AddManufacturerPopup()
    {
        InitializeComponent();
        CountryPicker.SelectedIndex = 0; // РБ по умолчанию
        
        // Сразу блокируем кнопку при старте
        UpdateCreateButtonState();
    }
    
    // Вызывается при изменении текста названия
    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateCreateButtonState();
    }

    private void UpdateCreateButtonState()
    {
        // Кнопка активна, только если название не пустое
        bool isValid = !string.IsNullOrWhiteSpace(NameEntry.Text);
        
        CreateBtn.IsEnabled = isValid;
        // Визуально показываем доступность (0.5 - бледно, 1.0 - ярко)
        CreateBtn.Opacity = isValid ? 1.0 : 0.5; 
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text)) return;

        var result = new manufacturer
        {
            Name = NameEntry.Text,
            Country = CountryPicker.SelectedItem?.ToString(),
            City = CityEntry.Text,
            Description = DescEntry.Text
        };

        Close(result);
    }

    private void OnCancelClicked(object sender, EventArgs e) => Close(null);
}
```

## File: Pages/Shared/Popups/ApprovalPendingPopup.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<toolkit:Popup
    CanBeDismissedByTappingOutsideOfPopup="True"
    Color="Transparent"
    x:Class="MedCompatibility.Pages.Shared.Popups.ApprovalPendingPopup"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">

    <Border
        BackgroundColor="White"
        HorizontalOptions="Center"
        Padding="20"
        StrokeShape="RoundRectangle 16"
        VerticalOptions="Center"
        WidthRequest="360">

        <VerticalStackLayout Spacing="14">
            <Label
                FontAttributes="Bold"
                FontSize="18"
                Text="Заявка отправлена"
                TextColor="{StaticResource TextPrimary}" />

            <Label
                FontSize="14"
                Text="Аккаунт врача создан и ожидает подтверждения администратором. Попробуйте войти позже."
                TextColor="{StaticResource TextSecondary}" />

            <Button
                Clicked="OnOkClicked"
                Style="{StaticResource PrimaryButton}"
                Text="Понятно" />
        </VerticalStackLayout>

    </Border>
</toolkit:Popup>
```

## File: Pages/Shared/Popups/ApprovalPendingPopup.xaml.cs
```csharp
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
```

## File: Pages/Shared/Popups/ChooseRolePopup.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<toolkit:Popup
    CanBeDismissedByTappingOutsideOfPopup="True"
    Color="Transparent"
    x:Class="MedCompatibility.Pages.Shared.Popups.ChooseRolePopup"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">

    <Border
        BackgroundColor="White"
        HorizontalOptions="Center"
        Padding="20"
        StrokeShape="RoundRectangle 16"
        VerticalOptions="Center"
        WidthRequest="360">

        <VerticalStackLayout Spacing="14">
            <Label
                FontAttributes="Bold"
                FontSize="18"
                Text="Выберите роль"
                TextColor="{StaticResource TextPrimary}" />

            <Label
                FontSize="14"
                Text="Это нужно один раз, чтобы открыть нужные разделы приложения."
                TextColor="{StaticResource TextSecondary}" />

            <!--  Основные действия  -->
            <Button
                Clicked="OnPatientClicked"
                Style="{StaticResource PrimaryButton}"
                Text="Пациент" />

            <Button
                Clicked="OnDoctorClicked"
                Style="{StaticResource SecondaryButton}"
                Text="Врач" />

            <!--  Отмена  -->
            <Button
                Clicked="OnCancelClicked"
                Style="{StaticResource TextButton}"
                Text="Отмена" />
        </VerticalStackLayout>

    </Border>
</toolkit:Popup>
```

## File: Pages/Shared/Popups/ChooseRolePopup.xaml.cs
```csharp
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
```

## File: Pages/Shared/Popups/ConfirmPopup.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<toolkit:Popup xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
               xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
               xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
               x:Class="MedCompatibility.Pages.Shared.Popups.ConfirmPopup"
               Color="Transparent">

    <Border StrokeShape="RoundRectangle 16"
            BackgroundColor="White"
            Padding="20"
            HorizontalOptions="Center"
            VerticalOptions="Center"
            WidthRequest="360">

        <VerticalStackLayout Spacing="14">
            <Label Text="{Binding TitleText}"
                   FontSize="18"
                   FontAttributes="Bold"
                   TextColor="{StaticResource TextPrimary}" />

            <Label Text="{Binding MessageText}"
                   FontSize="14"
                   TextColor="{StaticResource TextSecondary}" />

            <Grid ColumnDefinitions="*,*" ColumnSpacing="12" Margin="0,6,0,0">
                <Button Grid.Column="0"
                        Text="{Binding CancelText}"
                        Clicked="OnCancelClicked"
                        Style="{StaticResource SecondaryButton}" />

                <Button Grid.Column="1"
                        Text="{Binding OkText}"
                        Clicked="OnOkClicked"
                        Style="{StaticResource PrimaryButton}" />
            </Grid>
        </VerticalStackLayout>
    </Border>
</toolkit:Popup>
```

## File: Pages/Shared/Popups/ConfirmPopup.xaml.cs
```csharp
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class ConfirmPopup : Popup
{
    public ConfirmPopup(string title, string message, string okText = "OK", string cancelText = "Отмена")
    {
        InitializeComponent();
        BindingContext = new Vm(title, message, okText, cancelText);
    }

    private void OnOkClicked(object sender, EventArgs e) => Close(true);
    private void OnCancelClicked(object sender, EventArgs e) => Close(false);

    private partial class Vm : ObservableObject
    {
        public Vm(string title, string message, string okText, string cancelText)
        {
            TitleText = title;
            MessageText = message;
            OkText = okText;
            CancelText = cancelText;
        }

        public string TitleText { get; }
        public string MessageText { get; }
        public string OkText { get; }
        public string CancelText { get; }
    }
}
```

## File: Pages/Shared/Popups/DbUnavailablePopup.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<toolkit:Popup
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:toolkit="clr-namespace:CommunityToolkit.Maui.Views;assembly=CommunityToolkit.Maui"
    x:Class="MedCompatibility.Pages.Shared.Popups.DbUnavailablePopup"
    CanBeDismissedByTappingOutsideOfPopup="True"
    Color="#80000000"> <!-- Полупрозрачный фон на весь экран (штатный) -->

    <!-- Сама карточка по центру -->
    <Border StrokeShape="RoundRectangle 16"
            BackgroundColor="White"
            WidthRequest="400"
            Padding="24"
            HorizontalOptions="Center"
            VerticalOptions="Center">
        
        <Grid RowDefinitions="Auto, Auto, Auto, Auto" RowSpacing="16">
            
            <!-- 1. Заголовок -->
            <Label Grid.Row="0"
                   Text="Ошибка подключения"
                   TextColor="#2C3E50"
                   FontSize="18"
                   FontAttributes="Bold"
                   HorizontalOptions="Center"/>

            <!-- 2. Короткое сообщение -->
            <Label Grid.Row="1"
                   Text="{Binding ShortMessage}"
                   TextColor="#546E7A"
                   FontSize="14"
                   HorizontalTextAlignment="Center"
                   HorizontalOptions="Center" />

            <!-- 3. Лог ошибки (в сером блоке) -->
            <Border Grid.Row="2"
                    BackgroundColor="#F5F7FA"
                    StrokeThickness="0"
                    StrokeShape="RoundRectangle 8"
                    Padding="12"
                    HeightRequest="140">
                 <ScrollView VerticalScrollBarVisibility="Default">
                     <Label Text="{Binding Details}"
                            FontSize="11"
                            FontFamily="Consolas"
                            TextColor="#455A64"
                            LineBreakMode="CharacterWrap"/>
                 </ScrollView>
            </Border>

            <!-- 4. Кнопки (равномерно) -->
            <Grid Grid.Row="3" ColumnDefinitions="*,*" ColumnSpacing="12">
                <Button Grid.Column="0"
                        Text="Скопировать"
                        Style="{StaticResource SecondaryButton}"
                        Command="{Binding CopyCommand}"/>
                
                <Button Grid.Column="1"
                        Text="Закрыть"
                        Style="{StaticResource PrimaryButton}"
                        Command="{Binding CloseCommand}"/>
            </Grid>
        </Grid>
    </Border>
</toolkit:Popup>
```

## File: Pages/Shared/Popups/DbUnavailablePopup.xaml.cs
```csharp
using CommunityToolkit.Maui.Views;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class DbUnavailablePopup : Popup
{
    public DbUnavailablePopup(string shortMessage, string details)
    {
        InitializeComponent();
        BindingContext = new Vm(this, shortMessage, details);
    }

    private sealed class Vm
    {
        private readonly Popup _popup;

        public string ShortMessage { get; }
        public string Details { get; }

        public Command CloseCommand => new(() => _popup.Close());
        public Command CopyCommand => new(async () => await Clipboard.SetTextAsync(Details));

        public Vm(Popup popup, string shortMessage, string details)
        {
            _popup = popup;
            ShortMessage = shortMessage;
            Details = details;
        }
    }
}
```

## File: Pages/Shared/Popups/LoadingPopup.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<toolkit:Popup
    CanBeDismissedByTappingOutsideOfPopup="False"
    Color="Transparent"
    x:Class="MedCompatibility.Pages.Shared.Popups.LoadingPopup"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">
    <!--
        ВАЖНО: Color="Transparent" в самом Popup.
        Системное затемнение (dimmed background) MAUI добавляет автоматически.
        Если мы тут зададим Серый, он может перекрыть контент.
    -->

    <!--  Контейнер самого окошка (Плашка)  -->
    <Border
        BackgroundColor="{AppThemeBinding Light=White,
                                          Dark=#333333}"
        HorizontalOptions="Center"
        Padding="30"
        StrokeShape="RoundRectangle 15"
        StrokeThickness="0"
        VerticalOptions="Center">

        <VerticalStackLayout
            HorizontalOptions="Center"
            Spacing="15"
            VerticalOptions="Center">

            <!--  Крутилка  -->
            <ActivityIndicator
                Color="{StaticResource Primary}"
                HeightRequest="50"
                HorizontalOptions="Center"
                IsRunning="True"
                WidthRequest="50" />

            <!--  Текст (опционально)  -->
            <Label
                FontSize="14"
                HorizontalOptions="Center"
                HorizontalTextAlignment="Center"
                Text="Пожалуйста, подождите..."
                TextColor="{AppThemeBinding Light=Black,
                                            Dark=White}" />

        </VerticalStackLayout>
    </Border>

</toolkit:Popup>
```

## File: Pages/Shared/Popups/LoadingPopup.xaml.cs
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class LoadingPopup : Popup
{
    public LoadingPopup()
    {
        InitializeComponent();
    }
}
```

## File: Pages/Shared/Popups/MedicineSelectionPopup.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<toolkit:Popup xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
               xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
               xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
               xmlns:models="clr-namespace:MedCompatibility.Models"
               x:Class="MedCompatibility.Pages.Shared.Popups.MedicineSelectionPopup"
               Color="Transparent"
               CanBeDismissedByTappingOutsideOfPopup="True">

    <Border StrokeShape="RoundRectangle 20" 
            BackgroundColor="{StaticResource Surface}"
            WidthRequest="320"
            HeightRequest="500"
            Padding="20">
        
        <Grid RowDefinitions="Auto, Auto, Auto, *">
            
            <!-- Заголовок -->
            <Label Grid.Row="0" Text="Выбор лекарства" 
                   FontSize="18" FontAttributes="Bold" 
                   HorizontalOptions="Center" Margin="0,0,0,15"
                   TextColor="{StaticResource TextPrimary}"/>

            <!-- Быстрые действия -->
            <Grid Grid.Row="1" ColumnDefinitions="*, *" ColumnSpacing="10" Margin="0,0,0,15">
                <!-- Кнопка Сканер -->
                <Border StrokeShape="RoundRectangle 10" BackgroundColor="{StaticResource Primary}" HeightRequest="40">
                    <Border.GestureRecognizers>
                        <TapGestureRecognizer Tapped="OnScanClicked"/>
                    </Border.GestureRecognizers>
                    <Label Text="📷 Сканер" TextColor="White" VerticalOptions="Center" HorizontalOptions="Center"/>
                </Border>

                <!-- Кнопка История -->
                <Border StrokeShape="RoundRectangle 10" BackgroundColor="{StaticResource Secondary}" HeightRequest="40">
                    <Border.GestureRecognizers>
                        <TapGestureRecognizer Tapped="OnHistoryClicked"/>
                    </Border.GestureRecognizers>
                    <Label Text="📜 История" TextColor="White" VerticalOptions="Center" HorizontalOptions="Center"/>
                </Border>
            </Grid>

            <!-- Поиск -->
            <Border Grid.Row="2" StrokeShape="RoundRectangle 10" Stroke="{StaticResource TextSecondary}" StrokeThickness="1" HeightRequest="45" Margin="0,0,0,10">
                <Grid ColumnDefinitions="*, Auto">
                    <Entry x:Name="SearchEntry" Placeholder="Название или штрихкод..." 
                           TextColor="{StaticResource TextPrimary}"
                           VerticalOptions="Center" Margin="10,0"
                           TextChanged="OnSearchTextChanged"/>
                    <ActivityIndicator x:Name="SearchLoader" IsRunning="False" Color="{StaticResource Primary}" Grid.Column="1" Margin="0,0,10,0"/>
                </Grid>
            </Border>

            <!-- Список результатов -->
            <CollectionView Grid.Row="3" x:Name="MedicinesList" SelectionMode="Single" SelectionChanged="OnSelectionChanged">
                <CollectionView.EmptyView>
                    <Label Text="Начните ввод для поиска..." 
                           HorizontalOptions="Center" VerticalOptions="Center" 
                           TextColor="{StaticResource TextSecondary}"/>
                </CollectionView.EmptyView>
                <CollectionView.ItemTemplate>
                    <DataTemplate x:DataType="models:medicine">
                        <Border StrokeShape="RoundRectangle 10" BackgroundColor="White" Margin="0,5" Padding="10">
                            <VerticalStackLayout>
                                <Label Text="{Binding TradeName}" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}"/>
                                <Label Text="{Binding Manufacturer.Name}" FontSize="12" TextColor="{StaticResource TextSecondary}"/>
                                <Label Text="{Binding GTIN}" FontSize="10" TextColor="{StaticResource TextSecondary}"/>
                            </VerticalStackLayout>
                        </Border>
                    </DataTemplate>
                </CollectionView.ItemTemplate>
            </CollectionView>

            <!-- Кнопка Закрыть (крестик в углу) -->
            <ImageButton Grid.Row="0" Source="dotnet_bot.png" IsVisible="false"/> <!-- Заглушка, можно добавить крестик -->
        </Grid>
    </Border>
</toolkit:Popup>
```

## File: Pages/Shared/Popups/MedicineSelectionPopup.xaml.cs
```csharp
using CommunityToolkit.Maui.Views;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.Maui.Controls;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class MedicineSelectionPopup : Popup
{
    private readonly IMedicineService _medicineService;
    private readonly IScanService _scanService;

    // Результат, который вернем: 
    // Либо объект medicine (если выбрали), 
    // Либо string "SCAN" (если нажали сканер)
    public MedicineSelectionPopup(IMedicineService medicineService, IScanService scanService)
    {
        InitializeComponent();
        _medicineService = medicineService;
        _scanService = scanService;
    }

    private void OnScanClicked(object sender, EventArgs e)
    {
        Close("SCAN"); // Возвращаем спец-сигнал, что нужно открыть сканер
    }

    private async void OnHistoryClicked(object sender, EventArgs e)
    {
        SearchLoader.IsRunning = true;
        try
        {
            var history = await _scanService.GetUserHistoryAsync();
            var uniqueMeds = history.Select(h => h.Medicine).DistinctBy(m => m.MedicineId).ToList();
            
            if (!uniqueMeds.Any())
            {
                 // Если истории нет - просто покажем пустоту или алерт (но в попапе алерт сложно)
                 MedicinesList.ItemsSource = new List<medicine>();
            }
            else
            {
                MedicinesList.ItemsSource = uniqueMeds;
            }
        }
        finally
        {
            SearchLoader.IsRunning = false;
        }
    }

    private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var query = e.NewTextValue;
        if (string.IsNullOrWhiteSpace(query) || query.Length < 2) 
        {
            MedicinesList.ItemsSource = null;
            return;
        }

        SearchLoader.IsRunning = true;
        try
        {
            // Небольшая задержка (debounce), чтобы не бомбить базу на каждой букве
            await Task.Delay(300); 
            if (SearchEntry.Text != query) return; // Если текст уже изменился, отменяем старый запрос

            var results = await _medicineService.SearchMedicinesAsync(query);
            MedicinesList.ItemsSource = results;
        }
        catch
        {
            // Игнорируем ошибки поиска
        }
        finally
        {
            SearchLoader.IsRunning = false;
        }
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is medicine selected)
        {
            Close(selected); // Возвращаем выбранное лекарство
        }
    }
}
```

## File: Pages/Shared/Popups/PatientBlockedPopup.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<toolkit:Popup
    Color="Transparent"
    x:Class="MedCompatibility.Pages.Shared.Popups.PatientBlockedPopup"
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">

    <Border
        BackgroundColor="White"
        HorizontalOptions="Center"
        Padding="20"
        StrokeShape="RoundRectangle 16"
        VerticalOptions="Center"
        WidthRequest="360">

        <VerticalStackLayout Spacing="14">
            <Label
                FontAttributes="Bold"
                FontSize="18"
                Text="Доступ ограничен"
                TextColor="{StaticResource TextPrimary}" />

            <Label
                FontSize="14"
                Text="Ваш аккаунт пациента заблокирован администратором. Обратитесь в поддержку или к администратору для разблокировки."
                TextColor="{StaticResource TextSecondary}" />

            <Button
                Clicked="OnOkClicked"
                Style="{StaticResource PrimaryButton}"
                Text="OK" />
        </VerticalStackLayout>
    </Border>
</toolkit:Popup>
```

## File: Pages/Shared/Popups/PatientBlockedPopup.xaml.cs
```csharp
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
```

## File: Pages/Shared/Popups/PatientSearchPopup.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<toolkit:Popup xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
               xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
               xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
               xmlns:models="clr-namespace:MedCompatibility.Models"
               x:Class="MedCompatibility.Pages.Shared.Popups.PatientSearchPopup"
               Color="Transparent"
               HorizontalOptions="Center"
               VerticalOptions="Center"
               CanBeDismissedByTappingOutsideOfPopup="True"
               Opened="OnPopupOpened">

    <Border StrokeShape="RoundRectangle 20"
            BackgroundColor="White"
            WidthRequest="350"
            HeightRequest="500"
            StrokeThickness="0"
            Padding="20">

        <Grid RowDefinitions="Auto, Auto, Auto, *, Auto" RowSpacing="12">

            <Label Grid.Row="0"
                   Text="Добавить пациента"
                   FontSize="20"
                   FontAttributes="Bold"
                   TextColor="Black"/>

            <SearchBar Grid.Row="1"
                       x:Name="SearchInput"
                       Placeholder="Фамилия или логин..."
                       TextChanged="OnSearchTextChanged"
                       BackgroundColor="#F0F0F0"/>

            <ActivityIndicator Grid.Row="2"
                               x:Name="Loader"
                               IsVisible="False"
                               IsRunning="False"
                               Color="#2563EB"
                               HeightRequest="24"/>

            <!-- ВАЖНО: CollectionView сам скроллится, ScrollView тут не нужен -->
            <CollectionView Grid.Row="3"
                            x:Name="ResultsList"
                            SelectionMode="Single"
                            SelectionChanged="OnSelectionChanged">
                <CollectionView.EmptyView>
                    <Label Text="Пациенты не найдены"
                           TextColor="#999"
                           HorizontalOptions="Center"
                           VerticalOptions="Center"/>
                </CollectionView.EmptyView>

                <CollectionView.ItemTemplate>
                    <DataTemplate x:DataType="models:user">
                        <Border Padding="12"
                                Margin="0,0,0,8"
                                BackgroundColor="#F5F5F5"
                                StrokeShape="RoundRectangle 10"
                                StrokeThickness="0">
                            <VerticalStackLayout Spacing="2">
                                <Label Text="{Binding LastName}"
                                       FontAttributes="Bold"
                                       FontSize="16"
                                       TextColor="Black"/>
                                <Label Text="{Binding FirstName}"
                                       FontSize="14"
                                       TextColor="Gray"/>
                                <Label Text="{Binding Login, StringFormat='@{0}'}"
                                       FontSize="12"
                                       TextColor="Gray"/>
                            </VerticalStackLayout>
                        </Border>
                    </DataTemplate>
                </CollectionView.ItemTemplate>
            </CollectionView>

            <Button Grid.Row="4"
                    Text="Закрыть"
                    Clicked="OnCloseClicked"
                    BackgroundColor="#E0E0E0"
                    TextColor="Black"/>
        </Grid>
    </Border>
</toolkit:Popup>
```

## File: Pages/Shared/Popups/PatientSearchPopup.xaml.cs
```csharp
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class PatientSearchPopup : Popup
{
    private readonly IUserService _userService;
    private readonly IUserSessionService _sessionService;

    public PatientSearchPopup(IUserService userService, IUserSessionService sessionService)
    {
        InitializeComponent();
        _userService = userService;
        _sessionService = sessionService;
    }

    private async void OnPopupOpened(object? sender, PopupOpenedEventArgs e)
    {
        await LoadPatientsAsync("");
    }

    private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        await LoadPatientsAsync(e.NewTextValue ?? "");
    }

    private async Task LoadPatientsAsync(string query)
    {
        try
        {
            var doctor = _sessionService.CurrentUser;
            if (doctor == null) return;

            SetLoading(true);

            var patients = await _userService.SearchNewPatientsAsync(query, doctor.UserId);

            // ItemsSource лучше обновлять на UI-потоке. [web:29]
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                ResultsList.ItemsSource = patients;
            });
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Ошибка поиска: {ex.Message}");
        }
        finally
        {
            SetLoading(false);
        }
    }

    private void SetLoading(bool isLoading)
    {
        Loader.IsVisible = isLoading;
        Loader.IsRunning = isLoading;
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is user selectedPatient)
            Close(selectedPatient);
    }

    private void OnCloseClicked(object sender, EventArgs e) => Close(null);
}
```

## File: Pages/Shared/Popups/SelectSubstancePopup.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<toolkit:Popup xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
               xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
               xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolkit"
               xmlns:models="clr-namespace:MedCompatibility.Models"
               x:Class="MedCompatibility.Pages.Shared.Popups.SelectSubstancePopup"
               Color="Transparent"
               CanBeDismissedByTappingOutsideOfPopup="True">

    <Border StrokeShape="RoundRectangle 20" 
            BackgroundColor="{StaticResource Surface}" 
            Stroke="{StaticResource Primary}"
            StrokeThickness="1"
            Padding="20" 
            WidthRequest="340" 
            VerticalOptions="Start" Margin="0,60,0,0"
            Shadow="{Shadow Brush={StaticResource Primary}, Offset='0,4', Radius=10, Opacity=0.2}">
        
        <VerticalStackLayout Spacing="10">
            <Label Text="Выбор вещества" FontAttributes="Bold" FontSize="16" TextColor="{StaticResource TextPrimary}" HorizontalOptions="Center"/>
            
            <!-- Поле поиска -->
            <Border StrokeShape="RoundRectangle 10" BackgroundColor="{StaticResource AppBackground}" StrokeThickness="0" HeightRequest="44" Padding="10,0">
                <Grid ColumnDefinitions="*, Auto">
                    <Entry x:Name="SearchEntry" 
                           Placeholder="Начните вводить..." 
                           TextChanged="OnSearchTextChanged" 
                           TextColor="{StaticResource TextPrimary}"
                           PlaceholderColor="{StaticResource TextSecondary}"
                           VerticalOptions="Center"/>
                    <!-- Кнопка очистки (свой крестик) -->
                    <Button Grid.Column="1" Text="✕" BackgroundColor="Transparent" TextColor="{StaticResource TextSecondary}" 
                            Clicked="OnClearSearchClicked" HeightRequest="40" WidthRequest="40" Padding="0"/>
                </Grid>
            </Border>

            <!-- Лоадер -->
            <ActivityIndicator x:Name="LoadingIndicator" IsRunning="True" Color="{StaticResource Primary}" HeightRequest="20" IsVisible="False"/>

            <!-- Список существующих веществ -->
            <!-- Важно: HeightRequest ограничен, чтобы список скроллился внутри попапа -->
            <CollectionView x:Name="ResultsList" HeightRequest="180" SelectionMode="Single" SelectionChanged="OnSubstanceSelected" IsVisible="False">
                <CollectionView.ItemsLayout>
                    <LinearItemsLayout Orientation="Vertical" ItemSpacing="4"/>
                </CollectionView.ItemsLayout>
                <CollectionView.ItemTemplate>
                    <DataTemplate x:DataType="models:activesubstance">
                        <Border StrokeShape="RoundRectangle 8" BackgroundColor="Transparent" StrokeThickness="0" Padding="10">
                            <Label Text="{Binding Name}" TextColor="{StaticResource TextPrimary}" FontSize="14"/>
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualState x:Name="Normal" />
                                    <VisualState x:Name="Selected">
                                        <VisualState.Setters>
                                            <Setter Property="BackgroundColor" Value="#E0F7FA" /> <!-- Подсветка при нажатии -->
                                        </VisualState.Setters>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                        </Border>
                    </DataTemplate>
                </CollectionView.ItemTemplate>
            </CollectionView>

            <!-- Динамический блок создания -->
            <VerticalStackLayout x:Name="CreateBlock" IsVisible="False" Spacing="8">
                <BoxView HeightRequest="1" Color="{StaticResource Primary}" Opacity="0.3" Margin="0,5"/>
                <Label Text="Не найдено. Создать новое?" FontSize="12" TextColor="{StaticResource Secondary}" HorizontalOptions="Center"/>
                
                <!-- Название (копия из поиска) -->
                <Label Text="{Binding Source={x:Reference NewNameEntry}, Path=Text}" FontAttributes="Bold" TextColor="{StaticResource TextPrimary}" HorizontalOptions="Center" FontSize="16"/>
                <Entry x:Name="NewNameEntry" IsVisible="False"/> 

                <!-- Описание (Исправляем черный фон) -->
                <Border StrokeShape="RoundRectangle 8" BackgroundColor="{StaticResource AppBackground}" StrokeThickness="0" HeightRequest="80" Padding="10">
                     <Editor x:Name="NewDescEntry" 
                             Placeholder="Описание (необязательно)" 
                             TextColor="{StaticResource TextPrimary}" 
                             PlaceholderColor="{StaticResource TextSecondary}"
                             BackgroundColor="Transparent"
                             AutoSize="TextChanges"/>
                </Border>

                <Button Text="Сохранить и выбрать" Clicked="OnCreateClicked" Style="{StaticResource PrimaryButton}" CornerRadius="10" HeightRequest="44"/>
            </VerticalStackLayout>
            
            <Button Text="Отмена" Clicked="OnCancelClicked" BackgroundColor="Transparent" TextColor="{StaticResource TextSecondary}" FontSize="14" HeightRequest="36" Margin="0,10,0,0"/>
        </VerticalStackLayout>
    </Border>
</toolkit:Popup>
```

## File: Pages/Shared/Popups/SelectSubstancePopup.xaml.cs
```csharp
using CommunityToolkit.Maui.Views;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using System.Collections.ObjectModel;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class SelectSubstancePopup : Popup
{
    private readonly IMedicineService _service;
    private List<activesubstance> _allCachedSubstances = new(); // Кеш всех веществ

    public SelectSubstancePopup(IMedicineService service)
    {
        InitializeComponent();
        _service = service;
        
        // Запускаем загрузку
        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        try
        {
            LoadingIndicator.IsVisible = true;
            ResultsList.IsVisible = false;
            CreateBlock.IsVisible = false;

            // Грузим ВСЕ вещества сразу при открытии.
            // Передаем null или "" - сервис должен вернуть всё.
            // Если сервис SearchSubstancesAsync("") не возвращает всё, нужно это проверить в MedicineService.cs
            _allCachedSubstances = await _service.SearchSubstancesAsync("") ?? new List<activesubstance>();
            
            // Сразу показываем список
            UpdateList(_allCachedSubstances);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error loading substances: {ex}");
        }
        finally
        {
            LoadingIndicator.IsVisible = false;
        }
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string query = e.NewTextValue?.Trim() ?? "";
        FilterData(query);
    }
    
    private void OnClearSearchClicked(object sender, EventArgs e)
    {
        SearchEntry.Text = string.Empty;
    }

    private void FilterData(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            // Показываем полный список
            UpdateList(_allCachedSubstances);
            CreateBlock.IsVisible = false;
            return;
        }

        // Фильтруем локально (в памяти), так быстрее и надежнее для небольших списков
        var filtered = _allCachedSubstances
            .Where(s => s.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToList();

        UpdateList(filtered);

        // Проверяем точное совпадение
        bool exactMatch = filtered.Any(s => s.Name.Equals(query, StringComparison.OrdinalIgnoreCase));

        // Показываем блок создания, если нет точного совпадения
        CreateBlock.IsVisible = !exactMatch;
        
        if (!exactMatch)
        {
            NewNameEntry.Text = query; 
        }
    }

    private void UpdateList(List<activesubstance> items)
    {
        ResultsList.ItemsSource = items;
        // Показываем список, только если в нем что-то есть
        ResultsList.IsVisible = items.Count > 0;
    }

    private void OnSubstanceSelected(object sender, SelectionChangedEventArgs e)
    {
        var selected = e.CurrentSelection.FirstOrDefault() as activesubstance;
        if (selected != null)
        {
            Close(selected);
        }
    }

    private async void OnCreateClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NewNameEntry.Text)) return;

        try
        {
            var newSub = await _service.CreateSubstanceAsync(NewNameEntry.Text, NewDescEntry.Text);
            
            // Обновляем кеш, чтобы при следующем открытии оно там было (хотя Popup пересоздается)
            _allCachedSubstances.Add(newSub); 
            
            Close(newSub);
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Ошибка", ex.Message, "OK");
        }
    }

    private void OnCancelClicked(object sender, EventArgs e) => Close(null);
}
```

## File: Pages/Shared/RegisterPage.xaml
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vm="clr-namespace:MedCompatibility.ViewModels.Shared"
             x:Class="MedCompatibility.Pages.Shared.RegisterPage"
             Shell.NavBarIsVisible="False">

    <ScrollView VerticalScrollBarVisibility="Never">
        <Grid RowDefinitions="*" Padding="20">
            
            <VerticalStackLayout Spacing="25" 
                                 VerticalOptions="Center" 
                                 HorizontalOptions="Center">

                <!-- Заголовок -->
                <VerticalStackLayout Spacing="5" HorizontalOptions="Center">
                    <Label Text="Новый аккаунт" 
                           Style="{StaticResource HeaderLabel}" 
                           HorizontalTextAlignment="Center"/>
                    <Label Text="Заполните данные пациента" 
                           Style="{StaticResource SubHeaderLabel}" 
                           HorizontalTextAlignment="Center"/>
                </VerticalStackLayout>

                <!-- Карточка регистрации -->
                <Frame Style="{StaticResource CardFrame}" WidthRequest="380">
                    <VerticalStackLayout Spacing="15">

                        <!-- Блок ФИО -->
                        <VerticalStackLayout Spacing="10">
                            
                            <!-- Фамилия (на всю ширину) -->
                            <VerticalStackLayout Spacing="6">
                                <Label Text="Фамилия" TextColor="{StaticResource TextPrimary}" FontSize="13" FontAttributes="Bold"/>
                                <Border Style="{StaticResource InputFrame}">
                                    <Entry Text="{Binding LastName}" Placeholder="Иванов"/>
                                </Border>
                            </VerticalStackLayout>

                            <!-- Имя и Отчество (в один ряд) -->
                            <Grid ColumnDefinitions="*,*" ColumnSpacing="10">
                                <VerticalStackLayout Spacing="6" Grid.Column="0">
                                    <Label Text="Имя" TextColor="{StaticResource TextPrimary}" FontSize="13" FontAttributes="Bold"/>
                                    <Border Style="{StaticResource InputFrame}">
                                        <Entry Text="{Binding FirstName}" Placeholder="Иван"/>
                                    </Border>
                                </VerticalStackLayout>

                                <VerticalStackLayout Spacing="6" Grid.Column="1">
                                    <Label Text="Отчество" TextColor="{StaticResource TextPrimary}" FontSize="13" FontAttributes="Bold"/>
                                    <Border Style="{StaticResource InputFrame}">
                                        <Entry Text="{Binding MiddleName}" Placeholder="Иванович"/>
                                    </Border>
                                </VerticalStackLayout>
                            </Grid>
                            
                        </VerticalStackLayout>

                        <!-- Логин -->
                        <VerticalStackLayout Spacing="6">
                            <Label Text="Логин" TextColor="{StaticResource TextPrimary}" FontSize="13" FontAttributes="Bold"/>
                            <Border Style="{StaticResource InputFrame}">
                                <Entry Text="{Binding Login}" Placeholder="Придумайте логин"/>
                            </Border>
                        </VerticalStackLayout>

                        <!-- Пароль -->
                        <VerticalStackLayout Spacing="6">
                            <Label Text="Пароль" TextColor="{StaticResource TextPrimary}" FontSize="13" FontAttributes="Bold"/>
                            <Border Style="{StaticResource InputFrame}">
                                <Entry Text="{Binding Password}" IsPassword="True" Placeholder="Минимум 6 символов"/>
                            </Border>
                        </VerticalStackLayout>
                        
                        <!-- Подтверждение пароля -->
                        <VerticalStackLayout Spacing="6">
                            <Label Text="Повторите пароль" TextColor="{StaticResource TextPrimary}" FontSize="13" FontAttributes="Bold"/>
                            <Border Style="{StaticResource InputFrame}">
                                <Entry Text="{Binding ConfirmPassword}" IsPassword="True" Placeholder="Пароль ещё раз"/>
                            </Border>
                        </VerticalStackLayout>
                        <!-- Выбор роли -->
                        <VerticalStackLayout Spacing="6">
                            <Label Text="Тип аккаунта" TextColor="{StaticResource TextPrimary}" FontSize="13" FontAttributes="Bold"/>
                            
                            <!-- Рамка, идентичная Entry -->
                            <Border Style="{StaticResource InputFrame}">
                                <Picker  
                                        ItemsSource="{Binding AvailableRoles}" 
                                        SelectedItem="{Binding SelectedRole}"
                                        TextColor="{StaticResource TextPrimary}"
                                        TitleColor="{StaticResource TextSecondary}"
                                        BackgroundColor="Transparent"
                                        Margin="0"
                                        HorizontalOptions="FillAndExpand"/>
                            </Border>
                            
                            <!-- Инфо-сообщение (появляется при выборе Врача) -->
                            <Border BackgroundColor="#E3F2FD" StrokeThickness="0" StrokeShape="RoundRectangle 8" Padding="10" Margin="0,5,0,0">
                                <Border.Triggers>
                                    <DataTrigger TargetType="Border" Binding="{Binding SelectedRole}" Value="Врач">
                                        <Setter Property="IsVisible" Value="True"/>
                                    </DataTrigger>
                                    <!-- Скрыто для Пациента и когда ничего не выбрано -->
                                    <DataTrigger TargetType="Border" Binding="{Binding SelectedRole}" Value="Пациент">
                                        <Setter Property="IsVisible" Value="False"/>
                                    </DataTrigger>
                                    <DataTrigger TargetType="Border" Binding="{Binding SelectedRole}" Value="{x:Null}">
                                        <Setter Property="IsVisible" Value="False"/>
                                    </DataTrigger>
                                </Border.Triggers>

                                <Label Text="⚠️ Аккаунт врача требует подтверждения администратора" 
                                       TextColor="{StaticResource Primary}" 
                                       FontSize="11"/>
                            </Border>
                        </VerticalStackLayout>

                        <!-- Ошибка -->
                        <Label Text="{Binding ErrorMessage}" 
                               TextColor="{StaticResource Error}" 
                               IsVisible="{Binding IsErrorVisible}" 
                               FontSize="13"
                               HorizontalTextAlignment="Center"/>

                        <!-- Кнопка Регистрации -->
                        <Button Text="Зарегистрироваться" 
                                Command="{Binding RegisterCommand}" 
                                Style="{StaticResource PrimaryButton}" 
                                Margin="0,10,0,0"/>

                    </VerticalStackLayout>
                </Frame>

                <!-- Кнопка Назад -->
                <Button Text="У меня уже есть аккаунт" 
                        Command="{Binding GoBackCommand}" 
                        Style="{StaticResource TextButton}"
                        HorizontalOptions="Center"/>

            </VerticalStackLayout>
        </Grid>
    </ScrollView>
</ContentPage>
```

## File: Pages/Shared/RegisterPage.xaml.cs
```csharp
using MedCompatibility.ViewModels.Shared;

namespace MedCompatibility.Pages.Shared;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
```

## File: Platforms/Android/AndroidManifest.xml
```xml
<?xml version="1.0" encoding="utf-8"?>
<manifest xmlns:android="http://schemas.android.com/apk/res/android">
	<application android:allowBackup="true" android:icon="@mipmap/appicon" android:roundIcon="@mipmap/appicon_round" android:supportsRtl="true" android:usesCleartextTraffic="true"></application>
	<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
	<uses-permission android:name="android.permission.INTERNET" />
	<uses-permission android:name="android.permission.CAMERA" />
</manifest>
```

## File: Platforms/Android/MainActivity.cs
```csharp
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MedCompatibility;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                           ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
}
```

## File: Platforms/Android/MainApplication.cs
```csharp
using Android.App;
using Android.Runtime;

namespace MedCompatibility;

[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
```

## File: Platforms/Android/MedCompatAuthCallbackActivity.cs
```csharp
using Android.App;
using Android.Content;
using Android.Content.PM;
using Microsoft.Maui.Authentication;

namespace MedCompatibility;

[Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
[IntentFilter(
    new[] { Intent.ActionView },
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataScheme = "com.googleusercontent.apps.285954249476-6ofmkkjb4m6n8qs6bdd4chht713n4hd8"
)]
public class MedCompatAuthCallbackActivity : WebAuthenticatorCallbackActivity { }
```

## File: Platforms/Android/Resources/values/colors.xml
```xml
<?xml version="1.0" encoding="utf-8"?>
<resources>
    <color name="colorPrimary">#512BD4</color>
    <color name="colorPrimaryDark">#2B0B98</color>
    <color name="colorAccent">#2B0B98</color>
</resources>
```

## File: Platforms/Windows/app.manifest
```
<?xml version="1.0" encoding="utf-8"?>
<assembly manifestVersion="1.0" xmlns="urn:schemas-microsoft-com:asm.v1">
  <assemblyIdentity version="1.0.0.0" name="MedCompatibility.WinUI.app"/>

  <application xmlns="urn:schemas-microsoft-com:asm.v3">
    <windowsSettings>
      <!-- The combination of below two tags have the following effect:
           1) Per-Monitor for >= Windows 10 Anniversary Update
           2) System < Windows 10 Anniversary Update
      -->
      <dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">true/PM</dpiAware>
      <dpiAwareness xmlns="http://schemas.microsoft.com/SMI/2016/WindowsSettings">PerMonitorV2, PerMonitor</dpiAwareness>
    </windowsSettings>
  </application>
</assembly>
```

## File: Platforms/Windows/App.xaml
```
<maui:MauiWinUIApplication
    x:Class="MedCompatibility.WinUI.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:maui="using:Microsoft.Maui"
    xmlns:local="using:MedCompatibility.WinUI">

</maui:MauiWinUIApplication>
```

## File: Platforms/Windows/App.xaml.cs
```csharp
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MedCompatibility.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication
{
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
```

## File: Platforms/Windows/Package.appxmanifest
```
<?xml version="1.0" encoding="utf-8"?>
<Package
  xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:mp="http://schemas.microsoft.com/appx/2014/phone/manifest"
  xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
  IgnorableNamespaces="uap rescap">

  <Identity Name="maui-package-name-placeholder" Publisher="CN=User Name" Version="0.0.0.0" />

  <mp:PhoneIdentity PhoneProductId="547E87AB-86D0-4B04-9C6F-FC8E8415B68C" PhonePublisherId="00000000-0000-0000-0000-000000000000"/>

  <Properties>
    <DisplayName>$placeholder$</DisplayName>
    <PublisherDisplayName>User Name</PublisherDisplayName>
    <Logo>$placeholder$.png</Logo>
  </Properties>

  <Dependencies>
    <TargetDeviceFamily Name="Windows.Universal" MinVersion="10.0.17763.0" MaxVersionTested="10.0.19041.0" />
    <TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.17763.0" MaxVersionTested="10.0.19041.0" />
  </Dependencies>

  <Resources>
    <Resource Language="x-generate" />
  </Resources>

  <Applications>
    <Application Id="App" Executable="$targetnametoken$.exe" EntryPoint="$targetentrypoint$">
      <uap:VisualElements
        DisplayName="$placeholder$"
        Description="$placeholder$"
        Square150x150Logo="$placeholder$.png"
        Square44x44Logo="$placeholder$.png"
        BackgroundColor="transparent">
        <uap:DefaultTile Square71x71Logo="$placeholder$.png" Wide310x150Logo="$placeholder$.png" Square310x310Logo="$placeholder$.png" />
        <uap:SplashScreen Image="$placeholder$.png" />
      </uap:VisualElements>
    </Application>
  </Applications>

  <Capabilities>
    <rescap:Capability Name="runFullTrust" />
  </Capabilities>

</Package>
```

## File: Properties/launchSettings.json
```json
{
  "profiles": {
    "Windows Machine": {
      "commandName": "MsixPackage",
      "nativeDebugging": false
    }
  }
}
```

## File: Resources/AppIcon/appicon.svg
```xml
<?xml version="1.0" encoding="UTF-8" standalone="no"?>
<svg width="456" height="456" viewBox="0 0 456 456" version="1.1" xmlns="http://www.w3.org/2000/svg">
    <rect x="0" y="0" width="456" height="456" fill="#512BD4" />
</svg>
```

## File: Resources/AppIcon/appiconfg.svg
```xml
<?xml version="1.0" encoding="UTF-8" standalone="no"?>
<!DOCTYPE svg PUBLIC "-//W3C//DTD SVG 1.1//EN" "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">
<svg width="456" height="456" viewBox="0 0 456 456" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" xml:space="preserve" xmlns:serif="http://www.serif.com/" style="fill-rule:evenodd;clip-rule:evenodd;stroke-linejoin:round;stroke-miterlimit:2;">
    <path d="m 105.50037,281.60863 c -2.70293,0 -5.00091,-0.90042 -6.893127,-2.70209 -1.892214,-1.84778 -2.837901,-4.04181 -2.837901,-6.58209 0,-2.58722 0.945687,-4.80389 2.837901,-6.65167 1.892217,-1.84778 4.190197,-2.77167 6.893127,-2.77167 2.74819,0 5.06798,0.92389 6.96019,2.77167 1.93749,1.84778 2.90581,4.06445 2.90581,6.65167 0,2.54028 -0.96832,4.73431 -2.90581,6.58209 -1.89221,1.80167 -4.212,2.70209 -6.96019,2.70209 z" style="fill:#ffffff;fill-rule:nonzero;stroke-width:0.838376" />
    <path d="M 213.56111,280.08446 H 195.99044 L 149.69953,207.0544 c -1.17121,-1.84778 -2.14037,-3.76515 -2.90581,-5.75126 h -0.40578 c 0.36051,2.12528 0.54076,6.67515 0.54076,13.6496 v 65.13172 h -15.54349 v -99.36009 h 18.71925 l 44.7374,71.29798 c 1.89222,2.95695 3.1087,4.98917 3.64945,6.09751 h 0.26996 c -0.45021,-2.6325 -0.67573,-7.09015 -0.67573,-13.37293 v -64.02256 h 15.47557 z" style="fill:#ffffff;fill-rule:nonzero;stroke-width:0.838376" />
    <path d="m 289.25134,280.08446 h -54.40052 v -99.36009 h 52.23835 v 13.99669 h -36.15411 v 28.13085 h 33.31621 v 13.9271 h -33.31621 v 29.37835 h 38.31628 z" style="fill:#ffffff;fill-rule:nonzero;stroke-width:0.838376" />
    <path d="M 366.56466,194.72106 H 338.7222 v 85.3634 h -16.08423 v -85.3634 h -27.77455 v -13.99669 h 71.70124 z" style="fill:#ffffff;fill-rule:nonzero;stroke-width:0.838376" />
</svg>
```

## File: Resources/Raw/AboutAssets.txt
```
Any raw assets you want to be deployed with your application can be placed in
this directory (and child directories). Deployment of the asset to your application
is automatically handled by the following `MauiAsset` Build Action within your `.csproj`.

	<MauiAsset Include="Resources\Raw\**" LogicalName="%(RecursiveDir)%(Filename)%(Extension)" />

These files will be deployed with your package and will be accessible using Essentials:

	async Task LoadMauiAsset()
	{
		using var stream = await FileSystem.OpenAppPackageFileAsync("AboutAssets.txt");
		using var reader = new StreamReader(stream);

		var contents = reader.ReadToEnd();
	}
```

## File: Resources/Splash/splash.svg
```xml
<?xml version="1.0" encoding="UTF-8" standalone="no"?>
<!DOCTYPE svg PUBLIC "-//W3C//DTD SVG 1.1//EN" "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd">
<svg width="456" height="456" viewBox="0 0 456 456" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" xml:space="preserve" xmlns:serif="http://www.serif.com/" style="fill-rule:evenodd;clip-rule:evenodd;stroke-linejoin:round;stroke-miterlimit:2;">
    <path d="m 105.50037,281.60863 c -2.70293,0 -5.00091,-0.90042 -6.893127,-2.70209 -1.892214,-1.84778 -2.837901,-4.04181 -2.837901,-6.58209 0,-2.58722 0.945687,-4.80389 2.837901,-6.65167 1.892217,-1.84778 4.190197,-2.77167 6.893127,-2.77167 2.74819,0 5.06798,0.92389 6.96019,2.77167 1.93749,1.84778 2.90581,4.06445 2.90581,6.65167 0,2.54028 -0.96832,4.73431 -2.90581,6.58209 -1.89221,1.80167 -4.212,2.70209 -6.96019,2.70209 z" style="fill:#ffffff;fill-rule:nonzero;stroke-width:0.838376" />
    <path d="M 213.56111,280.08446 H 195.99044 L 149.69953,207.0544 c -1.17121,-1.84778 -2.14037,-3.76515 -2.90581,-5.75126 h -0.40578 c 0.36051,2.12528 0.54076,6.67515 0.54076,13.6496 v 65.13172 h -15.54349 v -99.36009 h 18.71925 l 44.7374,71.29798 c 1.89222,2.95695 3.1087,4.98917 3.64945,6.09751 h 0.26996 c -0.45021,-2.6325 -0.67573,-7.09015 -0.67573,-13.37293 v -64.02256 h 15.47557 z" style="fill:#ffffff;fill-rule:nonzero;stroke-width:0.838376" />
    <path d="m 289.25134,280.08446 h -54.40052 v -99.36009 h 52.23835 v 13.99669 h -36.15411 v 28.13085 h 33.31621 v 13.9271 h -33.31621 v 29.37835 h 38.31628 z" style="fill:#ffffff;fill-rule:nonzero;stroke-width:0.838376" />
    <path d="M 366.56466,194.72106 H 338.7222 v 85.3634 h -16.08423 v -85.3634 h -27.77455 v -13.99669 h 71.70124 z" style="fill:#ffffff;fill-rule:nonzero;stroke-width:0.838376" />
</svg>
```

## File: Resources/Styles/Colors.xaml
```
<?xml version="1.0" encoding="UTF-8" ?>
<?xaml-comp compile="true" ?>
<ResourceDictionary 
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">

    <!-- Note: For Android please see also Platforms\Android\Resources\values\colors.xml -->

    <Color x:Key="Primary">#512BD4</Color>
    <Color x:Key="PrimaryDark">#ac99ea</Color>
    <Color x:Key="PrimaryDarkText">#242424</Color>
    <Color x:Key="Secondary">#DFD8F7</Color>
    <Color x:Key="SecondaryDarkText">#9880e5</Color>
    <Color x:Key="Tertiary">#2B0B98</Color>

    <Color x:Key="White">White</Color>
    <Color x:Key="Black">Black</Color>
    <Color x:Key="Magenta">#D600AA</Color>
    <Color x:Key="MidnightBlue">#190649</Color>
    <Color x:Key="OffBlack">#1f1f1f</Color>

    <Color x:Key="Gray100">#E1E1E1</Color>
    <Color x:Key="Gray200">#C8C8C8</Color>
    <Color x:Key="Gray300">#ACACAC</Color>
    <Color x:Key="Gray400">#919191</Color>
    <Color x:Key="Gray500">#6E6E6E</Color>
    <Color x:Key="Gray600">#404040</Color>
    <Color x:Key="Gray900">#212121</Color>
    <Color x:Key="Gray950">#141414</Color>

    <SolidColorBrush x:Key="PrimaryBrush" Color="{StaticResource Primary}"/>
    <SolidColorBrush x:Key="SecondaryBrush" Color="{StaticResource Secondary}"/>
    <SolidColorBrush x:Key="TertiaryBrush" Color="{StaticResource Tertiary}"/>
    <SolidColorBrush x:Key="WhiteBrush" Color="{StaticResource White}"/>
    <SolidColorBrush x:Key="BlackBrush" Color="{StaticResource Black}"/>

    <SolidColorBrush x:Key="Gray100Brush" Color="{StaticResource Gray100}"/>
    <SolidColorBrush x:Key="Gray200Brush" Color="{StaticResource Gray200}"/>
    <SolidColorBrush x:Key="Gray300Brush" Color="{StaticResource Gray300}"/>
    <SolidColorBrush x:Key="Gray400Brush" Color="{StaticResource Gray400}"/>
    <SolidColorBrush x:Key="Gray500Brush" Color="{StaticResource Gray500}"/>
    <SolidColorBrush x:Key="Gray600Brush" Color="{StaticResource Gray600}"/>
    <SolidColorBrush x:Key="Gray900Brush" Color="{StaticResource Gray900}"/>
    <SolidColorBrush x:Key="Gray950Brush" Color="{StaticResource Gray950}"/>
    
    <Color x:Key="MedCompBackground">#121212</Color>
    <Color x:Key="MedCompPrimary">#00CEC8</Color>
    <Color x:Key="MedCompPrimaryDark">#00938F</Color>
    <Color x:Key="MedCompTextPrimary">#FFFFFF</Color>
    <Color x:Key="MedCompTextSecondary">#B0B0B0</Color>
    
</ResourceDictionary>
```

## File: Resources/Styles/Styles.xaml
```
<?xml version="1.0" encoding="UTF-8" ?>
<?xaml-comp compile="true" ?>
<ResourceDictionary 
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">

    <Style TargetType="ActivityIndicator">
        <Setter Property="Color" Value="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource White}}" />
    </Style>

    <Style TargetType="IndicatorView">
        <Setter Property="IndicatorColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray500}}"/>
        <Setter Property="SelectedIndicatorColor" Value="{AppThemeBinding Light={StaticResource Gray950}, Dark={StaticResource Gray100}}"/>
    </Style>

    <Style TargetType="Border">
        <Setter Property="Stroke" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray500}}" />
        <Setter Property="StrokeShape" Value="Rectangle"/>
        <Setter Property="StrokeThickness" Value="1"/>
    </Style>

    <Style TargetType="BoxView">
        <Setter Property="BackgroundColor" Value="{AppThemeBinding Light={StaticResource Gray950}, Dark={StaticResource Gray200}}" />
    </Style>

    <Style TargetType="Button">
        <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource White}, Dark={StaticResource PrimaryDarkText}}" />
        <Setter Property="BackgroundColor" Value="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource PrimaryDark}}" />
        <Setter Property="FontFamily" Value="OpenSansRegular"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="BorderWidth" Value="0"/>
        <Setter Property="CornerRadius" Value="8"/>
        <Setter Property="Padding" Value="14,10"/>
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray950}, Dark={StaticResource Gray200}}" />
                            <Setter Property="BackgroundColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray600}}" />
                        </VisualState.Setters>
                    </VisualState>
                    <!-- Добавляем эффект нажатия -->
                    <VisualState x:Name="Pressed">
                        <VisualState.Setters>
                            <Setter Property="Scale" Value="0.96" />
                            <Setter Property="Opacity" Value="0.8" />
                        </VisualState.Setters>
                    </VisualState>
                    <VisualState x:Name="PointerOver" />
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="CheckBox">
        <Setter Property="Color" Value="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource White}}" />
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="Color" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="DatePicker">
        <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray900}, Dark={StaticResource White}}" />
        <Setter Property="BackgroundColor" Value="Transparent" />
        <Setter Property="FontFamily" Value="OpenSansRegular"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray500}}" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="Editor">
        <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Black}, Dark={StaticResource White}}" />
        <Setter Property="BackgroundColor" Value="Transparent" />
        <Setter Property="FontFamily" Value="OpenSansRegular"/>
        <Setter Property="FontSize" Value="14" />
        <Setter Property="PlaceholderColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray500}}" />
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="Entry">
        <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Black}, Dark={StaticResource White}}" />
        <Setter Property="BackgroundColor" Value="Transparent" />
        <Setter Property="FontFamily" Value="OpenSansRegular"/>
        <Setter Property="FontSize" Value="14" />
        <Setter Property="PlaceholderColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray500}}" />
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="Frame">
        <Setter Property="HasShadow" Value="False" />
        <Setter Property="BorderColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray950}}" />
        <Setter Property="CornerRadius" Value="8" />
        <Setter Property="BackgroundColor" Value="{AppThemeBinding Light={StaticResource White}, Dark={StaticResource Black}}" />
    </Style>

    <Style TargetType="ImageButton">
        <Setter Property="Opacity" Value="1" />
        <Setter Property="BorderColor" Value="Transparent"/>
        <Setter Property="BorderWidth" Value="0"/>
        <Setter Property="CornerRadius" Value="0"/>
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="Opacity" Value="0.5" />
                        </VisualState.Setters>
                    </VisualState>
                    <VisualState x:Name="PointerOver" />
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="Label">
        <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Black}, Dark={StaticResource White}}" />
        <Setter Property="BackgroundColor" Value="Transparent" />
        <Setter Property="FontFamily" Value="OpenSansRegular" />
        <Setter Property="FontSize" Value="14" />
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="Span">
        <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Black}, Dark={StaticResource White}}" />
    </Style>

    <Style TargetType="Label" x:Key="Headline">
        <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource MidnightBlue}, Dark={StaticResource White}}" />
        <Setter Property="FontSize" Value="32" />
        <Setter Property="HorizontalOptions" Value="Center" />
        <Setter Property="HorizontalTextAlignment" Value="Center" />
    </Style>

    <Style TargetType="Label" x:Key="SubHeadline">
        <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource MidnightBlue}, Dark={StaticResource White}}" />
        <Setter Property="FontSize" Value="24" />
        <Setter Property="HorizontalOptions" Value="Center" />
        <Setter Property="HorizontalTextAlignment" Value="Center" />
    </Style>

    <Style TargetType="ListView">
        <Setter Property="SeparatorColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray500}}" />
        <Setter Property="RefreshControlColor" Value="{AppThemeBinding Light={StaticResource Gray900}, Dark={StaticResource Gray200}}" />
    </Style>

    <Style TargetType="Picker">
        <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray900}, Dark={StaticResource White}}" />
        <Setter Property="TitleColor" Value="{AppThemeBinding Light={StaticResource Gray900}, Dark={StaticResource Gray200}}" />
        <Setter Property="BackgroundColor" Value="Transparent" />
        <Setter Property="FontFamily" Value="OpenSansRegular"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                            <Setter Property="TitleColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="ProgressBar">
        <Setter Property="ProgressColor" Value="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource White}}" />
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="ProgressColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="RadioButton">
        <Setter Property="BackgroundColor" Value="Transparent"/>
        <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Black}, Dark={StaticResource White}}" />
        <Setter Property="FontFamily" Value="OpenSansRegular"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="RefreshView">
        <Setter Property="RefreshColor" Value="{AppThemeBinding Light={StaticResource Gray900}, Dark={StaticResource Gray200}}" />
    </Style>

    <Style TargetType="SearchBar">
        <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray900}, Dark={StaticResource White}}" />
        <Setter Property="PlaceholderColor" Value="{StaticResource Gray500}" />
        <Setter Property="CancelButtonColor" Value="{StaticResource Gray500}" />
        <Setter Property="BackgroundColor" Value="Transparent" />
        <Setter Property="FontFamily" Value="OpenSansRegular" />
        <Setter Property="FontSize" Value="14" />
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                            <Setter Property="PlaceholderColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="SearchHandler">
        <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray900}, Dark={StaticResource White}}" />
        <Setter Property="PlaceholderColor" Value="{StaticResource Gray500}" />
        <Setter Property="BackgroundColor" Value="Transparent" />
        <Setter Property="FontFamily" Value="OpenSansRegular" />
        <Setter Property="FontSize" Value="14" />
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                            <Setter Property="PlaceholderColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="Shadow">
        <Setter Property="Radius" Value="15" />
        <Setter Property="Opacity" Value="0.5" />
        <Setter Property="Brush" Value="{AppThemeBinding Light={StaticResource White}, Dark={StaticResource White}}" />
        <Setter Property="Offset" Value="10,10" />
    </Style>

    <Style TargetType="Slider">
        <Setter Property="MinimumTrackColor" Value="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource White}}" />
        <Setter Property="MaximumTrackColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray600}}" />
        <Setter Property="ThumbColor" Value="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource White}}" />
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="MinimumTrackColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}"/>
                            <Setter Property="MaximumTrackColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}"/>
                            <Setter Property="ThumbColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}"/>
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="SwipeItem">
        <Setter Property="BackgroundColor" Value="{AppThemeBinding Light={StaticResource White}, Dark={StaticResource Black}}" />
    </Style>

    <Style TargetType="Switch">
        <Setter Property="OnColor" Value="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource White}}" />
        <Setter Property="ThumbColor" Value="{StaticResource White}" />
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="OnColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                            <Setter Property="ThumbColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                        </VisualState.Setters>
                    </VisualState>
                    <VisualState x:Name="On">
                        <VisualState.Setters>
                            <Setter Property="OnColor" Value="{AppThemeBinding Light={StaticResource Secondary}, Dark={StaticResource Gray200}}" />
                            <Setter Property="ThumbColor" Value="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource White}}" />
                        </VisualState.Setters>
                    </VisualState>
                    <VisualState x:Name="Off">
                        <VisualState.Setters>
                            <Setter Property="ThumbColor" Value="{AppThemeBinding Light={StaticResource Gray400}, Dark={StaticResource Gray500}}" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="TimePicker">
        <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray900}, Dark={StaticResource White}}" />
        <Setter Property="BackgroundColor" Value="Transparent"/>
        <Setter Property="FontFamily" Value="OpenSansRegular"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="MinimumHeightRequest" Value="44"/>
        <Setter Property="MinimumWidthRequest" Value="44"/>
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="Disabled">
                        <VisualState.Setters>
                            <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource Gray300}, Dark={StaticResource Gray600}}" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>

    <Style TargetType="Page" ApplyToDerivedTypes="True">
        <Setter Property="Padding" Value="0"/>
        <Setter Property="BackgroundColor" Value="{AppThemeBinding Light={StaticResource White}, Dark={StaticResource OffBlack}}" />
    </Style>

    <Style TargetType="Shell" ApplyToDerivedTypes="True">
        <Setter Property="Shell.BackgroundColor" Value="{AppThemeBinding Light={StaticResource White}, Dark={StaticResource OffBlack}}" />
        <Setter Property="Shell.ForegroundColor" Value="{AppThemeBinding Light={StaticResource Black}, Dark={StaticResource SecondaryDarkText}}" />
        <Setter Property="Shell.TitleColor" Value="{AppThemeBinding Light={StaticResource Black}, Dark={StaticResource SecondaryDarkText}}" />
        <Setter Property="Shell.DisabledColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray950}}" />
        <Setter Property="Shell.UnselectedColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray200}}" />
        <Setter Property="Shell.NavBarHasShadow" Value="False" />
        <Setter Property="Shell.TabBarBackgroundColor" Value="{AppThemeBinding Light={StaticResource White}, Dark={StaticResource Black}}" />
        <Setter Property="Shell.TabBarForegroundColor" Value="{AppThemeBinding Light={StaticResource Magenta}, Dark={StaticResource White}}" />
        <Setter Property="Shell.TabBarTitleColor" Value="{AppThemeBinding Light={StaticResource Magenta}, Dark={StaticResource White}}" />
        <Setter Property="Shell.TabBarUnselectedColor" Value="{AppThemeBinding Light={StaticResource Gray900}, Dark={StaticResource Gray200}}" />
    </Style>

    <Style TargetType="NavigationPage">
        <Setter Property="BarBackgroundColor" Value="{AppThemeBinding Light={StaticResource White}, Dark={StaticResource OffBlack}}" />
        <Setter Property="BarTextColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource White}}" />
        <Setter Property="IconColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource White}}" />
    </Style>

    <Style TargetType="TabbedPage">
        <Setter Property="BarBackgroundColor" Value="{AppThemeBinding Light={StaticResource White}, Dark={StaticResource Gray950}}" />
        <Setter Property="BarTextColor" Value="{AppThemeBinding Light={StaticResource Magenta}, Dark={StaticResource White}}" />
        <Setter Property="UnselectedTabColor" Value="{AppThemeBinding Light={StaticResource Gray200}, Dark={StaticResource Gray950}}" />
        <Setter Property="SelectedTabColor" Value="{AppThemeBinding Light={StaticResource Gray950}, Dark={StaticResource Gray200}}" />
    </Style>
    
    
    <!-- Базовый стиль страницы -->
    <Style TargetType="ContentPage">
        <Setter Property="BackgroundColor" Value="{StaticResource MedCompBackground}" />
        <Setter Property="Padding" Value="20" />
    </Style>

    <!-- Заголовок формы -->
    <Style x:Key="FormTitleLabelStyle" TargetType="Label">
        <Setter Property="FontSize" Value="26" />
        <Setter Property="FontAttributes" Value="Bold" />
        <Setter Property="TextColor" Value="{StaticResource MedCompTextPrimary}" />
    </Style>

    <!-- Подписи к полям -->
    <Style x:Key="FieldLabelStyle" TargetType="Label">
        <Setter Property="FontSize" Value="14" />
        <Setter Property="TextColor" Value="{StaticResource MedCompTextSecondary}" />
    </Style>

    <!-- Поля ввода -->
    <Style x:Key="EntryStyle" TargetType="Entry">
        <Setter Property="BackgroundColor" Value="#1E1E1E" />
        <Setter Property="TextColor" Value="{StaticResource MedCompTextPrimary}" />
        <Setter Property="PlaceholderColor" Value="#777777" />
        <Setter Property="HeightRequest" Value="44" />
        <Setter Property="Margin" Value="0,4,0,0" />
    </Style>

    <!-- Основная кнопка -->
    <Style x:Key="PrimaryButtonStyle" TargetType="Button">
        <Setter Property="BackgroundColor" Value="{StaticResource MedCompPrimary}" />
        <Setter Property="TextColor" Value="White" />
        <Setter Property="CornerRadius" Value="16" />
        <Setter Property="HeightRequest" Value="48" />
        <Setter Property="FontAttributes" Value="Bold" />
    </Style>
    <Color x:Key="AppBackgroundStart">#061826</Color>
    <Color x:Key="AppBackgroundEnd">#0F5C63</Color>
    <Color x:Key="CardBackground">#141821</Color>
    <Color x:Key="PrimaryAccent">#00CEC8</Color>
    <Color x:Key="TextPrimary">#FFFFFF</Color>
    <!-- Градиент фона страницы -->
    <LinearGradientBrush x:Key="AppBackgroundBrush" StartPoint="0,0" EndPoint="0,1">
        <GradientStop Color="{StaticResource AppBackgroundStart}" Offset="0.0" />
        <GradientStop Color="{StaticResource AppBackgroundStart}" Offset="0.4" />
        <GradientStop Color="{StaticResource AppBackgroundEnd}" Offset="1.0" />
    </LinearGradientBrush>
    
    <!-- Стиль карточки (контейнер для контента) -->
    <Style x:Key="CardFrameStyle" TargetType="Frame">
        <Setter Property="BackgroundColor" Value="{StaticResource CardBackground}" />
        <Setter Property="CornerRadius" Value="24" />
        <Setter Property="HasShadow" Value="True" />
        <Setter Property="Padding" Value="20" />
        <Setter Property="BorderColor" Value="Transparent" />
    </Style>
    
    <!-- Стиль заголовка страницы -->
    <Style x:Key="PageTitleStyle" TargetType="Label">
        <Setter Property="FontSize" Value="24" />
        <Setter Property="FontAttributes" Value="Bold" />
        <Setter Property="TextColor" Value="{StaticResource TextPrimary}" />
        <Setter Property="HorizontalOptions" Value="Center" />
        <Setter Property="Margin" Value="0,0,0,20" />
    </Style>
    
    

</ResourceDictionary>
```

## File: Services/AuthService.cs
```csharp
using MedCompatibility.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.Services;

public class AuthService : IAuthService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;
    public AuthService(IDbContextFactory<DrugContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<user?> LoginAsync(string login, string password)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var user = await context.users
            .AsNoTracking()
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Login == login);
        if (user == null) return null;
        bool isPasswordValid = false;
        try 
        {
            isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }
        catch
        {
            isPasswordValid = (user.PasswordHash == password);
        }
        if (!isPasswordValid) return null;
        return user;
    }

    public async Task<string> RegisterUserAsync(string login, string password, string firstName, string lastName, string middleName, string roleName)
    {   
        try {
            using var context = await _contextFactory.CreateDbContextAsync();
            var exists = await context.users.AnyAsync(u => u.Login == login);
            if (exists) return "Пользователь с таким логином уже существует";
            var role = await context.roles.FirstOrDefaultAsync(r => r.Name.ToLower() == roleName.ToLower());
            if (role == null) return $"Ошибка: роль '{roleName}' не найдена";
            bool isApproved = (roleName.ToLower() != "doctor" && roleName.ToLower() != "врач");
            var newUser = new user 
            {
                Login = login,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                RoleId = role.RoleId,
                IsApproved = isApproved,
                CreatedAt = DateTime.Now
            };
            context.users.Add(newUser);
            await context.SaveChangesAsync();
            return null;
        } catch (Exception ex) {
            return $"Ошибка базы данных: {ex.Message}";
        }
    }
}
```

## File: Services/DatabaseHealthService.cs
```csharp
using System.Data.Common;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace MedCompatibility.Services;

public class DatabaseHealthService : IDatabaseHealthService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;

    public bool IsAvailable { get; private set; }
    public string? LastErrorShort { get; private set; }
    public string? LastErrorDetails { get; private set; }

    public DatabaseHealthService(IDbContextFactory<DrugContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task CheckAsync(CancellationToken ct = default)
    {
        LastErrorShort = null;
        LastErrorDetails = null;

        try
        {
            await using var ctx = await _contextFactory.CreateDbContextAsync(ct);

            // Быстрая проверка (может не дать деталей)
            if (await ctx.Database.CanConnectAsync(ct))
            {
                IsAvailable = true;
                return;
            }

            // Глубокая проверка: получаем реальную причину (exception message)
            try
            {
                DbConnection conn = ctx.Database.GetDbConnection();
                await conn.OpenAsync(ct);
                await conn.CloseAsync();
                IsAvailable = true;
            }
            catch (Exception ex)
            {
                IsAvailable = false;
                LastErrorShort = "Не удалось подключиться к базе данных.";
                LastErrorDetails = ex.ToString();
            }
        }
        catch (Exception ex)
        {
            IsAvailable = false;
            LastErrorShort = "База данных сейчас недоступна.";
            LastErrorDetails = ex.ToString();
        }
    }
}
```

## File: Services/InteractionService.cs
```csharp
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Services;

public class InteractionService : IInteractionService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;

    public InteractionService(IDbContextFactory<DrugContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    // --- СУЩЕСТВУЮЩИЕ МЕТОДЫ (Оставляем как есть) ---

    public async Task<List<interaction>> GetAllInteractionsAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.interactions
            .Include(i => i.SubstanceId1Navigation)
            .Include(i => i.SubstanceId2Navigation)
            .Include(i => i.InteractionType)
            .Include(i => i.RiskLevel)
            .OrderBy(i => i.SubstanceId1Navigation.Name)
            .AsNoTracking()
            .ToListAsync();
    }
    
    // ... (Методы Add, Delete, GetDictionaries оставляем без изменений) ...

    public async Task<List<interactiontype>> GetInteractionTypesAsync()
    {
         using var context = await _contextFactory.CreateDbContextAsync();
         return await context.interactiontypes.OrderBy(t => t.Name).ToListAsync();
    }

    public async Task<List<risklevel>> GetRiskLevelsAsync()
    {
         using var context = await _contextFactory.CreateDbContextAsync();
         return await context.risklevels.OrderBy(r => r.RiskLevelId).ToListAsync();
    }

    public async Task AddInteractionAsync(int subId1, int subId2, int typeId, int riskId, string desc, string recommendation)
    {
        // ... (Твой код добавления) ...
         if (subId1 == subId2)
            throw new Exception("Нельзя создать конфликт вещества с самим собой.");

        using var context = await _contextFactory.CreateDbContextAsync();

        var exists = await context.interactions.AnyAsync(i => 
            (i.SubstanceId1 == subId1 && i.SubstanceId2 == subId2) ||
            (i.SubstanceId1 == subId2 && i.SubstanceId2 == subId1));

        if (exists)
            throw new Exception("Такое взаимодействие уже существует.");

        var newInteraction = new interaction
        {
            SubstanceId1 = subId1,
            SubstanceId2 = subId2,
            InteractionTypeId = typeId,
            RiskLevelId = riskId,
            Description = desc,
            Recommendation = recommendation
        };

        context.interactions.Add(newInteraction);
        await context.SaveChangesAsync();
    }
    
    public async Task DeleteInteractionAsync(int id)
    {
         using var context = await _contextFactory.CreateDbContextAsync();
        var item = await context.interactions.FindAsync(id);
        if (item != null)
        {
            context.interactions.Remove(item);
            await context.SaveChangesAsync();
        }
    }

    public async Task<interaction?> GetInteractionByIdAsync(int id)
    {
         using var context = await _contextFactory.CreateDbContextAsync();
        return await context.interactions
            .Include(i => i.SubstanceId1Navigation)
            .Include(i => i.SubstanceId2Navigation)
            .Include(i => i.InteractionType)
            .Include(i => i.RiskLevel)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.InteractionId == id);
    }

    public async Task UpdateInteractionAsync(interaction item)
    {
         using var context = await _contextFactory.CreateDbContextAsync();
        var exists = await context.interactions.AnyAsync(i => 
            i.InteractionId != item.InteractionId && 
            ((i.SubstanceId1 == item.SubstanceId1 && i.SubstanceId2 == item.SubstanceId2) ||
             (i.SubstanceId1 == item.SubstanceId2 && i.SubstanceId2 == item.SubstanceId1)));

        if (exists) throw new Exception("Такое взаимодействие уже существует.");

        context.interactions.Update(item);
        await context.SaveChangesAsync();
    }

    // --- НОВЫЙ МЕТОД: ПРОВЕРКА КОНФЛИКТА ---
    public async Task<List<interaction>> CheckInteractionAsync(int medicineId1, int medicineId2)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        // 1. Получаем вещества первого лекарства
        var med1Substances = await context.medicines
            .Where(m => m.MedicineId == medicineId1)
            .SelectMany(m => m.Substances)
            .Select(s => s.SubstanceId)
            .ToListAsync();

        // 2. Получаем вещества второго лекарства
        var med2Substances = await context.medicines
            .Where(m => m.MedicineId == medicineId2)
            .SelectMany(m => m.Substances)
            .Select(s => s.SubstanceId)
            .ToListAsync();

        if (!med1Substances.Any() || !med2Substances.Any())
        {
            return new List<interaction>();
        }

        // 3. Ищем взаимодействия
        var conflicts = await context.interactions
            .Include(i => i.RiskLevel)
            .Include(i => i.InteractionType) // Чтобы показать тип (хотя ты просил скрыть, но в модели пусть будет)
            .Include(i => i.SubstanceId1Navigation)
            .Include(i => i.SubstanceId2Navigation)
            .Where(i => 
                (med1Substances.Contains(i.SubstanceId1) && med2Substances.Contains(i.SubstanceId2)) ||
                (med1Substances.Contains(i.SubstanceId2) && med2Substances.Contains(i.SubstanceId1))
            )
            .ToListAsync();

        return conflicts;
    }
}
```

## File: Services/Interfaces/IAuthService.cs
```csharp
using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IAuthService
{
    Task<user?> LoginAsync(string login, string password);
    Task<string> RegisterUserAsync(string login, string password, string firstName, string lastName, string middleName, string roleName);
}
```

## File: Services/Interfaces/IDatabaseHealthService.cs
```csharp
namespace MedCompatibility.Services.Interfaces;

public interface IDatabaseHealthService
{
    bool IsAvailable { get; }
    string? LastErrorShort { get; }
    string? LastErrorDetails { get; }

    Task CheckAsync(CancellationToken ct = default);
}
```

## File: Services/Interfaces/IInteractionService.cs
```csharp
using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IInteractionService
{
    // Получить список конфликтов (с include всех связей)
    Task<List<interaction>> GetAllInteractionsAsync();

    // Справочники для выпадающих списков
    Task<List<interactiontype>> GetInteractionTypesAsync();
    Task<List<risklevel>> GetRiskLevelsAsync();

    // Создать взаимодействие
    Task AddInteractionAsync(int subId1, int subId2, int typeId, int riskId, string desc, string recommendation);

    // Удалить
    Task DeleteInteractionAsync(int id);
    
    Task<interaction?> GetInteractionByIdAsync(int id);
    Task UpdateInteractionAsync(interaction item);
    Task<List<interaction>> CheckInteractionAsync(int medicineId1, int medicineId2);
}
```

## File: Services/Interfaces/ILoadingService.cs
```csharp
namespace MedCompatibility.Services.Interfaces;

public interface ILoadingService
{
    void Show();
    void Hide();
    bool IsShown { get; }
}
```

## File: Services/Interfaces/IMedicineService.cs
```csharp
using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IMedicineService
{
    // Получить список с фильтрацией (поиск + производитель)
    Task<List<medicine>> GetMedicinesFilteredAsync(string searchText, string manufacturerName);
    
    // Получить всех производителей (для фильтра в UI)
    Task<List<manufacturer>> GetAllManufacturersAsync();

    // Удалить (мягкое удаление)
    Task DeleteMedicineAsync(int id);
    
    // Добавляем методы создания справочников
    Task<manufacturer> CreateManufacturerAsync(string name, string country, string city, string description);
    Task<activesubstance> CreateSubstanceAsync(string name, string description);
    Task<List<activesubstance>> SearchSubstancesAsync(string query); // Для поиска при добавлении
    Task CreateMedicineAsync(medicine med, List<int> substanceIds); // Сохранение лекарства со связями
    Task<bool> ExistsMedicineByGtinAsync(string gtin); // Проверка на дубли
    Task<medicine?> GetMedicineByGtinAsync(string gtin);
    
    Task UpdateMedicineAsync(medicine med, List<int> substanceIds);
    Task<medicine?> GetMedicineByIdAsync(int id);
    Task<List<medicine>> SearchMedicinesAsync(string query);

}
```

## File: Services/Interfaces/IPrescriptionService.cs
```csharp
using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IPrescriptionService
{
    Task<List<prescription>> GetPatientPrescriptionsAsync(int patientId);
    Task<prescription> AddPrescriptionAsync(int patientId, int doctorId, int medicineId, string? notes);
}
```

## File: Services/Interfaces/IScanService.cs
```csharp
using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IScanService
{
    // Записывает факт сканирования (если пользователь не гость)
    Task LogScanAsync(int medicineId);
    
    // Получает историю для текущего пользователя
    Task<List<scan>> GetUserHistoryAsync();
    Task<List<scan>> GetAllScansAsync();
}
```

## File: Services/Interfaces/IUserService.cs
```csharp
using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IUserService
{
    Task<List<user>> GetAllUsersAsync();
    Task ToggleUserStatusAsync(int userId, bool isApproved);
    
    // Новые быстрые методы
    Task<int> GetPatientsCountAsync();
    Task<int> GetActiveDoctorsCountAsync();
    
    Task<List<user>> GetUsersFilteredAsync(string? searchText, string? roleName, string? status);
    // Удаление
    Task DeleteUserAsync(int userId);
    Task UpdateUserProfileAsync(int userId, string firstName, string lastName, string middleName);
    Task<List<user>> SearchPatientsAsync(string query);
    
    // Получить список пациентов, прикрепленных к врачу
    Task<List<user>> GetDoctorPatientsAsync(int doctorId);

// Добавить пациента к врачу
    Task AddPatientToDoctorListAsync(int doctorId, int patientId);

// Поиск пациентов, КОТОРЫХ ЕЩЕ НЕТ у этого врача (для добавления)
    Task<List<user>> SearchNewPatientsAsync(string query, int excludeDoctorId);
}
```

## File: Services/Interfaces/IUserSessionService.cs
```csharp
using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IUserSessionService
{
    user? CurrentUser { get; }
    bool IsAuthenticated { get; }
    bool IsGuest { get; }
    
    void StartSession(user user);
    void EndSession();
}
```

## File: Services/LoadingService.cs
```csharp
using CommunityToolkit.Maui.Views;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.Services;

public class LoadingService : ILoadingService
{
    private Popup? _popup;

    public void Show()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (_popup != null)
                return;

            try
            {
                _popup = new LoadingPopup();
                Shell.Current?.ShowPopup(_popup);
            }
            catch
            {
                _popup = null;
            }
        });
    }

    public void Hide()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            var p = _popup;
            _popup = null;

            try
            {
                p?.Close();
            }
            catch
            {
                // Hide() никогда не должен ронять приложение
            }
        });
    }
    
    public bool IsShown => _popup != null;
}
```

## File: Services/MedicineService.cs
```csharp
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Services;

public class MedicineService : IMedicineService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;

    public MedicineService(IDbContextFactory<DrugContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<medicine>> GetMedicinesFilteredAsync(string searchText, string manufacturerName)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        
        // Include обязательно нужен, чтобы показать имя производителя
        var query = context.medicines
                           .Include(m => m.Manufacturer) 
                           .AsNoTracking()
                           .AsQueryable();

        // 1. Поиск (Название, INN или Штрихкод)
        if (!string.IsNullOrWhiteSpace(searchText))
        {
            string lowerSearch = searchText.ToLower();
            query = query.Where(m => 
                m.TradeName.ToLower().Contains(lowerSearch) ||
                m.GTIN.Contains(lowerSearch) || 
                (m.INN != null && m.INN.ToLower().Contains(lowerSearch)));
        }

        // 2. Фильтр по производителю
        if (!string.IsNullOrWhiteSpace(manufacturerName) && manufacturerName != "Все")
        {
            query = query.Where(m => m.Manufacturer.Name == manufacturerName);
        }

        return await query.OrderBy(m => m.TradeName).ToListAsync();
    }

    public async Task<List<manufacturer>> GetAllManufacturersAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.manufacturers
            .OrderBy(m => m.Name)
            .ToListAsync();
    }

    public async Task DeleteMedicineAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var item = await context.medicines.FindAsync(id);
        if (item != null)
        {
            item.IsDeleted = true;
            item.GTIN = $"DEL_{item.GTIN}_{DateTime.Now.Ticks}".Substring(0, Math.Min(49, $"DEL_{item.GTIN}_{DateTime.Now.Ticks}".Length)); 
        
            await context.SaveChangesAsync();
        }
    }

    public async Task<manufacturer> CreateManufacturerAsync(string name, string country, string city, string description)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
    
        var existing = await context.manufacturers.FirstOrDefaultAsync(m => m.Name == name);
        if (existing != null) return existing;

        var newItem = new manufacturer
        {
            Name = name,
            Country = string.IsNullOrWhiteSpace(country) ? "Республика Беларусь" : country,
            City = city,
            Description = description // <--- Сохраняем
        };
    
        context.manufacturers.Add(newItem);
        await context.SaveChangesAsync();
    
        return newItem;
    }



    public async Task<activesubstance> CreateSubstanceAsync(string name, string description)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var newItem = new activesubstance { Name = name, Description = description };
        context.activesubstances.Add(newItem);
        await context.SaveChangesAsync();
        return newItem;
    }

    public async Task<List<activesubstance>> SearchSubstancesAsync(string query)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
    
        if (string.IsNullOrWhiteSpace(query))
        {
            // Если запрос пустой - возвращаем ВСЕ (или первые 50)
            return await context.activesubstances
                .OrderBy(s => s.Name)
                .Take(50) // Лимит для безопасности
                .ToListAsync();
        }

        return await context.activesubstances
            .Where(s => s.Name.Contains(query))
            .OrderBy(s => s.Name)
            .ToListAsync();
    }

    public async Task CreateMedicineAsync(medicine med, List<int> substanceIds)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        // 1. Добавляем само лекарство
        context.medicines.Add(med);
        await context.SaveChangesAsync(); // Чтобы получить med.MedicineId

        // 2. Привязываем вещества (Таблица MedicineSubstance)
        if (substanceIds != null && substanceIds.Any())
        {
            // В EF Core Many-to-Many можно добавлять через коллекцию, 
            // но так как у нас связь через промежуточный объект (Dictionary или скрытый), 
            // проще выполнить SQL или приаттачить сущности.

            // Самый надежный способ в EF Core 6/7/8 для M:N без явной сущности связи:
            var substances = await context.activesubstances.Where(s => substanceIds.Contains(s.SubstanceId))
                .ToListAsync();

            // Важно: загружаем текущую коллекцию (она пустая, но инициализируется)
            // context.Entry(med).Collection(m => m.Substances).Load(); // Если бы мы были в одном контексте

            // Так как контекст новый, нам нужно прикрепить med (он уже Added) и добавить в коллекцию
            med.Substances = substances;
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsMedicineByGtinAsync(string gtin)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.medicines.AnyAsync(m => m.GTIN == gtin && !m.IsDeleted);
    }
    
    public async Task<medicine?> GetMedicineByGtinAsync(string gtin)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
    
        return await context.medicines
            .Include(m => m.Manufacturer) // Подгружаем производителя
            .Include(m => m.Substances)   // Подгружаем вещества
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.GTIN == gtin && !m.IsDeleted);
    }
    
    public async Task UpdateMedicineAsync(medicine med, List<int> substanceIds)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        
        // 1. Ищем существующее лекарство с подгрузкой веществ
        var existingMed = await context.medicines
            .Include(m => m.Substances)
            .FirstOrDefaultAsync(m => m.MedicineId == med.MedicineId);

        if (existingMed == null) throw new Exception("Лекарство не найдено");

        // 2. Обновляем простые поля
        existingMed.TradeName = med.TradeName;
        existingMed.INN = med.INN;
        existingMed.Form = med.Form;
        existingMed.GTIN = med.GTIN;
        existingMed.ManufacturerId = med.ManufacturerId;
        existingMed.Description = med.Description;
        // Не трогаем IsDeleted, prescriptions, scans

        // 3. Обновляем связи Many-to-Many (Вещества)
        // Очищаем старые связи
        existingMed.Substances.Clear();

        // Добавляем новые, если есть
        if (substanceIds != null && substanceIds.Any())
        {
            var substances = await context.activesubstances
                .Where(s => substanceIds.Contains(s.SubstanceId))
                .ToListAsync();
             
            foreach (var sub in substances)
            {
                existingMed.Substances.Add(sub);
            }
        }

        await context.SaveChangesAsync();
    }
    
    public async Task<medicine?> GetMedicineByIdAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.medicines
            .Include(m => m.Manufacturer)
            .Include(m => m.Substances)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.MedicineId == id);
    }
    
    public async Task<List<medicine>> SearchMedicinesAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query)) return new List<medicine>();

        using var context = await _contextFactory.CreateDbContextAsync();
    
        // Ищем по GTIN (полное совпадение) или по Названию (частичное)
        return await context.medicines
            .Include(m => m.Manufacturer) // Подгружаем производителя для красоты
            .Where(m => m.GTIN.Contains(query) || 
                        m.TradeName.Contains(query) || 
                        m.INN.Contains(query))
            .Take(20) // Ограничиваем список, чтобы не грузить базу
            .ToListAsync();
    }

}
```

## File: Services/PrescriptionService.cs
```csharp
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;

    public PrescriptionService(IDbContextFactory<DrugContext> contextFactory)
        => _contextFactory = contextFactory;

    public async Task<List<prescription>> GetPatientPrescriptionsAsync(int patientId)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();

        return await ctx.prescriptions
            .AsNoTracking()
            .Where(p => p.PatientId == patientId)
            .Include(p => p.Medicine)
            .Include(p => p.Doctor)
            .OrderByDescending(p => p.PrescribedAt)
            .ToListAsync();
    }

    public async Task<prescription> AddPrescriptionAsync(int patientId, int doctorId, int medicineId, string? notes)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();

        var p = new prescription
        {
            PatientId = patientId,
            DoctorId = doctorId,
            MedicineId = medicineId,
            Notes = notes,
            PrescribedAt = DateTime.Now
        };

        ctx.prescriptions.Add(p);
        await ctx.SaveChangesAsync();
        return p;
    }
}
```

## File: Services/ScanService.cs
```csharp
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Services;

public class ScanService : IScanService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;
    private readonly IUserSessionService _sessionService;

    public ScanService(IDbContextFactory<DrugContext> contextFactory, IUserSessionService sessionService)
    {
        _contextFactory = contextFactory;
        _sessionService = sessionService;
    }

    public async Task LogScanAsync(int medicineId)
    {
        // 1. Гостям историю не пишем (согласно ТЗ)
        if (!_sessionService.IsAuthenticated || _sessionService.CurrentUser == null)
            return;

        try
        {
            using var context = await _contextFactory.CreateDbContextAsync();

            var newScan = new scan
            {
                UserId = _sessionService.CurrentUser.UserId,
                MedicineId = medicineId,
                ScannedAt = DateTime.Now
            };

            context.scans.Add(newScan);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Логируем ошибку, но не роняем приложение, если история не записалась
            Console.WriteLine($"Ошибка записи истории: {ex.Message}");
        }
    }

    public async Task<List<scan>> GetUserHistoryAsync()
    {
        if (!_sessionService.IsAuthenticated || _sessionService.CurrentUser == null)
            return new List<scan>();

        using var context = await _contextFactory.CreateDbContextAsync();
        
        return await context.scans
            .Include(s => s.Medicine) // Подгружаем лекарство
            .Where(s => s.UserId == _sessionService.CurrentUser.UserId)
            .OrderByDescending(s => s.ScannedAt)
            .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task<List<scan>> GetAllScansAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        // Берем последние 100 записей, чтобы не грузить все миллионы
        return await context.scans
            .Include(s => s.Medicine)
            .Include(s => s.User) 
            .OrderByDescending(s => s.ScannedAt)
            .Take(100)
            .ToListAsync();
    }

}
```

## File: Services/UserService.cs
```csharp
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Services;

public class UserService : IUserService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;

    public UserService(IDbContextFactory<DrugContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<user>> GetAllUsersAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        
        return await context.users // с маленькой u
            .AsNoTracking() // Важно для read-only списков!
            .Include(u => u.Role)
            .OrderByDescending(u => u.CreatedAt)
            .ToListAsync();
    }

    public async Task ToggleUserStatusAsync(int userId, bool isApproved)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        
        var user = await context.users.FindAsync(userId);
        if (user != null)
        {
            user.IsApproved = isApproved;
            await context.SaveChangesAsync();
        }
    }
    public async Task<int> GetPatientsCountAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.users.AsNoTracking()
            .Where(u => u.Role.Name == "patient")
            .CountAsync();
    }

    public async Task<int> GetDoctorsCountAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.users.AsNoTracking()
            .Where(u => u.Role.Name == "doctor")
            .CountAsync();
    }
    
    public async Task<int> GetActiveDoctorsCountAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        return await context.users.AsNoTracking()
            .Where(u => u.Role.Name == "doctor" && u.IsApproved == true)
            .CountAsync();
    }
    
    public async Task<List<user>> GetUsersFilteredAsync(string? searchText, string? roleName, string? status)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var query = context.users
            .AsNoTracking()
            .Include(u => u.Role)
            .AsQueryable();

        // 1. Поиск по ФИО и Логину
        if (!string.IsNullOrWhiteSpace(searchText))
        {
            string s = searchText.Trim().ToLower();
            query = query.Where(u => 
                u.Login.ToLower().Contains(s) || 
                u.LastName.ToLower().Contains(s) ||
                u.FirstName.ToLower().Contains(s) ||
                (u.MiddleName != null && u.MiddleName.ToLower().Contains(s))
            );
        }

        // 2. Фильтр по роли
        if (!string.IsNullOrWhiteSpace(roleName) && roleName != "Все")
        {
            // Если в UI написано "Врачи", а в БД "doctor"
            string dbRole = roleName switch
            {
                "Врачи" => "doctor",
                "Пациенты" => "patient",
                "Админы" => "admin",
                _ => roleName.ToLower()
            };
            query = query.Where(u => u.Role.Name == dbRole);
        }

        // 3. Фильтр по статусу
        if (!string.IsNullOrWhiteSpace(status) && status != "Все")
        {
            bool isActive = (status == "Активные");
            query = query.Where(u => u.IsApproved == isActive);
        }

        return await query.OrderByDescending(u => u.CreatedAt).ToListAsync();
    }
    
    public async Task DeleteUserAsync(int userId)
    {
        try
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var user = await context.users.FindAsync(userId);

            if (user != null)
            {
                user.IsDeleted = true;

                // Генерируем короткий уникальный суффикс, чтобы влезло в 50 символов
                // Формат: DEL_Id_Login (обрезанный)

                string prefix = $"DEL_{user.UserId}_";
                string oldLogin = user.Login;

                // Если логин + префикс длиннее 50, обрезаем старый логин
                if (prefix.Length + oldLogin.Length > 50)
                {
                    oldLogin = oldLogin.Substring(0, 50 - prefix.Length);
                }

                user.Login = prefix + oldLogin;

                await context.SaveChangesAsync();
            }
        }catch (Exception ex) {
            // Поставь точку останова здесь или выведи в лог
            System.Diagnostics.Debug.WriteLine($"CRASH ERROR: {ex.Message}");
            if (ex.InnerException != null)
                System.Diagnostics.Debug.WriteLine($"INNER: {ex.InnerException.Message}");
            throw; // Пробросить дальше, чтобы UI показал Alert
        }
    }
    
    public async Task UpdateUserProfileAsync(int userId, string firstName, string lastName, string middleName)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var user = await context.users.FindAsync(userId);
    
        if (user == null) throw new Exception("Пользователь не найден");

        user.FirstName = firstName;
        user.LastName = lastName;
        user.MiddleName = middleName;
    
        // Важно: Логин и Роль здесь не меняем в целях безопасности
    
        context.users.Update(user);
        await context.SaveChangesAsync();
    }
    
    public async Task<List<user>> SearchPatientsAsync(string query)
    {
        // Используем уже существующую логику фильтрации, но фиксируем роль "Пациенты" и статус "Активные"
        // query - это строка поиска (Фамилия)
        return await GetUsersFilteredAsync(query, "Пациенты", "Активные");
    }
    

// 2. Добавить связь
    public async Task<List<user>> GetDoctorPatientsAsync(int doctorId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        var patientIds = await context.doctor_patient
            .AsNoTracking()
            .Where(dp => dp.DoctorId == doctorId)
            .Select(dp => dp.PatientId)
            .ToListAsync();

        if (patientIds.Count == 0) return new List<user>();

        return await context.users
            .AsNoTracking()
            .Include(u => u.Role)
            .Where(u => patientIds.Contains(u.UserId))
            .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
            .ToListAsync();
    }

    public async Task AddPatientToDoctorListAsync(int doctorId, int patientId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        bool exists = await context.doctor_patient
            .AnyAsync(dp => dp.DoctorId == doctorId && dp.PatientId == patientId);

        if (exists) return;

        context.doctor_patient.Add(new doctor_patient
        {
            DoctorId = doctorId,
            PatientId = patientId,
            AddedAt = DateTime.Now
        });

        await context.SaveChangesAsync();
    }

    public async Task<List<user>> SearchNewPatientsAsync(string query, int excludeDoctorId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        var existing = await context.doctor_patient
            .AsNoTracking()
            .Where(dp => dp.DoctorId == excludeDoctorId)
            .Select(dp => dp.PatientId)
            .ToListAsync();

        string term = query.Trim().ToLower();

        return await context.users
            .AsNoTracking()
            .Include(u => u.Role)
            .Where(u => u.Role.Name == "patient" && (u.IsApproved ?? false))
            .Where(u => !existing.Contains(u.UserId))
            .Where(u =>
                u.LastName.ToLower().Contains(term) ||
                u.FirstName.ToLower().Contains(term) ||
                u.Login.ToLower().Contains(term))
            .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
            .ToListAsync();
    }

}
```

## File: Services/UserSessionService.cs
```csharp
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.Services;

public class UserSessionService : IUserSessionService
{
    public user? CurrentUser { get; private set; }

    public bool IsAuthenticated => CurrentUser != null;
    
    // Если пользователь null, считаем его гостем (если ваша логика подразумевает явный вход как Гость, можно добавить флаг)
    public bool IsGuest => CurrentUser == null;

    public void StartSession(user user)
    {
        CurrentUser = user;
    }

    public void EndSession()
    {
        CurrentUser = null;
    }
}
```

## File: ViewModels/Admin/AdminHomeViewModel.cs
```csharp
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Pages.Admin;
using MedCompatibility.Services.Interfaces;
namespace MedCompatibility.ViewModels.Admin;
public partial class AdminHomeViewModel : ObservableObject
{
    private readonly IUserService _userService;
    private readonly ILoadingService _loading;

    [ObservableProperty] private int patientsCount = 0;
    [ObservableProperty] private int doctorsCount = 0;

    public AdminHomeViewModel(IUserService userService, ILoadingService loading)
    {
        _userService = userService;
        _loading = loading;
    }

    public async Task OnAppearingAsync()
    {
        try
        {
            _loading.Show();
            var patientsTask = _userService.GetPatientsCountAsync();
            var doctorsTask = _userService.GetActiveDoctorsCountAsync();
            await Task.WhenAll(patientsTask, doctorsTask);
            PatientsCount = patientsTask.Result;
            DoctorsCount = doctorsTask.Result;
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert(
                "Ошибка",
                "Не удалось загрузить статистику: " + ex.Message,
                "OK");
        }
        finally
        {
            _loading.Hide();
        }
    }
    [RelayCommand]
    private async Task LogoutAsync()
    {
        var resultObj = await Shell.Current.ShowPopupAsync(
            new Pages.Shared.Popups.ConfirmPopup(
                "Выход",
                "Выйти из аккаунта?",
                okText: "Выйти",
                cancelText: "Отмена"));

        if (resultObj is bool ok && ok)
            await Shell.Current.GoToAsync("//Login");
    }
    [RelayCommand]
    private async Task GoToUsersAsync()
    {
        await Shell.Current.GoToAsync("UsersList");
    }
    [RelayCommand]
    private async Task GoToMedicinesAsync()
    {
        await Shell.Current.GoToAsync(nameof(Pages.Admin.MedicinesListPage));
    }
    [RelayCommand]
    private async Task GoToConflictsAsync()
    {
        await Shell.Current.GoToAsync(nameof(InteractionsListPage));
    }
    [RelayCommand]
    private async Task GoToSystemAsync()
    {
        await Shell.Current.GoToAsync(nameof(SystemLogsPage));
    }
}
```

## File: ViewModels/Admin/InteractionAddViewModel.cs
```csharp
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using MedCompatibility.Pages.Shared.Popups;

namespace MedCompatibility.ViewModels.Admin;

public partial class InteractionAddViewModel : ObservableObject, IQueryAttributable
{
    private readonly IInteractionService _interactionService;
    private readonly IMedicineService _medicineService;
    
    // Задача загрузки справочников, чтобы мы могли её ждать
    private Task _initializationTask; 

    [ObservableProperty]
    private interaction currentInteraction = new();

    // Справочники
    [ObservableProperty]
    private ObservableCollection<interactiontype> types = new();
    
    [ObservableProperty]
    private ObservableCollection<risklevel> risks = new();

    // Выбранные значения
    [ObservableProperty]
    private interactiontype selectedType;

    [ObservableProperty]
    private risklevel selectedRisk;

    [ObservableProperty]
    private activesubstance substance1;

    [ObservableProperty]
    private activesubstance substance2;

    [ObservableProperty]
    private string pageTitle = "Создание конфликта";
    
    [ObservableProperty]
    private string buttonText = "Создать";

    public InteractionAddViewModel(IInteractionService interactionService, IMedicineService medicineService)
    {
        _interactionService = interactionService;
        _medicineService = medicineService;
        
        // Запускаем загрузку сразу, но сохраняем Task
        _initializationTask = LoadDictionariesAsync();
    }

    // Изменили void на Task
    private async Task LoadDictionariesAsync()
    {
        try
        {
            // Если уже загружено - не грузим повторно
            if (Types.Any() && Risks.Any()) return;

            var t = await _interactionService.GetInteractionTypesAsync();
            var r = await _interactionService.GetRiskLevelsAsync();

            // Обновляем UI в главном потоке
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Types = new ObservableCollection<interactiontype>(t);
                Risks = new ObservableCollection<risklevel>(r);
            });
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка загрузки", ex.Message, "OK");
        }
    }

    [RelayCommand]
    private async Task SelectSubstance1Async()
    {
        var popup = new SelectSubstancePopup(_medicineService);
        var result = await Shell.Current.ShowPopupAsync(popup);
        if (result is activesubstance sub) Substance1 = sub;
    }

    [RelayCommand]
    private async Task SelectSubstance2Async()
    {
        var popup = new SelectSubstancePopup(_medicineService);
        var result = await Shell.Current.ShowPopupAsync(popup);
        if (result is activesubstance sub) Substance2 = sub;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (Substance1 == null || Substance2 == null || SelectedType == null || SelectedRisk == null)
        {
            await Shell.Current.DisplayAlert("Ошибка", "Заполните все обязательные поля", "OK");
            return;
        }

        if (Substance1.SubstanceId == Substance2.SubstanceId)
        {
            await Shell.Current.DisplayAlert("Ошибка", "Вещества должны быть разными", "OK");
            return;
        }

        try
        {
            CurrentInteraction.SubstanceId1 = Substance1.SubstanceId;
            CurrentInteraction.SubstanceId2 = Substance2.SubstanceId;
            CurrentInteraction.InteractionTypeId = SelectedType.InteractionTypeId;
            CurrentInteraction.RiskLevelId = SelectedRisk.RiskLevelId;

            if (CurrentInteraction.InteractionId == 0)
            {
                await _interactionService.AddInteractionAsync(
                    CurrentInteraction.SubstanceId1,
                    CurrentInteraction.SubstanceId2,
                    CurrentInteraction.InteractionTypeId,
                    CurrentInteraction.RiskLevelId,
                    CurrentInteraction.Description,
                    CurrentInteraction.Recommendation);
                
                await Shell.Current.DisplayAlert("Успех", "Взаимодействие создано", "OK");
            }
            else
            {
                await _interactionService.UpdateInteractionAsync(CurrentInteraction);
                await Shell.Current.DisplayAlert("Успех", "Изменения сохранены", "OK");
            }

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("InteractionToEdit"))
        {
            var source = query["InteractionToEdit"] as interaction;
            if (source != null)
            {
                await LoadForEdit(source.InteractionId);
            }
        }
    }

    private async Task LoadForEdit(int id)
    {
        // 1. Сначала ждем окончания загрузки справочников!
        await _initializationTask;

        var item = await _interactionService.GetInteractionByIdAsync(id);
        if (item == null) return;

        CurrentInteraction = item;

        Substance1 = item.SubstanceId1Navigation;
        Substance2 = item.SubstanceId2Navigation;

        // 2. Теперь списки точно заполнены, и поиск сработает
        SelectedType = Types.FirstOrDefault(t => t.InteractionTypeId == item.InteractionTypeId);
        SelectedRisk = Risks.FirstOrDefault(r => r.RiskLevelId == item.RiskLevelId);

        PageTitle = "Редактирование";
        ButtonText = "Сохранить изменения";
    }
}
```

## File: ViewModels/Admin/InteractionsListViewModel.cs
```csharp
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Pages.Admin;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Admin;

public partial class InteractionsListViewModel : ObservableObject
{
    private readonly IInteractionService _interactionService;

    [ObservableProperty]
    private ObservableCollection<interaction> interactions = new();

    [ObservableProperty]
    private bool isBusy;

    public InteractionsListViewModel(IInteractionService interactionService)
    {
        _interactionService = interactionService;
    }

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        try
        {
            var list = await _interactionService.GetAllInteractionsAsync();
            Interactions = new ObservableCollection<interaction>(list);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task DeleteInteractionAsync(interaction item)
    {
        if (item == null) return;
        
        bool confirm = await Shell.Current.DisplayAlert("Удаление", 
            $"Удалить взаимодействие {item.SubstanceId1Navigation.Name} + {item.SubstanceId2Navigation.Name}?", 
            "Да", "Нет");

        if (confirm)
        {
            await _interactionService.DeleteInteractionAsync(item.InteractionId);
            await LoadDataAsync();
        }
    }

    // Команда перехода на создание (пока просто заглушка, сделаем попап позже)
    [RelayCommand]
    private async Task GoToAddInteractionAsync()
    {
        await Shell.Current.GoToAsync(nameof(InteractionAddPage));
    }

    [RelayCommand]
    private async Task EditInteractionAsync(interaction item)
    {
        if (item == null) return;
        var navParam = new Dictionary<string, object>
        {
            { "InteractionToEdit", item }
        };
        await Shell.Current.GoToAsync(nameof(InteractionAddPage), navParam);
    }
}
```

## File: ViewModels/Admin/MedicineAddViewModel.cs
```csharp
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using CommunityToolkit.Maui.Views;
using MedCompatibility.Pages.Shared; // CodeScannerPage
using MedCompatibility.Pages.Shared.Popups;

namespace MedCompatibility.ViewModels.Admin;

public partial class MedicineAddViewModel : ObservableObject, IQueryAttributable
{
    private readonly IMedicineService _medicineService;
    private readonly ILoadingService _loading;

    [ObservableProperty]
    private medicine newMedicine = new();

    [ObservableProperty]
    private ObservableCollection<manufacturer> manufacturers = new();

    [ObservableProperty]
    private manufacturer selectedManufacturer;

    [ObservableProperty]
    private ObservableCollection<activesubstance> addedSubstances = new();

    [ObservableProperty]
    private string pageTitle = "Создание препарата";

    [ObservableProperty]
    private string buttonText = "Создать";

    public MedicineAddViewModel(IMedicineService medicineService, ILoadingService loading)
    {
        _medicineService = medicineService;
        _loading = loading;
        LoadData();
    }

    private async void LoadData()
    {
        try
        {
            var list = await _medicineService.GetAllManufacturersAsync();
            Manufacturers = new ObservableCollection<manufacturer>(list);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error loading manufacturers: {ex}");
        }
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(NewMedicine.TradeName) ||
            string.IsNullOrWhiteSpace(NewMedicine.GTIN) ||
            string.IsNullOrWhiteSpace(NewMedicine.INN) ||
            SelectedManufacturer == null)
        {
            return;
        }

        try
        {
            _loading.Show();

            // Проверка дубликата GTIN (только при создании)
            if (NewMedicine.MedicineId == 0)
            {
                if (await _medicineService.ExistsMedicineByGtinAsync(NewMedicine.GTIN))
                {
                    await Shell.Current.DisplayAlert("Ошибка", "Такой штрихкод уже есть в базе", "OK");
                    return;
                }
            }

            NewMedicine.ManufacturerId = SelectedManufacturer.ManufacturerId;
            if (NewMedicine.MedicineId == 0) NewMedicine.IsDeleted = false;

            var subIds = AddedSubstances.Select(s => s.SubstanceId).ToList();

            if (NewMedicine.MedicineId == 0)
            {
                await _medicineService.CreateMedicineAsync(NewMedicine, subIds);
                await Shell.Current.DisplayAlert("Успех", "Лекарство добавлено", "OK");
            }
            else
            {
                await _medicineService.UpdateMedicineAsync(NewMedicine, subIds);
                await Shell.Current.DisplayAlert("Успех", "Изменения сохранены", "OK");
            }

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
        finally
        {
            _loading.Hide();
        }
    }

    [RelayCommand]
    private async Task ScanBarcodeAsync()
    {
        await Shell.Current.GoToAsync(nameof(CodeScannerPage));
    }

    [RelayCommand]
    private async Task AddManufacturerAsync()
    {
        var popup = new AddManufacturerPopup();
        var result = await Shell.Current.ShowPopupAsync(popup);

        if (result is manufacturer manResult)
        {
            try
            {
                var newMan = await _medicineService.CreateManufacturerAsync(
                    manResult.Name,
                    manResult.Country,
                    manResult.City,
                    manResult.Description);

                Manufacturers.Add(newMan);
                SelectedManufacturer = newMan;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }
    }

    [RelayCommand]
    private async Task AddSubstanceAsync()
    {
        var popup = new SelectSubstancePopup(_medicineService);
        var result = await Shell.Current.ShowPopupAsync(popup);

        if (result is activesubstance subResult)
        {
            if (!AddedSubstances.Any(s => s.SubstanceId == subResult.SubstanceId))
                AddedSubstances.Add(subResult);
            else
                await Shell.Current.DisplayAlert("Инфо", "Это вещество уже добавлено", "OK");
        }
    }

    [RelayCommand]
    private void RemoveSubstance(activesubstance sub)
    {
        if (AddedSubstances.Contains(sub)) AddedSubstances.Remove(sub);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        // 1. Результат сканирования (ключ "ScannedCode")
        if (query.ContainsKey("ScannedCode"))
        {
            string code = query["ScannedCode"]?.ToString();
            if (!string.IsNullOrWhiteSpace(code))
            {
                NewMedicine.GTIN = code;
                OnPropertyChanged(nameof(NewMedicine)); // Чтобы UI обновился
            }
        }
        
        // Поддержка старого ключа на всякий случай, если где-то остался
        if (query.ContainsKey("ScanResult"))
        {
            string code = query["ScanResult"]?.ToString();
            if (!string.IsNullOrWhiteSpace(code))
            {
                NewMedicine.GTIN = code;
                OnPropertyChanged(nameof(NewMedicine));
            }
        }

        // 2. Режим редактирования
        if (query.ContainsKey("MedicineToEdit"))
        {
            var source = query["MedicineToEdit"] as medicine;
            if (source != null)
            {
                InitializeEditModeAsync(source.MedicineId);
            }
        }
        
        query.Clear(); // Чистим параметры, чтобы при повторном открытии не сработало лишнего
    }

    private async Task InitializeEditModeAsync(int medicineId)
    {
        try
        {
            _loading.Show();

            if (Manufacturers.Count == 0)
            {
                var mans = await _medicineService.GetAllManufacturersAsync();
                Manufacturers = new ObservableCollection<manufacturer>(mans);
            }

            var fullMedicine = await _medicineService.GetMedicineByIdAsync(medicineId);
            if (fullMedicine == null) return;

            NewMedicine = new medicine
            {
                MedicineId = fullMedicine.MedicineId,
                TradeName = fullMedicine.TradeName,
                INN = fullMedicine.INN,
                Form = fullMedicine.Form,
                GTIN = fullMedicine.GTIN,
                Description = fullMedicine.Description,
                ManufacturerId = fullMedicine.ManufacturerId,
                IsDeleted = fullMedicine.IsDeleted
            };

            SelectedManufacturer = Manufacturers.FirstOrDefault(m => m.ManufacturerId == fullMedicine.ManufacturerId);

            AddedSubstances.Clear();
            if (fullMedicine.Substances != null)
            {
                foreach (var sub in fullMedicine.Substances) AddedSubstances.Add(sub);
            }

            PageTitle = "Редактирование";
            ButtonText = "Сохранить изменения";
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", $"Не удалось загрузить данные: {ex.Message}", "OK");
        }
        finally
        {
            _loading.Hide();
        }
    }
}
```

## File: ViewModels/Admin/MedicinesListViewModel.cs
```csharp
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Admin;

public partial class MedicinesListViewModel : ObservableObject
{
    private readonly IMedicineService _medicineService;
    private readonly ILoadingService _loading; // Твой сервис для Popup

    [ObservableProperty]
    private ObservableCollection<medicine> medicines = new();

    [ObservableProperty]
    private ObservableCollection<string> manufacturers = new();

    [ObservableProperty]
    private string searchText;

    [ObservableProperty]
    private string selectedManufacturer = "Все";

    [ObservableProperty]
    private bool isBusy;

    public MedicinesListViewModel(IMedicineService medicineService, ILoadingService loading)
    {
        _medicineService = medicineService;
        _loading = loading;
    }

    // Инициализация (загрузка фильтров и данных)
    public async Task InitializeAsync()
    {
        if (Manufacturers.Count == 0)
        {
            await LoadManufacturersForFilterAsync();
        }
        await LoadDataAsync();
    }


    [RelayCommand]
    public async Task LoadDataAsync()
    {
        if (IsBusy) return;
        try
        {
            _loading.Show(); // Показываем Popup (если это не RefreshView)
            
            var list = await _medicineService.GetMedicinesFilteredAsync(SearchText, SelectedManufacturer);
            Medicines = new ObservableCollection<medicine>(list);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
        finally
        {
            _loading.Hide();
        }
    }
    
    // Команда для RefreshView
    [RelayCommand]
    public async Task RefreshDataAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        try
        {
            await LoadManufacturersForFilterAsync(); // Обновляем список

            var list = await _medicineService.GetMedicinesFilteredAsync(SearchText, SelectedManufacturer);
            Medicines = new ObservableCollection<medicine>(list);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task ResetFiltersAsync()
    {
        SearchText = string.Empty;
        SelectedManufacturer = "Все";
        await LoadDataAsync();
    }

    [RelayCommand]
    private async Task DeleteMedicineAsync(medicine item)
    {
        if (item == null) return;
        
        bool confirm = await Shell.Current.DisplayAlert("Удаление", $"Удалить {item.TradeName}?", "Да", "Нет");
        if (confirm)
        {
            await _medicineService.DeleteMedicineAsync(item.MedicineId);
            await LoadDataAsync(); // Обновить список
        }
    }
    
    [RelayCommand]
    private async Task EditMedicineAsync(medicine item)
    {
        if (item == null) return;
        
        // Передаем весь объект на страницу добавления
        // Ключ "MedicineToEdit" будет сигналом, что мы в режиме редактирования
        var navParam = new Dictionary<string, object>
        {
            { "MedicineToEdit", item }
        };

        await Shell.Current.GoToAsync(nameof(Pages.Admin.MedicineAddPage), navParam);
    }
    
    // Вспомогательный метод для загрузки и конвертации
    private async Task LoadManufacturersForFilterAsync()
    {
        // Получаем объекты
        var manObjects = await _medicineService.GetAllManufacturersAsync();
        
        // Превращаем в список имен
        var names = manObjects.Select(m => m.Name).ToList();
        
        // Добавляем "Все" в начало
        names.Insert(0, "Все");
        
        Manufacturers = new ObservableCollection<string>(names);
    }
    
    [RelayCommand]
    private async Task GoToAddMedicineAsync()
    {
        await Shell.Current.GoToAsync(nameof(Pages.Admin.MedicineAddPage));
    }

    // Реакция на изменение фильтра
    partial void OnSelectedManufacturerChanged(string value) => LoadDataCommand.Execute(null);
}
```

## File: ViewModels/Admin/SystemLogsViewModel.cs
```csharp
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using System.Collections.ObjectModel;

namespace MedCompatibility.ViewModels.Admin;

public partial class SystemLogsViewModel : ObservableObject
{
    private readonly IScanService _scanService;
    private readonly IDatabaseHealthService _dbHealth;

    [ObservableProperty]
    private ObservableCollection<scan> logs = new();

    [ObservableProperty]
    private bool isBusy;
    
    [ObservableProperty]
    private string dbStatusText;

    [ObservableProperty]
    private Color dbStatusColor;

    public SystemLogsViewModel(IScanService scanService, IDatabaseHealthService dbHealth)
    {
        _scanService = scanService;
        _dbHealth = dbHealth;
    }

    [RelayCommand]
    public async Task LoadLogsAsync()
    {
        if (IsBusy) return;
        IsBusy = true;

        try
        {
            // 1. Обновляем статус БД
            await _dbHealth.CheckAsync();
            if (_dbHealth.IsAvailable)
            {
                DbStatusText = "База данных: Подключено";
                DbStatusColor = Colors.Green;
            }
            else
            {
                DbStatusText = "База данных: Ошибка соединения";
                DbStatusColor = Colors.Red;
            }

            // 2. Грузим логи
            var list = await _scanService.GetAllScansAsync();
            Logs = new ObservableCollection<scan>(list);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
```

## File: ViewModels/Admin/UsersListViewModel.cs
```csharp
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Admin;

public partial class UsersListViewModel : ObservableObject
{
    private readonly IUserService _userService;
    private readonly ILoadingService _loading;

    [ObservableProperty]
    private ObservableCollection<user> users = new();

    [ObservableProperty] 
    private string searchText;

    [ObservableProperty] 
    private string selectedRole = "Все";
    
    [ObservableProperty] 
    private string selectedStatus = "Все";

    public List<string> Roles { get; } = new() { "Все", "Врачи", "Пациенты", "Админы" };
    public List<string> Statuses { get; } = new() { "Все", "Активные", "Заблокированные" };

    public UsersListViewModel(IUserService userService, ILoadingService loading)
    {
        _userService = userService;
        _loading = loading;
    }

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        try
        {
            _loading.Show();
            var list = await _userService.GetUsersFilteredAsync(SearchText, SelectedRole, SelectedStatus);
            Users = new ObservableCollection<user>(list);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
        finally
        {
            _loading.Hide();
        }
    }

    [RelayCommand]
    private async Task DeleteUserAsync(user u)
    {
        if (u == null) return;

        var confirm = await Shell.Current.ShowPopupAsync(
            new Pages.Shared.Popups.ConfirmPopup(
                "Удаление", 
                $"Удалить пользователя {u.Login}?", 
                okText: "Удалить", 
                cancelText: "Отмена"));

        if (confirm is bool ok && ok)
        {
            try
            {
                _loading.Show();
                await _userService.DeleteUserAsync(u.UserId);
                await LoadDataAsync();
            }
            finally
            {
                _loading.Hide();
            }
        }
    }

    [RelayCommand]
    private async Task ToggleStatusAsync(user u)
    {
        if (u == null) return;
        try
        {
            bool newStatus = !(u.IsApproved ?? false);
            await _userService.ToggleUserStatusAsync(u.UserId, newStatus);
            await LoadDataAsync(); // Обновляем список чтобы показать актуальное состояние
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
    }
    
    [RelayCommand]
    private async Task ResetFiltersAsync()
    {
        SearchText = string.Empty;
        SelectedRole = "Все";
        SelectedStatus = "Все";
    
        // Сразу перезагружаем список
        await LoadDataAsync();
    }
    
    // Вызывается при изменении фильтров
    partial void OnSelectedRoleChanged(string value) => LoadDataCommand.Execute(null);
    partial void OnSelectedStatusChanged(string value) => LoadDataCommand.Execute(null);
}
```

## File: ViewModels/Doctor/DoctorHomeViewModel.cs
```csharp
using CommunityToolkit.Maui.Views; // Обязательно для ShowPopupAsync
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Pages.Admin;
using MedCompatibility.Pages.Doctor;
using MedCompatibility.Pages.Patient;
using MedCompatibility.Pages.Shared.Popups; // Тут лежит наш ConfirmPopup
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Doctor;

public partial class DoctorHomeViewModel : ObservableObject
{
    private readonly IUserSessionService _sessionService;
    private readonly ILoadingService _loading;
    // В будущем сюда добавим IUserService или IDoctorService для загрузки реальной статистики

    [ObservableProperty]
    private string welcomeText;

    [ObservableProperty]
    private int patientsCount = 0;

    [ObservableProperty]
    private int prescriptionsCount = 0;

    public DoctorHomeViewModel(IUserSessionService sessionService, ILoadingService loading)
    {
        _sessionService = sessionService;
        _loading = loading;
        UpdateInfo();
    }

    // Метод, который вызывается при открытии страницы (из CodeBehind)
    public async Task OnAppearingAsync()
    {
        UpdateInfo();

        // Пример загрузки статистики (как в Админке). 
        // Пока оставим заглушки или простые значения, 
        // но структура готова для внедрения реальных запросов к БД.
        /*
        try 
        {
            _loading.Show();
            // var stats = await _doctorService.GetStatsAsync();
            // PatientsCount = stats.Patients;
            // PrescriptionsCount = stats.Prescriptions;
        } 
        finally 
        {
            _loading.Hide();
        }
        */
        await Task.CompletedTask; 
    }

    private void UpdateInfo()
    {
        var user = _sessionService.CurrentUser;
        WelcomeText = user != null
            ? $"{user.FirstName} {user.MiddleName}"
            : "Врач";
    }

    [RelayCommand]
    private async Task LogoutAsync()
    {
        // --- ИСПОЛЬЗУЕМ КРАСИВЫЙ ПОПАП ---
        var resultObj = await Shell.Current.ShowPopupAsync(
            new ConfirmPopup(
                "Выход",
                "Вы уверены, что хотите выйти из аккаунта?",
                okText: "Выйти",
                cancelText: "Отмена"));

        if (resultObj is bool ok && ok)
        {
            _sessionService.EndSession();
            await Shell.Current.GoToAsync("//Login");
        }
    }

    [RelayCommand]
    private async Task GoToPatientsAsync()
    {
        await Shell.Current.GoToAsync(nameof(DoctorPatientsPage));
    }

    [RelayCommand]
    private async Task GoToMedicinesAsync()
    {
        await Shell.Current.GoToAsync(nameof(MedicinesListPage));
    }

    [RelayCommand]
    private async Task GoToInteractionsAsync()
    {
        await Shell.Current.GoToAsync(nameof(InteractionsListPage));
    }

    [RelayCommand]
    private async Task GoToProfileAsync()
    {
        await Shell.Current.GoToAsync(nameof(ProfilePage));
    }
}
```

## File: ViewModels/Doctor/DoctorPatientCardViewModel.cs
```csharp
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Pages.Shared;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Doctor;

public partial class DoctorPatientCardViewModel : ObservableObject, IQueryAttributable
{
    private readonly IPrescriptionService _prescriptionService;
    private readonly IInteractionService _interactionService;
    private readonly IMedicineService _medicineService;
    private readonly IScanService _scanService;
    private readonly IUserSessionService _session;

    [ObservableProperty] private user? patient;
    [ObservableProperty] private ObservableCollection<prescription> prescriptions = new();
    [ObservableProperty] private bool isBusy;

    public string PatientFullName =>
        Patient == null ? "" : $"{Patient.LastName} {Patient.FirstName} {Patient.MiddleName}".Trim();

    public string PatientLogin => Patient == null ? "" : $"@{Patient.Login}";

    public DoctorPatientCardViewModel(
        IPrescriptionService prescriptionService,
        IInteractionService interactionService,
        IMedicineService medicineService,
        IScanService scanService,
        IUserSessionService session)
    {
        _prescriptionService = prescriptionService;
        _interactionService = interactionService;
        _medicineService = medicineService;
        _scanService = scanService;
        _session = session;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("SelectedPatient", out var obj) && obj is user u)
        {
            Patient = u;
            OnPropertyChanged(nameof(PatientFullName));
            OnPropertyChanged(nameof(PatientLogin));
        }
    }

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        if (Patient == null || IsBusy) return;

        try
        {
            IsBusy = true;
            var list = await _prescriptionService.GetPatientPrescriptionsAsync(Patient.UserId);
            Prescriptions = new ObservableCollection<prescription>(list);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task AddMedicineAsync()
    {
        if (Patient == null) return;
        var doctor = _session.CurrentUser;
        if (doctor == null) return;

        // Выбор лекарства (у тебя popup уже используется в CompatibilityViewModel) [file:1]
        var popup = new MedicineSelectionPopup(_medicineService, _scanService);
        var result = await Shell.Current.ShowPopupAsync(popup);

        if (result is string action && action == "SCAN")
        {
            await Shell.Current.GoToAsync(nameof(CodeScannerPage));
            return;
        }

        if (result is not medicine selectedMed) return;

        // Берём актуальные назначения и проверяем на конфликты
        var current = await _prescriptionService.GetPatientPrescriptionsAsync(Patient.UserId);
        var allConflicts = new List<interaction>();

        foreach (var p in current)
        {
            if (p.MedicineId == selectedMed.MedicineId) continue;

            var conflicts = await _interactionService.CheckInteractionAsync(p.MedicineId, selectedMed.MedicineId);
            if (conflicts != null && conflicts.Count > 0)
                allConflicts.AddRange(conflicts);
        }

        // Пример правила: Severity >= 3 считаем “критично” (подстрой под свои RiskLevel) [file:1]
        var critical = allConflicts.Any(c => c.RiskLevel?.Severity >= 3);

        if (allConflicts.Any())
        {
            var title = critical ? "Опасная несовместимость" : "Есть взаимодействия";
            var msg = critical
                ? "Найдены критические взаимодействия. Добавить всё равно?"
                : $"Найдены взаимодействия: {allConflicts.Count}. Добавить?";

            var confirm = await Shell.Current.ShowPopupAsync(new ConfirmPopup(title, msg, "Добавить", "Отмена"));
            if (confirm is not bool ok || !ok) return;
        }

        await _prescriptionService.AddPrescriptionAsync(Patient.UserId, doctor.UserId, selectedMed.MedicineId, notes: null);
        await LoadDataAsync();
    }
    
    [RelayCommand]
    private async Task GoBackAsync()
        => await Shell.Current.GoToAsync("..");

    [RelayCommand]
    private async Task LogoutAsync()
    {
        var confirm = await Shell.Current.DisplayAlert("Выход", "Выйти из аккаунта?", "Да", "Нет");
        if (!confirm) return;

        _session.EndSession();
        await Shell.Current.GoToAsync("Login");
    }
}
```

## File: ViewModels/Doctor/DoctorPatientsViewModel.cs
```csharp
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Pages.Doctor;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Doctor;

public partial class DoctorPatientsViewModel : ObservableObject
{
    private readonly IUserService _userService;
    private readonly IUserSessionService _session;

    [ObservableProperty] private ObservableCollection<user> patients = new();
    [ObservableProperty] private bool isLoading;

    public DoctorPatientsViewModel(IUserService userService, IUserSessionService session)
    {
        _userService = userService;
        _session = session;
    }

    [RelayCommand]
    private async Task LoadDataAsync()
    {
        if (IsLoading) return;

        try
        {
            IsLoading = true;

            var doctor = _session.CurrentUser;
            if (doctor == null)
            {
                Patients.Clear();
                return;
            }

            // ВАЖНО: тут должен быть метод "мои пациенты" (по связке doctor-patient).
            var list = await _userService.GetDoctorPatientsAsync(doctor.UserId);
            Patients = new ObservableCollection<user>(list);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private async Task AddPatientAsync()
    {
        var doctor = _session.CurrentUser;
        if (doctor == null) return;

        var popup = new PatientSearchPopup(_userService, _session);
        var result = await Shell.Current.ShowPopupAsync(popup);

        if (result is not user selectedPatient) return;

        await _userService.AddPatientToDoctorListAsync(doctor.UserId, selectedPatient.UserId);
        await LoadDataAsync();
    }

    [RelayCommand]
    private async Task OpenPatientAsync(user patient)
    {
        if (patient == null) return;

        var navParam = new Dictionary<string, object>
        {
            ["SelectedPatient"] = patient
        };

        await Shell.Current.GoToAsync(nameof(DoctorPatientCardPage), navParam);
    }

    [RelayCommand]
    private async Task GoBackAsync()
        => await Shell.Current.GoToAsync("..");

    [RelayCommand]
    private async Task LogoutAsync()
    {
        var confirm = await Shell.Current.DisplayAlert("Выход", "Выйти из аккаунта?", "Да", "Нет");
        if (!confirm) return;

        _session.EndSession();
        await Shell.Current.GoToAsync("Login");
    }
}
```

## File: ViewModels/Patient/CompatibilityViewModel.cs
```csharp
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using MedCompatibility.Pages.Shared;
using MedCompatibility.Pages.Shared.Popups; // Для nameof(CodeScannerPage)

namespace MedCompatibility.ViewModels.Patient;

public partial class CompatibilityViewModel : ObservableObject, IQueryAttributable
{
    private readonly IInteractionService _interactionService;
    private readonly IMedicineService _medicineService;
    private readonly IScanService _scanService;

    // Флаг, чтобы понимать, в какой слот (А или Б) мы сейчас выбираем лекарство
    private bool _isSelectingA; 

    [ObservableProperty]
    private medicine? medicineA;

    [ObservableProperty]
    private medicine? medicineB;

    [ObservableProperty]
    private ObservableCollection<interaction> foundConflicts = new();

    [ObservableProperty]
    private bool isBusy;
    
    [ObservableProperty]
    private bool hasConflicts;

    [ObservableProperty]
    private string statusMessage = "Выберите два лекарства для проверки";

    public CompatibilityViewModel(IInteractionService interactionService, IMedicineService medicineService, IScanService scanService)
    {
        _interactionService = interactionService;
        _medicineService = medicineService;
        _scanService = scanService;
    }

    // --- Обработка результата от сканера ---
    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("ScannedCode"))
        {
            string code = query["ScannedCode"]?.ToString();
            if (!string.IsNullOrWhiteSpace(code))
            {
                // Ищем лекарство по коду
                await LoadMedicineByGtinAsync(code);
            }
        }
        query.Clear();
    }

    private async Task LoadMedicineByGtinAsync(string gtin)
    {
        try
        {
            var med = await _medicineService.GetMedicineByGtinAsync(gtin);
            if (med != null)
            {
                if (_isSelectingA) MedicineA = med;
                else MedicineB = med;
                
                StatusMessage = "Лекарство добавлено. Выберите второе или нажмите Проверить.";
            }
            else
            {
                await Shell.Current.DisplayAlert("Не найдено", $"Лекарство со штрихкодом {gtin} не найдено в базе", "OK");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
    }
    // ---------------------------------------

    [RelayCommand]
    private async Task SelectMedicineAAsync()
    {
        _isSelectingA = true; // Запоминаем, что выбираем для левого слота
        await OpenSelectionMenuAsync();
    }

    [RelayCommand]
    private async Task SelectMedicineBAsync()
    {
        _isSelectingA = false; // Запоминаем, что выбираем для правого слота
        await OpenSelectionMenuAsync();
    }

    private async Task OpenSelectionMenuAsync()
    {
        // Создаем попап, передавая сервисы
        var popup = new MedicineSelectionPopup(_medicineService, _scanService);
        
        // Показываем и ждем результат
        var result = await Shell.Current.ShowPopupAsync(popup);

        if (result is string action && action == "SCAN")
        {
            // Пользователь выбрал сканер внутри попапа
            await Shell.Current.GoToAsync(nameof(CodeScannerPage));
        }
        else if (result is medicine selectedMed)
        {
            // Пользователь выбрал лекарство из списка
            if (_isSelectingA) MedicineA = selectedMed;
            else MedicineB = selectedMed;
            
            StatusMessage = "Лекарство добавлено. Выберите второе.";
            
            // Если оба выбраны - можно сразу проверить (опционально)
            // if (MedicineA != null && MedicineB != null) await CheckAsync();
        }
    }


    [RelayCommand]
    private async Task CheckAsync()
    {
        if (MedicineA == null || MedicineB == null)
        {
            await Shell.Current.DisplayAlert("Внимание", "Выберите оба лекарства для проверки", "OK");
            return;
        }

        if (IsBusy) return;
        IsBusy = true;
        FoundConflicts.Clear();
        HasConflicts = false;

        try
        {
            var results = await _interactionService.CheckInteractionAsync(MedicineA.MedicineId, MedicineB.MedicineId);
            
            if (results.Any())
            {
                FoundConflicts = new ObservableCollection<interaction>(results);
                HasConflicts = true;
                StatusMessage = $"⚠️ Найдено {results.Count} взаимодействий!";
            }
            else
            {
                StatusMessage = "✅ Взаимодействий не найдено. Комбинация безопасна.";
                HasConflicts = false;
            }
        }
        catch (Exception ex)
        {
            StatusMessage = $"Ошибка проверки: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private void Clear()
    {
        MedicineA = null;
        MedicineB = null;
        FoundConflicts.Clear();
        HasConflicts = false;
        StatusMessage = "Выберите два лекарства для проверки";
    }
}
```

## File: ViewModels/Patient/HistoryViewModel.cs
```csharp
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using System.Collections.ObjectModel;
using MedCompatibility.Pages.Patient;

namespace MedCompatibility.ViewModels.Patient;

public partial class HistoryViewModel : ObservableObject
{
    private readonly IScanService _scanService;
    private readonly IUserSessionService _sessionService;

    [ObservableProperty]
    private ObservableCollection<scan> historyItems = new();

    [ObservableProperty]
    private bool isGuest;

    [ObservableProperty]
    private bool isUser;

    [ObservableProperty]
    private bool isBusy;

    public HistoryViewModel(IScanService scanService, IUserSessionService sessionService)
    {
        _scanService = scanService;
        _sessionService = sessionService;
    }

    [RelayCommand]
    public async Task LoadHistoryAsync()
    {
        // 1. Проверяем роль
        IsGuest = _sessionService.IsGuest;
        IsUser = !IsGuest;

        if (IsGuest)
        {
            HistoryItems.Clear();
            return;
        }

        // 2. Если пользователь, грузим историю
        if (IsBusy) return;
        IsBusy = true;

        try
        {
            var list = await _scanService.GetUserHistoryAsync();
            HistoryItems = new ObservableCollection<scan>(list);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", $"Не удалось загрузить историю: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    
    [RelayCommand]
    private async Task GoToLoginAsync()
    {
        // Если гость нажал "Войти" -> кидаем его на страницу входа
        // Используем абсолютный путь, чтобы сбросить навигационный стек или просто на Login
        await Shell.Current.GoToAsync("//Login");
    }
    
    [RelayCommand]
    private async Task GoToDetailsAsync(scan historyItem)
    {
        if (historyItem?.Medicine == null) return;

        var navParam = new Dictionary<string, object>
        {
            { "Medicine", historyItem.Medicine }
        };

        await Shell.Current.GoToAsync(nameof(MedicineDetailsPage), navParam);
    }
}
```

## File: ViewModels/Patient/MedicineDetailsViewModel.cs
```csharp
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces; // Добавляем using

namespace MedCompatibility.ViewModels.Patient;

public partial class MedicineDetailsViewModel : ObservableObject, IQueryAttributable
{
    private readonly IMedicineService _medicineService; // Добавляем сервис

    [ObservableProperty]
    private medicine selectedMedicine;

    [ObservableProperty]
    private string substancesText;
    
    [ObservableProperty]
    private bool isLoading;

    // Внедряем сервис через конструктор
    public MedicineDetailsViewModel(IMedicineService medicineService)
    {
        _medicineService = medicineService;
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("Medicine"))
        {
            var initialMed = query["Medicine"] as medicine;
            if (initialMed != null)
            {
                // Сначала показываем то, что есть (чтобы экран не был пустым)
                SelectedMedicine = initialMed;
                UpdateSubstancesText(); // Попытаемся отобразить вещества, если они есть

                // А теперь подгружаем ПОЛНЫЕ данные из базы (Manufacturer, Substances)
                await LoadFullDetailsAsync(initialMed.MedicineId);
            }
        }
    }

    private async Task LoadFullDetailsAsync(int medicineId)
    {
        try
        {
            IsLoading = true;
            // Используем метод получения по ID, который должен делать Include
            var fullMed = await _medicineService.GetMedicineByIdAsync(medicineId);
            
            if (fullMed != null)
            {
                SelectedMedicine = fullMed;
                UpdateSubstancesText();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error loading details: {ex.Message}");
        }
        finally
        {
            IsLoading = false;
        }
    }

    private void UpdateSubstancesText()
    {
        if (SelectedMedicine?.Substances != null && SelectedMedicine.Substances.Any())
        {
            SubstancesText = string.Join(", ", SelectedMedicine.Substances.Select(s => s.Name));
        }
        else
        {
            SubstancesText = "Нет данных";
        }
    }

    [RelayCommand]
    private async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}
```

## File: ViewModels/Patient/ProfileViewModel.cs
```csharp
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Patient;

public partial class ProfileViewModel : ObservableObject
{
    private readonly IUserSessionService _sessionService;
    private readonly IUserService _userService; // Добавляем сервис для сохранения

    [ObservableProperty]
    private string fullName;

    [ObservableProperty]
    private string roleName;

    [ObservableProperty]
    private bool isGuest;

    [ObservableProperty]
    private bool isUser;

    // --- Поля для редактирования ---
    [ObservableProperty]
    private string editFirstName;
    
    [ObservableProperty]
    private string editLastName;
    
    [ObservableProperty]
    private string editMiddleName;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotEditing))] // Чтобы инвертировать видимость
    private bool isEditing;

    public bool IsNotEditing => !IsEditing;
    // -------------------------------

    public ProfileViewModel(IUserSessionService sessionService, IUserService userService)
    {
        _sessionService = sessionService;
        _userService = userService;
    }

    [RelayCommand]
    public void LoadProfile()
    {
        IsGuest = _sessionService.IsGuest;
        IsUser = !IsGuest;
        IsEditing = false; // Сбрасываем режим редактирования при входе

        if (IsUser && _sessionService.CurrentUser != null)
        {
            var user = _sessionService.CurrentUser;
            
            // Заполняем отображение
            FullName = $"{user.LastName} {user.FirstName} {user.MiddleName}".Trim();
            RoleName = user.Role?.Description ?? "Пользователь";

            // Заполняем поля для возможного редактирования
            EditFirstName = user.FirstName;
            EditLastName = user.LastName;
            EditMiddleName = user.MiddleName;
        }
        else
        {
            FullName = "Гость";
            RoleName = "Ограниченный доступ";
        }
    }

    [RelayCommand]
    private void StartEditing()
    {
        IsEditing = true;
    }

    [RelayCommand]
    private void CancelEditing()
    {
        // Возвращаем старые значения
        LoadProfile(); 
    }

    [RelayCommand]
    private async Task SaveChangesAsync()
    {
        if (IsGuest) return;
        
        if (string.IsNullOrWhiteSpace(EditFirstName) || string.IsNullOrWhiteSpace(EditLastName))
        {
            await Shell.Current.DisplayAlert("Ошибка", "Имя и Фамилия обязательны", "OK");
            return;
        }

        try
        {
            var currentUser = _sessionService.CurrentUser;
            if (currentUser == null) return;

            // 1. Сохраняем в БД
            await _userService.UpdateUserProfileAsync(currentUser.UserId, EditFirstName, EditLastName, EditMiddleName);

            // 2. Обновляем локальную сессию (объект в памяти)
            currentUser.FirstName = EditFirstName;
            currentUser.LastName = EditLastName;
            currentUser.MiddleName = EditMiddleName;
            
            // 3. Обновляем UI
            LoadProfile(); // Перезагрузит FullName и сбросит IsEditing
            
            await Shell.Current.DisplayAlert("Успех", "Данные обновлены", "OK");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", $"Не удалось сохранить: {ex.Message}", "OK");
        }
    }

    [RelayCommand]
    private async Task LogoutAsync()
    {
        bool confirm = await Shell.Current.DisplayAlert("Выход", "Вы уверены, что хотите выйти?", "Да", "Нет");
        if (!confirm) return;

        _sessionService.EndSession();
        await Shell.Current.GoToAsync("//Login");
    }
    
    [RelayCommand]
    private async Task GoToLoginAsync()
    {
        await Shell.Current.GoToAsync("//Login");
    }
}
```

## File: ViewModels/Patient/ScanPageViewModel.cs
```csharp
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Pages.Shared; // Тут твой CodeScannerPage
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Patient;

public partial class ScanPageViewModel : ObservableObject, IQueryAttributable
{
    private readonly IMedicineService _medicineService;
    private readonly IScanService _scanService;

    [ObservableProperty]
    private string searchQuery;

    [ObservableProperty]
    private medicine foundMedicine;

    [ObservableProperty]
    private bool isMedicineVisible;

    [ObservableProperty]
    private bool isNotFoundVisible;

    [ObservableProperty]
    private string statusMessage;

    public ScanPageViewModel(IMedicineService medicineService, IScanService scanService)
    {
        _medicineService = medicineService;
        _scanService = scanService;
    }

    // Принимает результат от CodeScannerPage
    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("ScannedCode"))
        {
            string code = query["ScannedCode"]?.ToString();
            if (!string.IsNullOrWhiteSpace(code))
            {
                SearchQuery = code;
                await SearchAsync();
            }
        }
    }

    [RelayCommand]
    private async Task SearchAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery)) return;

        FoundMedicine = null;
        IsMedicineVisible = false;
        IsNotFoundVisible = false;
        StatusMessage = string.Empty;

        try
        {
            var medicine = await _medicineService.GetMedicineByGtinAsync(SearchQuery);
            // Если нужно по имени: if (medicine == null) medicine = await _medicineService.GetMedicineByNameAsync(SearchQuery);

            if (medicine != null)
            {
                FoundMedicine = medicine;
                IsMedicineVisible = true;
                await _scanService.LogScanAsync(medicine.MedicineId);
            }
            else
            {
                IsNotFoundVisible = true;
                StatusMessage = "Лекарство не найдено в базе данных.";
            }
        }
        catch (Exception ex)
        {
            StatusMessage = $"Ошибка поиска: {ex.Message}";
            IsNotFoundVisible = true;
        }
    }

    [RelayCommand]
    private async Task ScanBarcodeAsync()
    {
        // Переходим на страницу камеры
        await Shell.Current.GoToAsync(nameof(CodeScannerPage));
    }
}
```

## File: ViewModels/Shared/GoogleOAuthTest.cs
```csharp
using Microsoft.Maui.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class GoogleOAuthTest
{
    const string ClientId = "285954249476-6ofmkkjb4m6n8qs6bdd4chht713n4hd8.apps.googleusercontent.com";
    static readonly Uri CallbackUri =
        new("com.googleusercontent.apps.285954249476-6ofmkkjb4m6n8qs6bdd4chht713n4hd8:/oauth2redirect");

    
    public class GoogleTokenResponse
    {
        [JsonPropertyName("access_token")] public string AccessToken { get; set; } = "";
        [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
        [JsonPropertyName("token_type")] public string TokenType { get; set; } = "";
        [JsonPropertyName("scope")] public string Scope { get; set; } = "";
        [JsonPropertyName("id_token")] public string IdToken { get; set; } = "";
        [JsonPropertyName("refresh_token")] public string? RefreshToken { get; set; }
    }
    
    public sealed class GoogleIdTokenPayload
    {
        public string? sub { get; set; }           // стабильный Google user id
        public string? email { get; set; }
        public bool email_verified { get; set; }
        public string? name { get; set; }
        public string? given_name { get; set; }
        public string? family_name { get; set; }
        public string? picture { get; set; }
        public string? aud { get; set; }
        public string? iss { get; set; }
        public long exp { get; set; }
    }
    
    public static async Task<string?> GetAuthCodeAsync(TimeSpan? timeout = null)
    {
        timeout ??= TimeSpan.FromSeconds(60);

        var verifier = CreateCodeVerifier();
        var challenge = CreateCodeChallenge(verifier);

        await SecureStorage.SetAsync("pkce_verifier", verifier);

        var authUrl =
            "https://accounts.google.com/o/oauth2/v2/auth" +
            $"?client_id={Uri.EscapeDataString(ClientId)}" +
            $"&redirect_uri={Uri.EscapeDataString(CallbackUri.ToString())}" +
            $"&response_type=code" +
            $"&scope={Uri.EscapeDataString("openid email profile")}" +
            $"&code_challenge={Uri.EscapeDataString(challenge)}" +
            $"&code_challenge_method=S256" +
            $"&prompt=select_account";

        try
        {
            var authTask = WebAuthenticator.Default.AuthenticateAsync(new Uri(authUrl), CallbackUri);

            var completed = await Task.WhenAny(authTask, Task.Delay(timeout.Value));
            if (completed != authTask)
                return null;

            var result = await authTask;
            return result.Properties.TryGetValue("code", out var code) ? code : null;
        }
        catch (TaskCanceledException)
        {
            return null;
        }
        catch (OperationCanceledException)
        {
            return null;
        }
    }


    static string CreateCodeVerifier()
        => Convert.ToBase64String(RandomNumberGenerator.GetBytes(32))
            .TrimEnd('=').Replace('+', '-').Replace('/', '_');

    static string CreateCodeChallenge(string verifier)
    {
        var bytes = SHA256.HashData(Encoding.ASCII.GetBytes(verifier));
        return Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
    }
    
    public static async Task<GoogleTokenResponse> ExchangeCodeAsync(string code)
    {
        var verifier = await SecureStorage.GetAsync("pkce_verifier");
        if (string.IsNullOrWhiteSpace(verifier))
            throw new Exception("PKCE verifier not found");

        using var http = new HttpClient();

        var resp = await http.PostAsync(
            "https://oauth2.googleapis.com/token",
            new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["client_id"] = ClientId,
                ["code"] = code,
                ["code_verifier"] = verifier,
                ["redirect_uri"] = CallbackUri.ToString(), // важно: exact match [web:219]
                ["grant_type"] = "authorization_code",
            }));

        var json = await resp.Content.ReadAsStringAsync();
        if (!resp.IsSuccessStatusCode)
            throw new Exception(json);

        return JsonSerializer.Deserialize<GoogleTokenResponse>(json)!;
    }
    
    public static GoogleIdTokenPayload ParseIdToken(string idToken)
    {
        var parts = idToken.Split('.');
        if (parts.Length < 2) throw new Exception("Invalid JWT");

        var json = Base64UrlDecodeToString(parts[1]);
        return JsonSerializer.Deserialize<GoogleIdTokenPayload>(json)!;
    }

    static string Base64UrlDecodeToString(string input)
    {
        input = input.Replace('-', '+').Replace('_', '/');
        switch (input.Length % 4)
        {
            case 2: input += "=="; break;
            case 3: input += "="; break;
        }
        var bytes = Convert.FromBase64String(input);
        return Encoding.UTF8.GetString(bytes);
    }
}
```

## File: ViewModels/Shared/LoginViewModel.cs
```csharp
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Shared;

public partial class LoginViewModel : ObservableObject
{
    
    private readonly IDatabaseHealthService _dbHealth;
    private readonly IAuthService _authService;
    private readonly ILoadingService _loading;
    private readonly IUserSessionService _sessionService;
    private int _googleAttemptId;
    private CancellationTokenSource? _googleUiCts;

    [ObservableProperty] private string login = string.Empty;
    [ObservableProperty] private string password = string.Empty;

    [ObservableProperty] private string errorMessage = string.Empty;
    [ObservableProperty] private bool isErrorVisible;

    [ObservableProperty] private bool isDbWarningVisible;
    [ObservableProperty] private string? dbWarningText;
    [ObservableProperty] private bool isDbAvailable = true;

    [ObservableProperty] private bool isPasswordHidden = true;
    [ObservableProperty] private string eyeIconText = "🙈";
    [ObservableProperty] private bool isAuthInProgress;

    public LoginViewModel(
        IAuthService authService,
        IDatabaseHealthService dbHealth,
        ILoadingService loading,
        IUserSessionService sessionService)
    {
        _authService = authService;
        _dbHealth = dbHealth;
        _loading = loading;
        _sessionService = sessionService;
    }

    public async Task OnAppearingAsync()
    {
        try
        {
            _loading.Show();

            await _dbHealth.CheckAsync();

            IsDbAvailable = _dbHealth.IsAvailable;
            IsDbWarningVisible = !_dbHealth.IsAvailable;
            DbWarningText = _dbHealth.LastErrorShort;
        }
        finally
        {
            _loading.Hide();
        }
    }

    [RelayCommand]
    private async Task ShowDbDetailsAsync()
    {
        var shortMsg = _dbHealth.LastErrorShort ?? "База данных сейчас недоступна.";
        var details = _dbHealth.LastErrorDetails ?? "Детали недоступны (ошибка не была получена).";

        await Shell.Current.ShowPopupAsync(new DbUnavailablePopup(shortMsg, details));
    }

    private void ShowInlineError(string message)
    {
        ErrorMessage = message;
        IsErrorVisible = true;
    }

    /// <returns>true если вход/переход надо остановить (статус обработан)</returns>
    private async Task<bool> HandleNotApprovedAsync(MedCompatibility.Models.user user)
    {
        var role = user.Role?.Name?.ToLower();

        // 1) Врач: ожидает подтверждения
        if (role == "doctor" && user.IsApproved != true)
        {
            // UI через popup
            try
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Shell.Current.ShowPopupAsync(new ApprovalPendingPopup());
                });
            }
            catch
            {
                // fallback
                await Shell.Current.DisplayAlert(
                    "Заявка отправлена",
                    "Аккаунт врача создан и ожидает подтверждения администратором.",
                    "OK");
            }

            return true;
        }

        // 2) Пациент: считаем IsApproved=false как "заблокирован"
        if (role == "patient" && user.IsApproved != true)
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await Shell.Current.ShowPopupAsync(new PatientBlockedPopup());
            });

            return true;
        }

        return false;
    }

    private async Task NavigateByRoleAsync(string? roleName)
    {
        roleName = roleName?.ToLower();

        if (roleName == "admin")
            await Shell.Current.GoToAsync("//Admin");
        else if (roleName == "doctor")
            await Shell.Current.GoToAsync("//Doctor");
        else
            await Shell.Current.GoToAsync("//Patient");
    }

    [RelayCommand]
    private async Task LoginAsync()
    {
        try
        {
            _loading.Show();
            IsErrorVisible = false;

            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
                return;

            if (!_dbHealth.IsAvailable)
                await _dbHealth.CheckAsync();

            if (!_dbHealth.IsAvailable)
            {
                ShowInlineError("База данных недоступна. Попробуйте позже или войдите как гость.");
                return;
            }

            var user = await _authService.LoginAsync(Login, Password);

            if (user == null)
            {
                ShowInlineError("Неверный логин или пароль");
                return;
            }

            // ВАЖНО: статус проверяем ДО StartSession
            if (await HandleNotApprovedAsync(user))
                return;

            _sessionService.StartSession(user);

            await NavigateByRoleAsync(user.Role?.Name);

            // очистка после успешного входа
            Login = string.Empty;
            Password = string.Empty;
            IsErrorVisible = false;
        }
        catch (Exception ex)
        {
            ShowInlineError("Ошибка входа: " + ex.Message);
        }
        finally
        {
            _loading.Hide();
        }
    }
    

[RelayCommand]
private async Task GoogleLoginAsync()
{
    if (IsAuthInProgress)
        return;

    IsAuthInProgress = true;

    // id попытки (чтобы игнорировать "долетающие" результаты)
    var attemptId = Interlocked.Increment(ref _googleAttemptId);

    // отменяем предыдущую попытку на уровне UI
    _googleUiCts?.Cancel();
    _googleUiCts?.Dispose();
    _googleUiCts = new CancellationTokenSource();

    var uiCt = _googleUiCts.Token;

    try
    {
        _loading.Show();
        IsErrorVisible = false;

        var authTask = GoogleOAuthTest.GetAuthCodeAsync();
        var timeoutTask = Task.Delay(TimeSpan.FromSeconds(60), uiCt);

        var completed = await Task.WhenAny(authTask, timeoutTask);

        // если пришла новая попытка — просто выходим
        if (attemptId != _googleAttemptId)
            return;

        // таймаут или явная отмена UI
        if (completed != authTask || uiCt.IsCancellationRequested)
        {
            if (_loading.IsShown)
                _loading.Hide();

            await Task.Delay(50);
            await Shell.Current.DisplayAlert("Google", "Авторизация отменена или не завершена.", "OK");
            return;
        }

        // authTask завершился
        var code = await authTask;

        if (attemptId != _googleAttemptId)
            return;

        if (string.IsNullOrWhiteSpace(code))
            return;

        var tokens = await GoogleOAuthTest.ExchangeCodeAsync(code);
        var payload = GoogleOAuthTest.ParseIdToken(tokens.IdToken);

        var email = payload.email;
        var sub = payload.sub;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(sub))
            throw new Exception("Google token has no email/sub");

        var user = await _authService.LoginAsync(email, sub);

        if (attemptId != _googleAttemptId)
            return;

        if (user == null)
        {
            if (_loading.IsShown)
                _loading.Hide();

            await Task.Delay(50);

            var popupResult = await Shell.Current.ShowPopupAsync(new ChooseRolePopup());
            var role = popupResult as string;
            if (role is null)
                return;

            _loading.Show();

            var regError = await _authService.RegisterUserAsync(
                login: email,
                password: sub,
                firstName: payload.given_name ?? "Google",
                lastName: payload.family_name ?? "User",
                middleName: "",
                roleName: role);

            if (regError != null)
                throw new Exception(regError);

            user = await _authService.LoginAsync(email, sub);
        }

        if (attemptId != _googleAttemptId)
            return;

        if (user == null)
            throw new Exception("Не удалось войти после регистрации.");

        if (await HandleNotApprovedAsync(user))
        {
            _sessionService.EndSession();
            return;
        }

        _sessionService.StartSession(user);
        await NavigateByRoleAsync(user.Role?.Name);
    }
    catch (OperationCanceledException)
    {
        // нормально: отменили UI/таймаут
    }
    catch (Exception ex)
    {
        if (attemptId != _googleAttemptId)
            return;

        await Shell.Current.DisplayAlert("Google login error", ex.Message, "OK");
    }
    finally
    {
        // закрываем лоадер только для актуальной попытки
        if (attemptId == _googleAttemptId && _loading.IsShown)
            _loading.Hide();

        IsAuthInProgress = false;
    }
}




    [RelayCommand]
    private async Task GoToRegisterAsync()
    {
        await Shell.Current.GoToAsync(nameof(Pages.Shared.RegisterPage));
    }

    [RelayCommand]
    private async Task GuestLoginAsync()
    {
        _sessionService.EndSession();
        await Shell.Current.GoToAsync("//Patient");
    }

    [RelayCommand]
    private void TogglePasswordVisibility()
    {
        IsPasswordHidden = !IsPasswordHidden;
        EyeIconText = IsPasswordHidden ? "🙈" : "🙉";
    }
    
    public void CancelGoogleAuthUiFromPage()
    {
        // отменяем "ожидание" в GoogleLoginAsync (если ты завязал Delay на этот токен)
        _googleUiCts?.Cancel();

        // и гарантированно закрываем popup-лоадер
        _loading.Hide();

        IsAuthInProgress = false;
    }
    
}
```

## File: ViewModels/Shared/RegisterViewModel.cs
```csharp
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Shared;

public partial class RegisterViewModel : ObservableObject
{
    private readonly IAuthService _authService;
    private readonly ILoadingService _loading;

    [ObservableProperty] private string firstName;
    [ObservableProperty] private string lastName;
    [ObservableProperty] private string middleName;
    [ObservableProperty] private string login;
    [ObservableProperty] private string password;
    [ObservableProperty] private string confirmPassword;
    [ObservableProperty] private string errorMessage;
    [ObservableProperty] private bool isErrorVisible;

    // --- Добавляем выбор роли ---
    [ObservableProperty]
    private List<string> availableRoles = new() { "Пациент", "Врач" };

    [ObservableProperty]
    private string selectedRole = "Пациент"; // По умолчанию
    // ----------------------------

    public RegisterViewModel(IAuthService authService, ILoadingService loading)
    {
        _authService = authService;
        _loading = loading;
    }

    [RelayCommand]
    private async Task RegisterAsync()
    {
        IsErrorVisible = false;

        // 1. Валидация
        if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || 
            string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
        {
            ShowError("Заполните все обязательные поля");
            return;
        }

        if (Password != ConfirmPassword)
        {
            ShowError("Пароли не совпадают");
            return;
        }

        if (Password.Length < 4) // Чуть ослабил для удобства тестов, можешь вернуть 6
        {
            ShowError("Пароль слишком короткий");
            return;
        }

        try
        {
            _loading.Show(); 

            // Определяем роль для БД (UI "Врач" -> DB "Doctor")
            // Если у тебя в БД роль называется "doctor" (маленькими), пиши тут "doctor"
            string dbRoleName = SelectedRole == "Врач" ? "Doctor" : "Patient";

            // Вызываем НОВЫЙ метод RegisterUserAsync
            string error = await _authService.RegisterUserAsync(Login, Password, FirstName, LastName, MiddleName, dbRoleName);

            if (error != null)
            {
                ShowError(error);
                return; 
            }

            // Успех
            if (dbRoleName == "Doctor")
            {
                await Shell.Current.ShowPopupAsync(new ApprovalPendingPopup());
                await Shell.Current.GoToAsync(".."); // обратно на логин как и было
                return;
            }
            else
            {
                await Shell.Current.DisplayAlert("Успех", "Аккаунт создан!", "OK");
            }
            
            await Shell.Current.GoToAsync(".."); 
        }
        catch (Exception ex)
        {
            ShowError("Ошибка: " + ex.Message);
        }
        finally
        {
            _loading.Hide();
        }
    }

    [RelayCommand]
    private async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }

    private void ShowError(string message)
    {
        ErrorMessage = message;
        IsErrorVisible = true;
    }
}
```
