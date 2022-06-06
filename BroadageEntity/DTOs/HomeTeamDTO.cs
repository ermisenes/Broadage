namespace BroadageEntity.DTOs
{
    public class HomeTeamDTO : DTOBase<int>
    {
        public int HomeTeamId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string MediumName { get; set; }
        public ScoreDTO Scores { get; set; }
    }
}
