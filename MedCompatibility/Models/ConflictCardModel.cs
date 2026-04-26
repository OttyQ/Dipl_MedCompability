namespace MedCompatibility.Models;

/// <summary>
/// Правка 3: Обёртка над interaction для отображения в InteractionsDetailsPopup.
/// Хранит метаданные остаточного эффекта рядом с данными взаимодействия.
/// </summary>
public class ConflictCardModel
{
    public interaction Interaction { get; init; } = null!;

    /// <summary>True — препарат уже завершён, но находится в 14-дневном окне остаточного эффекта.</summary>
    public bool IsResidual { get; init; }

    /// <summary>Количество дней с момента завершения назначения (если IsResidual = true).</summary>
    public int DaysAgoEnded { get; init; }

    // --- Проброс свойств interaction для XAML-привязок ---
    public activesubstance SubstanceId1Navigation => Interaction.SubstanceId1Navigation;
    public activesubstance SubstanceId2Navigation => Interaction.SubstanceId2Navigation;
    public risklevel RiskLevel => Interaction.RiskLevel;
    public interactiontype InteractionType => Interaction.InteractionType;
    public string? Description => Interaction.Description;
    public string? Recommendation => Interaction.Recommendation;

    // --- Вычисляемые свойства для UI ---
    public string ResidualLabel => IsResidual
        ? $"Препарат завершён {DaysAgoEnded} дн. назад, возможен остаточный эффект вывода"
        : string.Empty;

    public string ConflictTypeLabel => IsResidual ? "Остаточный эффект" : "Активное взаимодействие";
    public string ConflictTypeIcon  => IsResidual ? "🟡" : "🔴";
    public double CardOpacity       => IsResidual ? 0.75 : 1.0;
    public string CardBackgroundColor => IsResidual ? "#FFFDE7" : "#FFFFFF";
}
