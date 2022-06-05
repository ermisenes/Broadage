using BroadageEntity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageEntity.IServices
{
    public interface IScoreService : IService<ScoreDTO, int>
    {
        //Task<ScoreDTO> GetByMatchIdAndTeamIdAsync(int matchId, int teamId);
    }
}
