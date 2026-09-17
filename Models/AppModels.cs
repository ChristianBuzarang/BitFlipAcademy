using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitFlipBlazor.Models;

[Table("tbluser")]
public class User
{
    [Key]
    [Column("uid")]
    public int Uid { get; set; }

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("email")]
    public string Email { get; set; } = string.Empty;

    [Column("password")]
    public string Password { get; set; } = string.Empty;

    [Column("role")]
    public string Role { get; set; } = "STUDENT";

    [Column("is_active")]
    public int IsActive { get; set; } = 1;
}

[Table("tblstudent")]
public class Student
{
    [Key]
    [Column("studid")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int StudId { get; set; }

    [Column("rank")]
    public string Rank { get; set; } = "Novice";
}

[Table("tblchallenge")]
public class Challenge
{
    [Key]
    [Column("cid")]
    public int Cid { get; set; }

    [Column("category")]
    public string Category { get; set; } = "Binary";

    [Column("target_number")]
    public int TargetNumber { get; set; }

    [Column("time_limit")]
    public int TimeLimit { get; set; } = 30;

    [Column("difficulty_level")]
    public string DifficultyLevel { get; set; } = "Easy";
}

[Table("tblscorerecord")]
public class ScoreRecord
{
    [Key]
    [Column("srid")]
    public int Srid { get; set; }

    [Column("final_score")]
    public int FinalScore { get; set; }

    [Column("date_completed")]
    public DateTime DateCompleted { get; set; } = DateTime.UtcNow;

    [Column("time_taken")]
    public int TimeTaken { get; set; }

    [Column("is_passed")]
    public int IsPassed { get; set; }
}