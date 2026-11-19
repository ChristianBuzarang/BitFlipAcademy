using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BitFlipBlazor.Models;

[Table("tblsection")]
public class Section : BaseModel
{
    [PrimaryKey("sid", false)]
    public int Sid { get; set; }

    [Column("section_name")]
    public string SectionName { get; set; } = string.Empty;

    [Column("semester")]
    public string Semester { get; set; } = "1st";

    [Column("year")]
    public string Year { get; set; } = "2026";

    [Column("section_password")]
    public string SectionPassword { get; set; } = string.Empty;

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}