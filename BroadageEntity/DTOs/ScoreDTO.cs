using System;
using System.Collections.Generic;

namespace BroadageEntity.DTOs
{
    public class ScoreDTO : DTOBase<int>
    {
        public ScoreDTO()
        {
            AwayTeams = new List<AwayTeamDTO>();
            HomeTeams = new List<HomeTeamDTO>();
        }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public Nullable<int> Regular { get; set; }
        public Nullable<int> HalfTime { get; set; }
        public Nullable<int> Penalties { get; set; }
        public Nullable<int> ExtraTime { get; set; }
        public Nullable<int> Current { get; set; }

        public ICollection<AwayTeamDTO> AwayTeams { get; set; }
        public ICollection<HomeTeamDTO> HomeTeams { get; set; }

    }
}
