using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitFlipBlazor.Models;

[Table("tblprofessor")]
public class Professor
{
    [Key, Column("pid")]
    [ForeignKey("User")]
    public int Pid { get; set; }
}