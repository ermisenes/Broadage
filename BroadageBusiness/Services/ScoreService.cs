using AutoMapper;
using BroadageEntity;
using BroadageEntity.DTOs;
using BroadageEntity.Entities;
using BroadageEntity.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BroadageBusiness.Services
{
    public class ScoreService : IScoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ScoreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<bool>> CreateAsync(ScoreDTO dtoObject)
        {
            await _unitOfWork.Scores.AddAsync(new Score()
            {
                TeamId = dtoObject.TeamId,
                Current = dtoObject.Current,
                ExtraTime = dtoObject.ExtraTime,
                MatchId = dtoObject.MatchId,
                Regular = dtoObject.Regular,
                HalfTime = dtoObject.HalfTime,
                Penalties = dtoObject.Penalties,
            });

            await _unitOfWork.CommitAsync();
            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            Score score = await _unitOfWork.Scores.GetByIdAsync(id);

            await _unitOfWork.Scores.DeleteAsync(score);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<List<ScoreDTO>>> GetAllAsync()
        {
            List<Score> scores = await _unitOfWork.Scores.GetAllAsync();
            List<ScoreDTO> scoreDTOs = _mapper.Map<List<ScoreDTO>>(scores);

            return new ServiceResponse<List<ScoreDTO>>(scoreDTOs);
        }

        public async Task<ServiceResponse<ScoreDTO>> GetByIdAsync(int id)
        {
            Score score = await _unitOfWork.Scores.GetByIdAsync(id);
            ScoreDTO scoreDTO = _mapper.Map<ScoreDTO>(score);


            return new ServiceResponse<ScoreDTO>(scoreDTO);
        }

        public async Task<ServiceResponse<ScoreDTO>> GetByMatchIdAndTeamIdAsync(int matchId, int teamId)
        {
            Score score = await _unitOfWork.Scores.GetByMatchIdAndTeamIdAsync(matchId, teamId);
            ScoreDTO scoreDTO = _mapper.Map<ScoreDTO>(score);

            return new ServiceResponse<ScoreDTO>(scoreDTO);
        }

        public async Task<ServiceResponse<bool>> UpdateAsync(ScoreDTO dtoObject)
        {
            Score entity = _mapper.Map<Score>(dtoObject);

            await _unitOfWork.Scores.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }
    }
}
