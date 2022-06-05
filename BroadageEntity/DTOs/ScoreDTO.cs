using System;

namespace BroadageEntity.DTOs
{
    public class ScoreDTO : DTOBase<int>
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public Nullable<int> Regular { get; set; }
        public Nullable<int> HalfTime { get; set; }
        public Nullable<int> Penalties { get; set; }
        public Nullable<int> EextraTime { get; set; }
        public Nullable<int> Current { get; set; }

    }
}
