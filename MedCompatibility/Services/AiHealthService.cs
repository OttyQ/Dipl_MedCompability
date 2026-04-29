using MedCompatibility.Services.Interfaces;
using System.Diagnostics;

namespace MedCompatibility.Services;

public class AiHealthService : IAiHealthService
{
    public bool IsAvailable { get; private set; }
    public long Latency { get; private set; }
    public string? LastError { get; private set; }

    public async Task CheckAsync()
    {
        LastError = null;

        try
        {
            var sw = Stopwatch.StartNew();

            // Заглушка: имитируем пинг до ИИ-эндпоинта.
            // Когда будет реальный эндпоинт — заменить на HTTP-пинг.
            var rng = new Random();
            await Task.Delay(rng.Next(80, 200));

            sw.Stop();
            Latency = sw.ElapsedMilliseconds;
            IsAvailable = true;
        }
        catch (Exception ex)
        {
            IsAvailable = false;
            Latency = -1;
            LastError = ex.Message;
        }
    }
}
