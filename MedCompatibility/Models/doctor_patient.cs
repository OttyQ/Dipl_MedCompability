using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class doctor_patient
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public int PatientId { get; set; }

    public DateTime? AddedAt { get; set; }

    public virtual user Doctor { get; set; } = null!;

    public virtual user Patient { get; set; } = null!;
}