using Microsoft.EntityFrameworkCore;
using BitFlipBlazor.Models;

namespace BitFlipBlazor.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Challenge> Challenges => Set<Challenge>();
    public DbSet<ScoreRecord> ScoreRecords => Set<ScoreRecord>();
}