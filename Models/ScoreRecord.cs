using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BitFlipBlazor.Models;

[Table("tblscorerecord")]
public class ScoreRecord : BaseModel
{
    [PrimaryKey("srid", false)]
    public int Srid { get; set; }

    [Column("final_score")]
    public int FinalScore { get; set; }

    [Column("date_completed")]
    public DateTime DateCompleted { get; set; } = DateTime.UtcNow;

    [Column("time_taken")]
    public int TimeTaken { get; set; }

    [Column("is_passed")]
    public int IsPassed { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}