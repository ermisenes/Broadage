using BroadageEntity.Entities;
using BroadageEntity.IRepositories;
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
    }
}
