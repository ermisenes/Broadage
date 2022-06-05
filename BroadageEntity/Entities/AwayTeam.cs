using BroadageEntity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BroadageEntity.Entities
{
    public class AwayTeam:EntityBase<int>
    {
        public int AwayTeamId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string MediumName { get; set; }
        public int ScoreId { get; set; }
        public Score Score { get; set; }
    }
}
