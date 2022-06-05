using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageEntity.DTOs
{
    public interface IDTO<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
