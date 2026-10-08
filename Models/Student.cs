using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitFlipBlazor.Models;

[Table("tblstudent")]
public class Student
{
    [Key, Column("studid")]
    [ForeignKey("User")]
    public int StudId { get; set; }
    [Column("rank")] public string Rank { get; set; } = "Novice";
}