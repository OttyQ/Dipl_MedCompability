using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IAiInteractionService
{
    /// <summary>
    /// Независимый ИИ-анализ совместимости переданных препаратов через Anthropic API.
    /// Не бросает исключений наружу — при ошибке возвращает понятное сообщение.
    /// </summary>
    Task<string> AnalyzeInteractionsAsync(IEnumerable<medicine> medicines);
}
