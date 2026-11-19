using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BitFlipBlazor.Models;

[Table("tblchallenge")]
public class Challenge : BaseModel
{
    [PrimaryKey("cid", false)]
    public int Cid { get; set; }

    [Column("category")]
    public string Category { get; set; } = "Binary";

    [Column("target_number")]
    public int TargetNumber { get; set; }

    [Column("time_limit")]
    public int TimeLimit { get; set; } = 30;

    [Column("difficulty_level")]
    public string DifficultyLevel { get; set; } = "Easy";

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}