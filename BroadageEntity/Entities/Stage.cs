using BroadageEntity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageEntity.Entities
{
    public class Stage : EntityBase<int>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
