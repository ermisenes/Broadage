using BroadageEntity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BroadageEntity.Entities
{
    public class HomeTeam : BaseEntity
    {
        public int HomeTeamId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string MiddleName { get; set; }
        public int ScoreId { get; set; }
        public Score Score { get; set; }

    }
}
