using BitFlipBlazor.Models;

namespace BitFlipBlazor.Services;

public class UserSession
{
    private readonly Supabase.Client _db;

    public UserSession(Supabase.Client db)
    {
        _db = db;
    }

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

    public async Task<bool> LoadInitialDataAsync()
    {
        try
        {
            if (Role == "STUDENT")
            {
                var res = await _db.From<Student>()
                    .Where(s => s.StudId == Uid)
                    .Get();
                var student = res.Models.FirstOrDefault();
                Rank = student?.Rank ?? "Novice";
            }

            await RefreshSectionsAsync();
            IsDataLoaded = true;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task RefreshSectionsAsync()
    {
        var tempSections = new List<SectionState>();
        var sectionIds = new List<int>();

        if (Role == "PROFESSOR")
        {
            var links = await _db.From<SectionProfessor>()
                .Where(sp => sp.Pid == Uid)
                .Get();
            sectionIds = links.Models.Select(sp => sp.Sid).Distinct().ToList();
        }
        else
        {
            var links = await _db.From<SectionStudent>()
                .Where(ss => ss.Studid == Uid)
                .Get();
            sectionIds = links.Models.Select(ss => ss.Sid).Distinct().ToList();
        }

        foreach (var sid in sectionIds)
        {
            var secRes = await _db.From<Section>()
                .Where(s => s.Sid == sid)
                .Get();
            foreach (var sec in secRes.Models)
            {
                tempSections.Add(new SectionState
                {
                    Sid = sec.Sid,
                    SectionName = sec.SectionName,
                    SectionPassword = sec.SectionPassword
                });
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