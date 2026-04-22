using System.Linq;

namespace MedCompatibility.Models;

public partial class medicine
{
    public string SubstancesText => (Substances != null && Substances.Any()) 
        ? string.Join(", ", Substances.Select(s => s.Name)) 
        : "Состав не указан";
}
