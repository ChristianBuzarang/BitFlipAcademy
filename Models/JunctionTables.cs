using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitFlipBlazor.Models;

// Junction Tables (Required for EF Core many-to-many logic used in your SQL queries)
[Table("tblsection_professor")]
public class SectionProfessor { public int Sid { get; set; } public int Pid { get; set; } }

[Table("tblsection_student")]
public class SectionStudent { public int Sid { get; set; } public int Studid { get; set; } }

[Table("tblchallenge_section")]
public class ChallengeSection { public int Cid { get; set; } public int Sid { get; set; } }

[Table("tblstudent_record")]
public class StudentRecord { public int Studid { get; set; } public int Srid { get; set; } }

[Table("tblchallenge_record")]
public class ChallengeRecord { public int Cid { get; set; } public int Srid { get; set; } }

[Table("tblstudent_badge")]
public class StudentBadge { public int Bid { get; set; } public int Studid { get; set; } }