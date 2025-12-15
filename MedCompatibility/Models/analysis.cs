using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class analysis
{
    public int AnalysisId { get; set; }

    public int UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual user User { get; set; } = null!;

    public virtual ICollection<interaction> Interactions { get; set; } = new List<interaction>();
}
