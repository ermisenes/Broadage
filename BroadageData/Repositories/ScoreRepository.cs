using BroadageEntity;
using BroadageEntity.DTOs;
using BroadageEntity.Entities;
using BroadageEntity.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageData.Repositories
{
    public class ScoreRepository : RepositoryBase<Score, int>, IScoreRepository
    {
        public ScoreRepository(BroadageDBContext dbDataContext) : base(dbDataContext)
        {
        }

        public async ValueTask<Score> GetByMatchIdAndTeamIdAsync(int matchId, int teamId)
        {
            return await _dbDataContext.Set<Score>().SingleOrDefaultAsync(x => x.MatchId == matchId && x.TeamId == teamId);
        }
    }
}
