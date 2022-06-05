using BroadageEntity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageEntity.IServices
{
    public interface IService<TDTO, TId> where TDTO : IDTO<TId>
    {
        Task<ServiceResponse<List<TDTO>>> GetAllAsync();
        Task<ServiceResponse<TDTO>> GetByIdAsync(TId id);
        Task<ServiceResponse<bool>> CreateAsync(TDTO dtoObject);
        Task<ServiceResponse<bool>> UpdateAsync(TDTO dtoObject);
        Task<ServiceResponse<bool>> DeleteAsync(TId id);
    }
}
