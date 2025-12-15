namespace MedCompatibility.Services.Interfaces;

public interface IDatabaseHealthService
{
    bool IsAvailable { get; }
    string? LastErrorShort { get; }
    string? LastErrorDetails { get; }

    Task CheckAsync(CancellationToken ct = default);
}