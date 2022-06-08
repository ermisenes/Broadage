using AutoMapper;
using BroadageEntity;
using BroadageEntity.DTOs;
using BroadageEntity.Entities;
using BroadageEntity.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BroadageBusiness.Services
{
    public class StageService : IStageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<bool>> CreateAsync(StageDTO dtoObject)
        {
            await _unitOfWork.Stages.AddAsync(new Stage()
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
            Stage stage = await _unitOfWork.Stages.GetByIdAsync(id);

            await _unitOfWork.Stages.DeleteAsync(stage);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<List<StageDTO>>> GetAllAsync()
        {
            List<Stage> stages = await _unitOfWork.Stages.GetAllAsync();
            List<StageDTO> stageDTOs = _mapper.Map<List<StageDTO>>(stages);

            return new ServiceResponse<List<StageDTO>>(stageDTOs);
        }

        public async Task<ServiceResponse<StageDTO>> GetByIdAsync(int id)
        {
            Stage stage = await _unitOfWork.Stages.GetByIdAsync(id);
            StageDTO stageDTO = _mapper.Map<StageDTO>(stage);

            return new ServiceResponse<StageDTO>(stageDTO);
        }
        public async Task<ServiceResponse<bool>> UpdateAsync(StageDTO dtoObject)
        {
            Stage entity = _mapper.Map<Stage>(dtoObject);

            await _unitOfWork.Stages.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }
    }
}
