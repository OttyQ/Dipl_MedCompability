using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class activesubstance
{
    public int SubstanceId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<interaction> interactionSubstanceId1Navigations { get; set; } = new List<interaction>();

    public virtual ICollection<interaction> interactionSubstanceId2Navigations { get; set; } = new List<interaction>();

    public virtual ICollection<medicine> Medicines { get; set; } = new List<medicine>();
    
    // Обратная навигационная коллекция для EF Core
    public virtual ICollection<user> AllergicUsers { get; set; } = new List<user>();
}
