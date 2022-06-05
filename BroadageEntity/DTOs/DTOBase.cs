using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageEntity.DTOs
{
    public abstract class DTOBase<TPrimaryKey> : IDTO<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
