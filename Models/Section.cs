using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitFlipBlazor.Models;

[Table("tblsection")]
public class Section
{
    [Key, Column("sid")]
    public int Sid { get; set; }
    [Column("section_name")] public string SectionName { get; set; } = string.Empty;
    [Column("semester")] public string Semester { get; set; } = "1st";
    [Column("year")] public string Year { get; set; } = "2026";
    [Column("section_password")] public string SectionPassword { get; set; } = string.Empty;
}