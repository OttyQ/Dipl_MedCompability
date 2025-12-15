using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class risklevel
{
    public int RiskLevelId { get; set; }

    public string Name { get; set; } = null!;

    public sbyte Severity { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<interaction> interactions { get; set; } = new List<interaction>();
}
