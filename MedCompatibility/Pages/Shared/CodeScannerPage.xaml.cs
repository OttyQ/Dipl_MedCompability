using System.ComponentModel;
using System.Runtime.CompilerServices;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace MedCompatibility.Pages.Shared;

public partial class CodeScannerPage : ContentPage, INotifyPropertyChanged
{
    private bool _isFlashlightOn;
    public bool IsFlashlightOn
    {
        get => _isFlashlightOn;
        set
        {
            if (_isFlashlightOn != value)
            {
                _isFlashlightOn = value;
                OnPropertyChanged();
                UpdateFlashlightAppearance();
            }
        }
    }

    public bool IsFlashlightSupported => DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS;

    public CodeScannerPage()
    {
        InitializeComponent();
        BindingContext = this;
        
        BarcodeReader.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormat.Ean13 | BarcodeFormat.QrCode, 
            AutoRotate = true,
            Multiple = false
        };

        UpdateFlashlightAppearance();
    }

    private void UpdateFlashlightAppearance()
    {
        if (IsFlashlightOn)
        {
            FlashlightBorder.BackgroundColor = Colors.White;
            FlashlightIcon.Text = "💡";
            FlashlightBorder.Shadow = new Shadow { Brush = Brush.White, Opacity = 0.5f, Radius = 10, Offset = new Point(0, 0) };
        }
        else
        {
            FlashlightBorder.BackgroundColor = Color.FromRgba("#80000000");
            FlashlightIcon.Text = "💡";
            FlashlightBorder.Shadow = null;
        }
    }

    /// <summary>Гасит фонарик, если он включён. Безопасен для вызова в любом контексте.</summary>
    private void TurnOffFlashlight()
    {
        if (IsFlashlightOn)
            IsFlashlightOn = false;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        // Защитный слой: гасим фонарик при любом уходе со страницы
        TurnOffFlashlight();
    }

    private void OnToggleFlashlightClicked(object sender, EventArgs e)
    {
        try
        {
            if (IsFlashlightSupported)
            {
                IsFlashlightOn = !IsFlashlightOn;
            }
        }
        catch (Exception)
        {
            // Игнорируем исключения, если на устройстве проблемы с доступом к вспышке
        }
    }

    private void BarcodeReader_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        var first = e.Results?.FirstOrDefault();
        if (first is null) return;

        BarcodeReader.IsDetecting = false;

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            TurnOffFlashlight();

            var navigationParameter = new Dictionary<string, object>
            {
                { "ScannedCode", first.Value }
            };

            await Shell.Current.GoToAsync("..", navigationParameter);
        });
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        TurnOffFlashlight();
        await Shell.Current.GoToAsync("..");
    }
}