namespace BroadageEntity.DTOs
{
    public class ScoreDTO : DTOBase<int>
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int Regular { get; set; }
        public int HalfTime { get; set; }
        public int Penalties { get; set; }
        public int EextraTime { get; set; }
        public int Current { get; set; }

    }
}
