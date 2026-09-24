using BitFlipBlazor.Data;
using Microsoft.EntityFrameworkCore;

namespace BitFlipBlazor.Services;

public class UserSession
{
    public int Uid { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Rank { get; set; } = "Novice";
    public bool IsAuthenticated => Uid > 0;
    public bool IsDataLoaded { get; set; } = false;

    // In-memory cache preserved across page transitions
    public List<SectionState> Sections { get; private set; } = new();

    public class SectionState
    {
        public int Sid { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public string SectionPassword { get; set; } = string.Empty;
    }

    public void SetUser(int uid, string name, string email, string role)
    {
        Uid = uid;
        Name = name;
        Email = email;
        Role = role;
    }

    public async Task<bool> LoadInitialDataAsync(AppDbContext db)
    {
        try
        {
            if (Role == "STUDENT")
            {
                var student = await db.Students.FirstOrDefaultAsync(s => s.StudId == Uid);
                Rank = student?.Rank ?? "Novice";
            }

            await RefreshSectionsAsync(db);
            IsDataLoaded = true;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task RefreshSectionsAsync(AppDbContext db)
    {
        var tempSections = new List<SectionState>();
        using (var cmd = db.Database.GetDbConnection().CreateCommand())
        {
            await db.Database.OpenConnectionAsync();
            if (Role == "PROFESSOR")
            {
                cmd.CommandText =
                    "SELECT s.sid, s.section_name, s.section_password FROM tblsection s JOIN tblsection_professor sp ON s.sid = sp.sid WHERE sp.pid = @uid;";
            }
            else
            {
                cmd.CommandText =
                    "SELECT s.sid, s.section_name, s.section_password FROM tblsection s JOIN tblsection_student ss ON s.sid = ss.sid WHERE ss.studid = @uid;";
            }

            var pUid = cmd.CreateParameter();
            pUid.ParameterName = "@uid";
            pUid.Value = Uid;
            cmd.Parameters.Add(pUid);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    tempSections.Add(
                        new SectionState
                        {
                            Sid = reader.GetInt32(0),
                            SectionName = reader.GetString(1),
                            SectionPassword = reader.GetString(2),
                        }
                    );
                }
            }
        }

        // Swap list atomatically to avoid flickering
        Sections = tempSections;
    }

    public void Clear()
    {
        Uid = 0;
        Name = string.Empty;
        Email = string.Empty;
        Role = string.Empty;
        Rank = "Novice";
        IsDataLoaded = false;
        Sections.Clear();
    }
}
