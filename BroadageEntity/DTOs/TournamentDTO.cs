using BroadageEntity.DTOs;

namespace BroadageEntity.DTOs
{
    public class TournamentDTO : DTOBase<int>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
