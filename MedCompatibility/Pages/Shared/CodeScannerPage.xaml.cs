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