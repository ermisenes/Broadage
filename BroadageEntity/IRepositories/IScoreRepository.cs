using BroadageEntity.DTOs;
using BroadageEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageEntity.IRepositories
{
    public interface IScoreRepository:IRepository<Score,int>
    {
        ValueTask<Score> GetByMatchIdAndTeamIdAsync(int matchId, int teamId);
    }
}
