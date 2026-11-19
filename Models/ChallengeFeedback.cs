using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BitFlipBlazor.Models;

[Table("tblchallenge_feedback")]
public class ChallengeFeedback : BaseModel
{
    [PrimaryKey("fbid", false)]
    public int Fbid { get; set; }

    [Column("cid")]
    public int Cid { get; set; }

    [Column("studid")]
    public int StudId { get; set; }

    [Column("rating")]
    public int Rating { get; set; }

    [Column("comment_text")]
    public string CommentText { get; set; } = string.Empty;

    [Column("date_submitted")]
    public DateTime DateSubmitted { get; set; } = DateTime.UtcNow;

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}