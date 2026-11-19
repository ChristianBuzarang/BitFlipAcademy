using BitFlipBlazor.Models;

namespace BitFlipBlazor.Services;

public class ScoreService
{
    private readonly Supabase.Client _db;

    public ScoreService(Supabase.Client db)
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
            DateCompleted = DateTime.UtcNow
        };

        var inserted = await _db.From<ScoreRecord>().Insert(record);
        var createdRecord = inserted.Models.FirstOrDefault();
        var srid = createdRecord?.Srid ?? record.Srid;

        // 2. Link records in junction tables
        await _db.From<StudentRecord>().Insert(new StudentRecord
        {
            Studid = studId,
            Srid = srid
        });

        await _db.From<ChallengeRecord>().Insert(new ChallengeRecord
        {
            Cid = cid,
            Srid = srid
        });

        // 3. Automated Badge Check (Rule 8: check passed score count)
        var studentRecords = await _db.From<StudentRecord>()
            .Where(x => x.Studid == studId)
            .Get();

        var passedCount = 0;
        foreach (var sr in studentRecords.Models)
        {
            var passedScores = await _db.From<ScoreRecord>()
                .Where(x => x.Srid == sr.Srid && x.IsPassed == 1)
                .Get();
            passedCount += passedScores.Models.Count;
        }

        if (passedCount >= 3)
        {
            await _db.From<Student>()
                .Where(x => x.StudId == studId)
                .Set(x => x.Rank, "Bit Master")
                .Update();
        }

        return true;
    }
}