using BroadageEntity.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
namespace BroadageEntity.Entities
{
    public class Match : EntityBase<int>
    {
       // public int MatchId { get; set; }
        public DateTime Date { get; set; }
        public Nullable<int> Stoppage { get; set; }
        public Nullable<int> CurrentMinute { get; set; }

        public Nullable<int> HomeTeamId { get; set; }
        public Nullable<int> AwayTeamId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> TournamentId { get; set; }
        public Nullable<int> StageId { get; set; }
        public Nullable<int> RoundId { get; set; }


        public virtual AwayTeam AwayTeam { get; set; }
        public virtual HomeTeam HomeTeam { get; set; }
        public virtual Round Round { get; set; }
        public virtual Stage Stage { get; set; }
        public virtual Status Status { get; set; }
        public virtual Tournament Tournament { get; set; }

    }
}
