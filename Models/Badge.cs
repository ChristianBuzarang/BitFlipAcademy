using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitFlipBlazor.Models;

[Table("tblbadge")]
public class Badge
{
    [Key, Column("bid")]
    public int Bid { get; set; }
    [Column("badgename")] public string BadgeName { get; set; } = string.Empty;
    [Column("criteriamet")] public string CriteriaMet { get; set; } = string.Empty;
}