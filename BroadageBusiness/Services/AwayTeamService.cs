using AutoMapper;
using BroadageEntity;
using BroadageEntity.DTOs;
using BroadageEntity.Entities;
using BroadageEntity.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BroadageBusiness.Services
{
    public class AwayTeamService : IAwayTeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AwayTeamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<bool>> CreateAsync(AwayTeamDTO dtoObject)
        {
            //  AwayTeam entity = _mapper.Map<AwayTeam>(dtoObject);

            await _unitOfWork.AwayTeams.AddAsync(new AwayTeam()
            {
                AwayTeamId = dtoObject.AwayTeamId,
                Name=dtoObject.Name,
                MediumName=dtoObject.MediumName,
                ShortName=dtoObject.ShortName,
                ScoreId = dtoObject.ScoreId
            });


            //await _unitOfWork.AwayTeams.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            AwayTeam awayTeam = await _unitOfWork.AwayTeams.GetByIdAsync(id);

            await _unitOfWork.AwayTeams.DeleteAsync(awayTeam);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<List<AwayTeamDTO>>> GetAllAsync()
        {
            List<AwayTeam> awayTeams = await _unitOfWork.AwayTeams.GetAllAsync();
            List<AwayTeamDTO> awayTeamDTOs = _mapper.Map<List<AwayTeamDTO>>(awayTeams);

            return new ServiceResponse<List<AwayTeamDTO>>(awayTeamDTOs);
        }

        public async Task<ServiceResponse<AwayTeamDTO>> GetByIdAsync(int id)
        {
            AwayTeam awayTeam = await _unitOfWork.AwayTeams.GetByIdAsync(id);
            AwayTeamDTO awayTeamDTO = _mapper.Map<AwayTeamDTO>(awayTeam);

            return new ServiceResponse<AwayTeamDTO>(awayTeamDTO);
        }
        public async Task<ServiceResponse<bool>> UpdateAsync(AwayTeamDTO dtoObject)
        {
            AwayTeam entity = _mapper.Map<AwayTeam>(dtoObject);

            await _unitOfWork.AwayTeams.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);

        }
    }
}
