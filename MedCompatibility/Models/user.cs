using System;
using System.Collections.Generic;

namespace MedCompatibility.Models;

public partial class user
{
    public int UserId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int RoleId { get; set; }

    public bool? IsApproved { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual role Role { get; set; } = null!;
    
    public bool IsDeleted { get; set; }

    public virtual ICollection<analysis> analyses { get; set; } = new List<analysis>();

    public virtual ICollection<prescription> prescriptionDoctors { get; set; } = new List<prescription>();

    public virtual ICollection<prescription> prescriptionPatients { get; set; } = new List<prescription>();

    public virtual ICollection<scan> scans { get; set; } = new List<scan>();
}
