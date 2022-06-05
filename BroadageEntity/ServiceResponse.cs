using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageEntity
{
    public class ServiceResponse<TResult>
    {
        public bool IsSuccessfull { get; set; }
        public TResult Result { get; set; }
        public List<string> Errors { get; set; }

        public ServiceResponse(TResult result, bool isSuccessfull = true)
        {
            IsSuccessfull = isSuccessfull;
            Result = result;
            Errors = new List<string>();
        }
    }
}
