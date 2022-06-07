using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadcaseConsoleApp.Models
{
    public class JsonAwayTeam
    {
        public JsonScore score { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string mediumName { get; set; }
        public int id { get; set; }
    }
}
