using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitFlipBlazor.Models;

[Table("tbluser")]
public class User
{
    [Key, Column("uid")]
    public int Uid { get; set; }
    [Column("name")] public string Name { get; set; } = string.Empty;
    [Column("email")] public string Email { get; set; } = string.Empty;
    [Column("password")] public string Password { get; set; } = string.Empty;
    [Column("role")] public string Role { get; set; } = "STUDENT"; // ADMIN, PROFESSOR, STUDENT
    [Column("is_active")] public int IsActive { get; set; } = 1;
}