using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class role
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<user> users { get; set; } = new List<user>();
}
