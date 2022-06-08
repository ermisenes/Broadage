using AutoMapper;
using BroadageEntity;
using BroadageEntity.DTOs;
using BroadageEntity.Entities;
using BroadageEntity.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BroadageBusiness.Services
{
    public class StatusService : IStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<bool>> CreateAsync(StatusDTO dtoObject)
        {
            await _unitOfWork.Statuses.AddAsync(new Status()
            {
                Id= dtoObject.Id,
                Name=dtoObject.Name,
                ShortName=dtoObject.ShortName
            });

            await _unitOfWork.CommitAsync();
            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            Status status = await _unitOfWork.Statuses.GetByIdAsync(id);

            await _unitOfWork.Statuses.DeleteAsync(status);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<List<StatusDTO>>> GetAllAsync()
        {
            List<Status> status = await _unitOfWork.Statuses.GetAllAsync();
            List<StatusDTO> statusDTOs = _mapper.Map<List<StatusDTO>>(status);

            return new ServiceResponse<List<StatusDTO>>(statusDTOs);
        }

        public async Task<ServiceResponse<StatusDTO>> GetByIdAsync(int id)
        {
            Status status = await _unitOfWork.Statuses.GetByIdAsync(id);
            StatusDTO statusDTO = _mapper.Map<StatusDTO>(status);

            return new ServiceResponse<StatusDTO>(statusDTO);
        }
        public async Task<ServiceResponse<bool>> UpdateAsync(StatusDTO dtoObject)
        {
            Status entity = _mapper.Map<Status>(dtoObject);

            await _unitOfWork.Statuses.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }
    }
}
