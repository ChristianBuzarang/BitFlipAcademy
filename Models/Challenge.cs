using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitFlipBlazor.Models;

[Table("tblchallenge")]
public class Challenge
{
    [Key, Column("cid")]
    public int Cid { get; set; }
    [Column("category")] public string Category { get; set; } = "Binary";
    [Column("target_number")] public int TargetNumber { get; set; }
    [Column("time_limit")] public int TimeLimit { get; set; } = 30;
    [Column("difficulty_level")] public string DifficultyLevel { get; set; } = "Easy";
}