using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class prescription
{
    public int PrescriptionId { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public int MedicineId { get; set; }

    public DateTime? PrescribedAt { get; set; }

    // --- НОВЫЕ ПОЛЯ ---
    // Используем DateTime (без ?) для дат, так как они обязательны для проверки пересечений
    public DateTime StartDate { get; set; } 

    public DateTime EndDate { get; set; }

    public string? Dosage { get; set; }
    // ------------------

    public string? Notes { get; set; }

    public virtual user Doctor { get; set; } = null!;

    public virtual medicine Medicine { get; set; } = null!;

    public virtual user Patient { get; set; } = null!;
}