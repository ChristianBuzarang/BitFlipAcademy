using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BitFlipBlazor.Models;

[Table("tblfeedback_reply")]
public class FeedbackReply : BaseModel
{
    [PrimaryKey("reply_id", false)]
    public int ReplyId { get; set; }

    [Column("fbid")]
    public int Fbid { get; set; }

    [Column("uid")]
    public int Uid { get; set; }

    [Column("reply_text")]
    public string ReplyText { get; set; } = string.Empty;

    [Column("date_replied")]
    public DateTime DateReplied { get; set; } = DateTime.UtcNow;

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}