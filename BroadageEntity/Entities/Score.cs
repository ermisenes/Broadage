using BroadageEntity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageEntity.Entities
{
    public class Score : EntityBase<int>
    {
        public Score()
        {
            AwayTeams = new List<AwayTeam>();
            HomeTeams = new List<HomeTeam>();
        }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public Nullable<int> Regular { get; set; }
        public Nullable<int> HalfTime { get; set; }
        public Nullable<int> Penalties { get; set; }
        public Nullable<int> EextraTime { get; set; }
        public Nullable<int> Current { get; set; }

        public ICollection<AwayTeam> AwayTeams { get; set; }
        public ICollection<HomeTeam> HomeTeams { get; set; }
    }
}
