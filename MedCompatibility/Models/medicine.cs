using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class medicine
{
    public int MedicineId { get; set; }

    public string TradeName { get; set; } = null!;

    public string? INN { get; set; }

    public int ManufacturerId { get; set; }

    public string? Form { get; set; }

    public string GTIN { get; set; } = null!;

    public string? Description { get; set; }

    public virtual manufacturer Manufacturer { get; set; } = null!;
    
    public bool IsDeleted { get; set; }

    public virtual ICollection<prescription> prescriptions { get; set; } = new List<prescription>();

    public virtual ICollection<scan> scans { get; set; } = new List<scan>();

    public virtual ICollection<activesubstance> Substances { get; set; } = new List<activesubstance>();
}
