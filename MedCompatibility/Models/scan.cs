using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class scan
{
    public int ScanId { get; set; }

    public int UserId { get; set; }

    public int MedicineId { get; set; }

    public DateTime? ScannedAt { get; set; }

    public virtual medicine Medicine { get; set; } = null!;

    public virtual user User { get; set; } = null!;
}
