using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageEntity.DTOs
{
    public class HomeTeamDTO : DTOBase<int>
    {
        public int HomeTeamId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string MiddleName { get; set; }
        public ScoreDTO Scores { get; set; }
    }
}
