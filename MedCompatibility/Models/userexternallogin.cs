using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedCompatibility.Models;

[Table("user_external_login")]
public class userexternallogin
{
    [Key]
    public int ExternalLoginId { get; set; }
    
    public int UserId { get; set; }
    
    [MaxLength(50)]
    public string ProviderName { get; set; } = null!;
    
    [MaxLength(255)]
    public string ProviderKey { get; set; } = null!;

    [ForeignKey("UserId")]
    public virtual user User { get; set; } = null!;
}
