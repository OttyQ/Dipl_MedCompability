namespace MedCompatibility.Services.Interfaces;

public interface IAiHealthService
{
    bool IsAvailable { get; }
    long Latency { get; }
    string? LastError { get; }
    Task CheckAsync();
}
