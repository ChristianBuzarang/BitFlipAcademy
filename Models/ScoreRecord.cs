using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitFlipBlazor.Models;

[Table("tblscorerecord")]
public class ScoreRecord
{
    [Key, Column("srid")]
    public int Srid { get; set; }
    [Column("final_score")] public int FinalScore { get; set; }
    [Column("date_completed")] public DateTime DateCompleted { get; set; } = DateTime.UtcNow;
    [Column("time_taken")] public int TimeTaken { get; set; }
    [Column("is_passed")] public int IsPassed { get; set; }
}