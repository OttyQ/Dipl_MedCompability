namespace MedCompatibility.Models;

public enum DayType
{
    None,
    ActiveFuture,  // назначение активно, дата сегодня или в будущем
    ActivePast,    // назначение активно, но дата в прошлом
    Expired        // назначение просрочено (EndDate < Today)
}
