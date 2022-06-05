using AutoMapper;
using BroadageEntity.DTOs;
using BroadageEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageBusiness.AutoMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AwayTeam, AwayTeamDTO>();
            CreateMap<HomeTeam, HomeTeamDTO>();
            CreateMap<Score, ScoreDTO>();
            CreateMap<Match, MatchDTO>();
            CreateMap<Round, RoundDTO>();
            CreateMap<Stage, StageDTO>();
            CreateMap<Status, StatusDTO>();
            CreateMap<Tournament, TournamentDTO>();
        }
    }
}
