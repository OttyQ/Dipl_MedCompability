using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class interactiontype
{
    public int InteractionTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<interaction> interactions { get; set; } = new List<interaction>();
}
