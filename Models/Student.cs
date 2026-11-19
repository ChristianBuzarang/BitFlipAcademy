using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BitFlipBlazor.Models;

[Table("tblstudent")]
public class Student : BaseModel
{
    [PrimaryKey("studid", false)]
    public int StudId { get; set; }

    [Column("rank")]
    public string Rank { get; set; } = "Novice";

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}