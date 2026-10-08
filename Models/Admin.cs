using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitFlipBlazor.Models;

[Table("tbladmin")]
public class Admin
{
    [Key, Column("aid")]
    [ForeignKey("User")]
    public int Aid { get; set; }
}