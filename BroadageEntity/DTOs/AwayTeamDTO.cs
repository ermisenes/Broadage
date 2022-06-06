namespace BroadageEntity.DTOs
{
    public class AwayTeamDTO : DTOBase<int>
    {
        public int AwayTeamId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string MediumName { get; set; }
        public ScoreDTO Scores { get; set; }
    }
}
