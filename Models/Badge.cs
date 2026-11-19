using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BitFlipBlazor.Models;

[Table("tblbadge")]
public class Badge : BaseModel
{
    [PrimaryKey("bid", false)]
    public int Bid { get; set; }

    [Column("badgename")]
    public string BadgeName { get; set; } = string.Empty;

    [Column("criteriamet")]
    public string CriteriaMet { get; set; } = string.Empty;

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}