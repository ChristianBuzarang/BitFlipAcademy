using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BitFlipBlazor.Models;

[Table("tbluser")]
public class User : BaseModel
{
    [PrimaryKey("uid", false)]
    public int Uid { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Column("password")]
    public string Password { get; set; } = string.Empty;

    [Column("role")]
    public string Role { get; set; } = "STUDENT";

    [Column("is_active")]
    public int IsActive { get; set; } = 1;

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}