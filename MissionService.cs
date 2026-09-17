using BitFlipBlazor.Data;
using BitFlipBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BitFlipBlazor.Services;

public class MissionService
{
    private readonly AppDbContext _db;

    public MissionService(AppDbContext db) => _db = db;

    public async Task SubmitScoreAsync(int studId, int cid, int score, int passed, int timeTaken)
    {
        // 1. Create score record
        var record = new ScoreRecord
        {
            FinalScore = score,
            TimeTaken = timeTaken,
            IsPassed = passed,
            DateCompleted = DateTime.Now
        };
        _db.ScoreRecords.Add(record);
        await _db.SaveChangesAsync();

        // 2. Automated Badge Check (Rule 8)
        var totalPassed = await (from sr in _db.Set<Dictionary<string, object>>("tblstudent_record") // Or dedicated junction entity
                                 join r in _db.ScoreRecords on sr["srid"] equals r.Srid
                                 where (int)sr["studid"] == studId && r.IsPassed == 1
                                 select r).CountAsync();

        if (totalPassed >= 3)
        {
            // Award badge and update rank
            var student = await _db.Students.FindAsync(studId);
            if (student != null)
            {
                student.Rank = "Bit Master";
                await _db.SaveChangesAsync();
            }
        }
    }
}