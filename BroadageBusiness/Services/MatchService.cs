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
            //  Score entity = _mapper.Map<Score>(dtoObject);
            //TODO: MAÇ ekle sonraya bıraktım
            await _unitOfWork.Matches.AddAsync(new Match()
            {
             MatchId=dtoObject.MatchId,
             Date=dtoObject.Date
             
            });


            //await _unitOfWork.Matches.AddAsync(entity);
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
            List<Match> scores = await _unitOfWork.Matches.GetAllAsync();
            List<MatchDTO> scoreDTOs = _mapper.Map<List<MatchDTO>>(scores);

            return new ServiceResponse<List<MatchDTO>>(scoreDTOs);
        }

        public async Task<ServiceResponse<MatchDTO>> GetByIdAsync(int id)
        {
            Match score = await _unitOfWork.Matches.GetByIdAsync(id);
            MatchDTO scoreDTO = _mapper.Map<MatchDTO>(score);

            return new ServiceResponse<MatchDTO>(scoreDTO);
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
