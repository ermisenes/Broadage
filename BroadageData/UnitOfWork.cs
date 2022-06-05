using BroadageEntity;
using BroadageEntity.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageData
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BroadageDBContext _context;
        public IAwayTeamRepository AwayTeams { get; private set; }

        public IHomeTeamRepository HomeTeams { get; private set; }

        public IMatchRepository Matches { get; private set; }

        public IRoundRepository Rounds { get; private set; }

        public IScoreRepository Scores { get; private set; }

        public IStageRepository Stages { get; private set; }

        public IStatusRepository Statuses { get; private set; }

        public ITournamentRepository Tournaments { get; private set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
