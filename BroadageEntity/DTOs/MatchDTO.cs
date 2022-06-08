using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageEntity.DTOs
{
    public class MatchDTO : DTOBase<int>
    {
        public DateTime Date { get; set; }
        public Nullable<int> CurrentMinute { get; set; }
        public Nullable<int> Stoppage { get; set; }

        public Nullable<int> HomeTeamId { get; set; }
        public Nullable<int> AwayTeamId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> TournamentId { get; set; }
        public Nullable<int> StageId { get; set; }
        public Nullable<int> RoundId { get; set; }

        public virtual HomeTeamDTO HomeTeam { get; set; }
        public virtual AwayTeamDTO AwayTeam { get; set; }
        public virtual StatusDTO Status { get; set; }
        public virtual TournamentDTO Tournament { get; set; }
        public virtual StageDTO Stage { get; set; }
        public virtual RoundDTO Round { get; set; }
    }
}
