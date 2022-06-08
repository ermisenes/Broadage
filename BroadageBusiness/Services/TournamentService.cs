using AutoMapper;
using BroadageEntity;
using BroadageEntity.DTOs;
using BroadageEntity.Entities;
using BroadageEntity.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BroadageBusiness.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TournamentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<bool>> CreateAsync(TournamentDTO dtoObject)
        {
            await _unitOfWork.Tournaments.AddAsync(new Tournament()
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
            Tournament tournament = await _unitOfWork.Tournaments.GetByIdAsync(id);

            await _unitOfWork.Tournaments.DeleteAsync(tournament);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }

        public async Task<ServiceResponse<List<TournamentDTO>>> GetAllAsync()
        {
            List<Tournament> tournaments = await _unitOfWork.Tournaments.GetAllAsync();
            List<TournamentDTO> tournamentDTOs = _mapper.Map<List<TournamentDTO>>(tournaments);

            return new ServiceResponse<List<TournamentDTO>>(tournamentDTOs);
        }

        public async Task<ServiceResponse<TournamentDTO>> GetByIdAsync(int id)
        {
            Tournament tournament = await _unitOfWork.Tournaments.GetByIdAsync(id);
            TournamentDTO scoreDTO = _mapper.Map<TournamentDTO>(tournament);

            return new ServiceResponse<TournamentDTO>(scoreDTO);
        }
        public async Task<ServiceResponse<bool>> UpdateAsync(TournamentDTO dtoObject)
        {
            Tournament entity = _mapper.Map<Tournament>(dtoObject);

            await _unitOfWork.Tournaments.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return new ServiceResponse<bool>(true);
        }
    }
}
