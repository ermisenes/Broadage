using BroadageEntity.DTOs;
using BroadageEntity.Entities;
using BroadageEntity.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BroadageData.Repositories
{
    public class MatchRepository : RepositoryBase<Match, int>, IMatchRepository
    {
        public MatchRepository(BroadageDBContext dbDataContext) : base(dbDataContext)
        {
        }
        public async Task<List<Match>> GetMatchListAll()
        {
           var result = _dbDataContext.Set<Match>().
           Include(x => x.AwayTeam)
          .Include(x => x.HomeTeam)
          .Include(x => x.Tournament)
          .Include(x => x.Round)
          .Include(x => x.Status)
          .Include(x => x.Stage).ToListAsync();

            return await result;
        }

    }
}
