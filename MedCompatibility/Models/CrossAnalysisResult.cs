namespace MedCompatibility.Models
{
    public class CrossAnalysisResult
    {
        public medicine Medicine1 { get; set; }
        public medicine Medicine2 { get; set; }
        public interaction InteractionDetails { get; set; }
        
        // Вспомогательные свойства для вывода состава
        public string Med1Substances => string.Join(", ", Medicine1.Substances.Select(s => s.Name));
        public string Med2Substances => string.Join(", ", Medicine2.Substances.Select(s => s.Name));
    }
}