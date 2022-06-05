using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageEntity.DTOs
{
    public class MatchDTO : DTOBase<int>
    {
        public int MatchId { get; set; }
        public DateTime Date { get; set; }
        public Nullable<int> CurrentMinute { get; set; }
        public Nullable<int> Stoppage { get; set; }
        public HomeTeamDTO HomeTeam { get; set; }
        public AwayTeamDTO AwayTeam { get; set; }
        public StatusDTO Status { get; set; }
        public TournamentDTO Tournament { get; set; }
        public StageDTO Stage { get; set; }
        public RoundDTO Round { get; set; }
    }
}
