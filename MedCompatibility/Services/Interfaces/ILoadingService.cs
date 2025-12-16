namespace MedCompatibility.Services.Interfaces;

public interface ILoadingService
{
    void Show();
    void Hide();
    bool IsShown { get; }
}
