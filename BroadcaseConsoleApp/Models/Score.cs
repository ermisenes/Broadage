using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadcaseConsoleApp.Models
{
    public class xScore
    {
        public Nullable<int> regular { get; set; }
        public Nullable<int> halfTime { get; set; }
        public Nullable<int> penalties { get; set; }
        public Nullable<int> extraTime { get; set; }
        public Nullable<int> current { get; set; }
    }
}
