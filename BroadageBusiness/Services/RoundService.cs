using AutoMapper;
using BroadageEntity;
using BroadageEntity.DTOs;
using BroadageEntity.Entities;
using BroadageEntity.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BroadageBusiness.Services
{
    public class RoundService : IRoundService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoundService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<bool>> CreateAsync(RoundDTO dtoObject)
        {
            await _unitOfWork.Rounds.AddAsync(new Round()
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
            Round round = await _unitOfWork.Rounds.GetByIdAsync(id);

            await _unitOfWork.Rounds.DeleteAsync(round);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<List<RoundDTO>>> GetAllAsync()
        {
            List<Round> round = await _unitOfWork.Rounds.GetAllAsync();
            List<RoundDTO> roundDTOs = _mapper.Map<List<RoundDTO>>(round);

            return new ServiceResponse<List<RoundDTO>>(roundDTOs);
        }

        public async Task<ServiceResponse<RoundDTO>> GetByIdAsync(int id)
        {
            Round round = await _unitOfWork.Rounds.GetByIdAsync(id);
            RoundDTO roundDTO = _mapper.Map<RoundDTO>(round);

            return new ServiceResponse<RoundDTO>(roundDTO);
        }
        public async Task<ServiceResponse<bool>> UpdateAsync(RoundDTO dtoObject)
        {
            Round entity = _mapper.Map<Round>(dtoObject);

            await _unitOfWork.Rounds.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }
    }
}
