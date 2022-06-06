using AutoMapper;
using BroadageEntity;
using BroadageEntity.DTOs;
using BroadageEntity.Entities;
using BroadageEntity.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BroadageBusiness.Services
{
    public class HomeTeamService : IHomeTeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HomeTeamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<bool>> CreateAsync(HomeTeamDTO dtoObject)
        {
            //  HomeTeam entity = _mapper.Map<HomeTeam>(dtoObject);

            await _unitOfWork.HomeTeams.AddAsync(new HomeTeam()
            {
                HomeTeamId = dtoObject.HomeTeamId,
                Name=dtoObject.Name,
                MediumName=dtoObject.MediumName,
                ShortName=dtoObject.ShortName,
                ScoreId = dtoObject.Scores.Id
            });


            //await _unitOfWork.HomeTeams.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            HomeTeam homeTeam = await _unitOfWork.HomeTeams.GetByIdAsync(id);

            await _unitOfWork.HomeTeams.DeleteAsync(homeTeam);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<List<HomeTeamDTO>>> GetAllAsync()
        {
            List<HomeTeam> homeTeams = await _unitOfWork.HomeTeams.GetAllAsync();
            List<HomeTeamDTO> homeTeamDTOs = _mapper.Map<List<HomeTeamDTO>>(homeTeams);

            return new ServiceResponse<List<HomeTeamDTO>>(homeTeamDTOs);
        }

        public async Task<ServiceResponse<HomeTeamDTO>> GetByIdAsync(int id)
        {
            HomeTeam homeTeam = await _unitOfWork.HomeTeams.GetByIdAsync(id);
            HomeTeamDTO scoreDTO = _mapper.Map<HomeTeamDTO>(homeTeam);

            return new ServiceResponse<HomeTeamDTO>(scoreDTO);
        }
        public async Task<ServiceResponse<bool>> UpdateAsync(HomeTeamDTO dtoObject)
        {
            HomeTeam entity = _mapper.Map<HomeTeam>(dtoObject);

            await _unitOfWork.HomeTeams.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);

        }
    }
}
