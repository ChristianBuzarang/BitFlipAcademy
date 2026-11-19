using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BitFlipBlazor.Models;

[Table("tbladmin")]
public class Admin : BaseModel
{
    [PrimaryKey("aid", false)]
    public int Aid { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}