using BroadageEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace BroadageData
{
    public class BroadageDBContext:DbContext
    {
        public BroadageDBContext(DbContextOptions<BroadageDBContext> options) : base(options)
        {
        }
        public DbSet<AwayTeam> AwayTeams { get; set; }
        public DbSet<HomeTeam> HomeTeams { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
    }
}
