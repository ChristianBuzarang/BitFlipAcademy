using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BitFlipBlazor.Models;

[Table("tblprofessor")]
public class Professor : BaseModel
{
    [PrimaryKey("pid", false)]
    public int Pid { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}