using BitFlipBlazor.Data;
using BitFlipBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BitFlipBlazor.Services;

public class ScoreService
{
    private readonly AppDbContext _db;

    public ScoreService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> SaveScoreAsync(
        int studId,
        int cid,
        int score,
        int passed,
        int timeTaken
    )
    {
        // 1. Insert into tblscorerecord
        var record = new ScoreRecord
        {
            FinalScore = score,
            IsPassed = passed,
            TimeTaken = timeTaken,
            DateCompleted = DateTime.UtcNow,
        };

        _db.ScoreRecords.Add(record);
        await _db.SaveChangesAsync();

        // 2. Link records in junction tables
        await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO tblstudent_record (studid, srid) VALUES ({studId}, {record.Srid})"
        );
        await _db.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO tblchallenge_record (cid, srid) VALUES ({cid}, {record.Srid})"
        );

        // 3. Automated Badge Check (Rule 8: check passed score count)
        var totalPassed = await _db
            .ScoreRecords.FromSqlInterpolated(
                $"SELECT r.* FROM tblscorerecord r JOIN tblstudent_record sr ON r.srid = sr.srid WHERE sr.studid = {studId} AND r.is_passed = 1"
            )
            .CountAsync();

        if (totalPassed >= 3)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.StudId == studId);
            if (student != null)
            {
                student.Rank = "Bit Master";
                await _db.SaveChangesAsync();
            }
        }

        return true;
    }
}
