using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class interaction
{
    public int InteractionId { get; set; }

    public int SubstanceId1 { get; set; }

    public int SubstanceId2 { get; set; }

    public int InteractionTypeId { get; set; }

    public int RiskLevelId { get; set; }

    public string? Description { get; set; }

    public string? Recommendation { get; set; }

    public virtual interactiontype InteractionType { get; set; } = null!;

    public virtual risklevel RiskLevel { get; set; } = null!;

    public virtual activesubstance SubstanceId1Navigation { get; set; } = null!;

    public virtual activesubstance SubstanceId2Navigation { get; set; } = null!;

    public virtual ICollection<analysis> Analyses { get; set; } = new List<analysis>();
}
