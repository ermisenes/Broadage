using BroadageEntity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageEntity.Entities
{
    public class Score:BaseEntity
    {
        public Score()
        {
            AwayTeams = new List<AwayTeam>();
            HomeTeams = new List<HomeTeam>();
        }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int Regular { get; set; }
        public int HalfTime { get; set; }
        public int Penalties { get; set; }
        public int EextraTime { get; set; }
        public int Current { get; set; }

        public ICollection<AwayTeam> AwayTeams { get; set; }
        public ICollection<HomeTeam> HomeTeams { get; set; }
    }
}
