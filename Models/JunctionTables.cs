using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BitFlipBlazor.Models;

[Table("tblsection_professor")]
public class SectionProfessor : BaseModel
{
    [Column("sid")]
    public int Sid { get; set; }

    [Column("pid")]
    public int Pid { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}

[Table("tblsection_student")]
public class SectionStudent : BaseModel
{
    [Column("sid")]
    public int Sid { get; set; }

    [Column("studid")]
    public int Studid { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}

[Table("tblchallenge_section")]
public class ChallengeSection : BaseModel
{
    [Column("cid")]
    public int Cid { get; set; }

    [Column("sid")]
    public int Sid { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}

[Table("tblstudent_record")]
public class StudentRecord : BaseModel
{
    [Column("studid")]
    public int Studid { get; set; }

    [Column("srid")]
    public int Srid { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}

[Table("tblchallenge_record")]
public class ChallengeRecord : BaseModel
{
    [Column("cid")]
    public int Cid { get; set; }

    [Column("srid")]
    public int Srid { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}

[Table("tblstudent_badge")]
public class StudentBadge : BaseModel
{
    [Column("bid")]
    public int Bid { get; set; }

    [Column("studid")]
    public int Studid { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}