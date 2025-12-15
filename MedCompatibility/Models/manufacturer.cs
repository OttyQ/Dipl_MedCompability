using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class manufacturer
{
    public int ManufacturerId { get; set; }

    public string Name { get; set; } = null!;

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<medicine> medicines { get; set; } = new List<medicine>();
}
