using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedCompatibility.Models;

[Table("system_log")]
public class SystemLog
{
    [Key]
    public int LogId { get; set; }

    public DateTime Timestamp { get; set; }

    [MaxLength(20)]
    public string Level { get; set; } = null!;

    [MaxLength(100)]
    public string Action { get; set; } = null!;

    [MaxLength(500)]
    public string Message { get; set; } = null!;

    public int? UserId { get; set; }

    [ForeignKey("UserId")]
    public virtual user? User { get; set; }
}
