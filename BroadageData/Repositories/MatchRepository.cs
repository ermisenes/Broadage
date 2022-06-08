using BroadageEntity.DTOs;
using BroadageEntity.Entities;
using BroadageEntity.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
           .Include(x => x.Stage)
           .Include(x => x.HomeTeam).ThenInclude(x => x.Score)
           .Include(x => x.AwayTeam).ThenInclude(x => x.Score)
           .OrderByDescending(x => x.Date)
           .AsNoTracking()
           .ToListAsync();



            return await result;
        }

    }
}
