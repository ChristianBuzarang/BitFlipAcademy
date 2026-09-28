using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitFlipBlazor.Models;

[Table("tblfeedback_reply")]
public class FeedbackReply
{
    [Key]
    [Column("reply_id")]
    public int ReplyId { get; set; }

    [Column("fbid")]
    public int Fbid { get; set; }

    [Column("uid")]
    public int Uid { get; set; }

    [Column("reply_text")]
    public string ReplyText { get; set; } = string.Empty;

    [Column("date_replied")]
    public DateTime DateReplied { get; set; } = DateTime.UtcNow;
}
