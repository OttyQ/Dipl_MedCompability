using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MedCompatibility.Services;

public class AiInteractionService : IAiInteractionService
{
    private readonly string _apiKey;
    
    // 1. Изменяем URL на OpenRouter (он использует формат OpenAI)
    private const string ApiUrl = "https://openrouter.ai/api/v1/chat/completions";
    
    // 2. Указываем бесплатную модель Qwen 2.5 (72 миллиарда параметров — очень умная)
    private const string Model = "openai/gpt-oss-120b:free";

    private const string SystemPrompt =
        "Ты — клинический фармаколог-ассистент. Проведи независимый анализ совместимости препаратов.\n" +
        "ОБЯЗАТЕЛЬНЫЕ ПРАВИЛА ФОРМАТИРОВАНИЯ: Отвечай только чистым текстом. КАТЕГОРИЧЕСКИ ЗАПРЕЩЕНО использовать Markdown (никаких таблиц с символом |, никаких звездочек ** для жирного шрифта, никаких решеток ###).\n" +
        "Для каждой выявленной пары используй ровно такую структуру:\n" +
        "ПАРА: [Названия препаратов]\n" +
        "ТИП: [Тип взаимодействия]\n" +
        "РИСК: [Низкий / Средний / Высокий]\n" +
        "МЕХАНИЗМ: [Краткое описание]\n" +
        "РЕКОМЕНДАЦИЯ: [Рекомендация врачу]\n\n" +
        "Если взаимодействий нет — явно укажи это. Отвечай только на русском языке.";

    public AiInteractionService(IConfiguration configuration)
    {
        _apiKey = configuration["AI:ApiKey"] ?? string.Empty;
    }

    public async Task<string> AnalyzeInteractionsAsync(IEnumerable<medicine> medicines)
    {
        System.Diagnostics.Debug.WriteLine("AiInteractionService: Building request...");
        
        if (string.IsNullOrWhiteSpace(_apiKey))
            return "⚠️ API-ключ для ИИ-анализа не настроен.";

        var medicineList = medicines.ToList();
        if (medicineList.Count < 2)
            return "Для анализа необходимо минимум 2 препарата.";

        var sb = new StringBuilder();
        sb.AppendLine("Препараты пациента:");
        foreach (var med in medicineList)
        {
            var substancesText = med.Substances != null && med.Substances.Any()
                ? string.Join(", ", med.Substances.Select(s => s.Name))
                : "нет данных";
            sb.AppendLine($"- {med.TradeName} (МНН: {med.INN ?? "нет данных"}, вещества: {substancesText})");
        }
        var userMessage = sb.ToString();

        try
        {
            using var client = new HttpClient();
            
            // 3. Формат авторизации OpenAI (Bearer token)
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            
            // OpenRouter просит эти заголовки для статистики (можно написать что угодно)
            client.DefaultRequestHeaders.Add("HTTP-Referer", "http://localhost");
            client.DefaultRequestHeaders.Add("X-Title", "MedCompatibility App");

            // 4. Формат тела запроса OpenAI
            var requestBody = new
            {
                model = Model,
                messages = new[]
                {
                    new { role = "system", content = SystemPrompt },
                    new { role = "user", content = userMessage }
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            System.Diagnostics.Debug.WriteLine("AiInteractionService: Sending request to OpenRouter...");
            var response = await client.PostAsync(ApiUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"AiInteractionService: API ERROR: {errorBody}");
                return $"⚠️ Ошибка API ({(int)response.StatusCode})";
            }

            var responseJson = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseJson);

            // 5. Парсинг ответа в формате OpenAI: { "choices": [{ "message": { "content": "..." } }] }
            var text = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return text ?? "ИИ вернул пустой ответ.";
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"AiInteractionService EXCEPTION: {ex.Message}");
            return $"⚠️ Ошибка: {ex.Message}";
        }
    }
}