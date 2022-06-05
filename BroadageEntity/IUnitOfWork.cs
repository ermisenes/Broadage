using BroadageEntity.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageEntity
{
    public interface IUnitOfWork : IDisposable
    {
        IAwayTeamRepository AwayTeams { get; }
        IHomeTeamRepository HomeTeams { get; }
        IMatchRepository Matches { get; }
        IRoundRepository Rounds { get; }
        IScoreRepository Scores { get; }
        IStageRepository Stages { get; }
        IStatusRepository Statuses { get; }
        ITournamentRepository Tournaments { get; }
        Task<int> CommitAsync();

    }
}
