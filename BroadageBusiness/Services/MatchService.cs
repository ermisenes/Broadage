using AutoMapper;
using BroadageEntity;
using BroadageEntity.DTOs;
using BroadageEntity.Entities;
using BroadageEntity.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageBusiness.Services
{
    public class MatchService : IMatchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MatchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<bool>> CreateAsync(MatchDTO dtoObject)
        {
            await _unitOfWork.Matches.AddAsync(new Match()
            {
                AwayTeamId = dtoObject.AwayTeamId,
                HomeTeamId = dtoObject.HomeTeamId,
                Id = dtoObject.Id,
                RoundId = dtoObject.RoundId,
                StageId = dtoObject.StageId,
                Date = dtoObject.Date,
                StatusId=dtoObject.StatusId,
                TournamentId = dtoObject.TournamentId,
                Stoppage = dtoObject.Stoppage,
                CurrentMinute = dtoObject.CurrentMinute
            });

            await _unitOfWork.CommitAsync();
            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            Match score = await _unitOfWork.Matches.GetByIdAsync(id);

            await _unitOfWork.Matches.DeleteAsync(score);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<List<MatchDTO>>> GetAllAsync()
        {
            List<Match> matches = await _unitOfWork.Matches.GetAllAsync();
            List<MatchDTO> matchDTOs = _mapper.Map<List<MatchDTO>>(matches);

            return new ServiceResponse<List<MatchDTO>>(matchDTOs);
        }

        public async Task<ServiceResponse<MatchDTO>> GetByIdAsync(int id)
        {
            Match match = await _unitOfWork.Matches.GetByIdAsync(id);
            MatchDTO scoreDTO = _mapper.Map<MatchDTO>(match);

            return new ServiceResponse<MatchDTO>(scoreDTO);
        }

        public async Task<ServiceResponse<List<MatchDTO>>> GetMatchListAll()
        {
            List<Match> matches = await _unitOfWork.Matches.GetMatchListAll();
            List<MatchDTO> matchDTOs = _mapper.Map<List<MatchDTO>>(matches);
            return new ServiceResponse<List<MatchDTO>>(matchDTOs);
        }
        public async Task<ServiceResponse<bool>> UpdateAsync(MatchDTO dtoObject)
        {
            Match entity = _mapper.Map<Match>(dtoObject);

            await _unitOfWork.Matches.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

    }
}
