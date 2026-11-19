using BitFlipBlazor.Models;
using Supabase;

namespace BitFlipBlazor.Services;

public class MissionService
{
    private readonly Supabase.Client _db;

    public MissionService(Supabase.Client db) => _db = db;

    public async Task SubmitScoreAsync(int studId, int cid, int score, int passed, int timeTaken)
    {
        var record = new ScoreRecord
        {
            FinalScore = score,
            TimeTaken = timeTaken,
            IsPassed = passed,
            DateCompleted = DateTime.UtcNow
        };

        var inserted = await _db.From<ScoreRecord>().Insert(record);
        var createdRecord = inserted.Models.FirstOrDefault();

        if (createdRecord is not null)
        {
            await _db.From<StudentRecord>().Insert(new StudentRecord
            {
                Studid = studId,
                Srid = createdRecord.Srid
            });

            await _db.From<ChallengeRecord>().Insert(new ChallengeRecord
            {
                Cid = cid,
                Srid = createdRecord.Srid
            });
        }

        var studentRecords = await _db.From<StudentRecord>()
            .Where(x => x.Studid == studId && x.DeletedAt == null)
            .Get();

        var passedCount = 0;
        foreach (var sr in studentRecords.Models)
        {
            var scores = await _db.From<ScoreRecord>()
                .Where(x => x.Srid == sr.Srid && x.DeletedAt == null && x.IsPassed == 1)
                .Get();
            passedCount += scores.Models.Count;
        }

        if (passedCount >= 3)
        {
            await _db.From<Student>()
                .Where(x => x.StudId == studId)
                .Set(x => x.Rank, "Bit Master")
                .Update();
        }
    }
}