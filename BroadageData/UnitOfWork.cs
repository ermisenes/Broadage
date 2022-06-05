using BroadageData.Repositories;
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
        public UnitOfWork(BroadageDBContext context)
        {
            _context = context;
            HomeTeams =new HomeTeamRepository(_context);
            Matches = new MatchRepository(_context); 
            Rounds = new RoundRepository(_context); 
            Scores = new ScoreRepository(_context); 
            Stages = new StageRepository(_context); 
            Statuses = new StatusRepository(_context);
            AwayTeams = new AwayTeamRepository(_context);
            Tournaments = new TournamentRepository(_context); 
        }

        public IHomeTeamRepository HomeTeams { get; private set; }

        public IMatchRepository Matches { get; private set; }

        public IRoundRepository Rounds { get; private set; }

        public IScoreRepository Scores { get; private set; }

        public IStageRepository Stages { get; private set; }

        public IStatusRepository Statuses { get; private set; }

        public ITournamentRepository Tournaments { get; private set; }

        public IAwayTeamRepository AwayTeams { get; private set; }

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
