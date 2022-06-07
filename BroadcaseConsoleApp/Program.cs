using AutoMapper;
using BroadageBusiness.AutoMapping;
using BroadageBusiness.Logger;
using BroadageBusiness.Services;
using BroadageData;
using BroadageData.Repositories;
using BroadageEntity;
using BroadageEntity.DTOs;
using BroadageEntity.Entities;
using BroadageEntity.IRepositories;
using BroadageEntity.IServices;
using BroadcaseConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BroadageConsoleApp
{
    public class Program
    {
        private static IScoreService _scoreService;
        private static IHomeTeamService _homeTeamService;
        private static IAwayTeamService _awayTeamService;
        private static IMatchService _matchService;
        private static IRoundService _roundService;
        private static ITournamentService _tournamentService;
        private static IStageService _stageService;
        private static IStatusService _statusService;


        private static BroadageDBContext _appDbContext;
        private static ILoggerManager _loggerManager;


        static async Task Main(string[] args)
        {



            var dfs = LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "\\Nlog.config"));
            var services = new ServiceCollection();
            services.AddDbContext<BroadageDBContext>(options =>
                   options.UseSqlServer(@"Server=DESKTOP-ERJ7DJG\SQLEXPRESS;Database=BroadageSportsDB;Trusted_Connection=True;"));

            services.AddScoped<IScoreService, ScoreService>();
            services.AddScoped<IScoreRepository, ScoreRepository>();

            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IMatchRepository, MatchRepository>();

            services.AddScoped<IHomeTeamService, HomeTeamService>();
            services.AddScoped<IHomeTeamRepository, HomeTeamRepository>();

            services.AddScoped<IAwayTeamService, AwayTeamService>();
            services.AddScoped<IAwayTeamRepository, AwayTeamRepository>();

            services.AddScoped<IRoundService, RoundService>();
            services.AddScoped<IRoundRepository, RoundRepository>();

            services.AddScoped<ITournamentService, TournamentService>();
            services.AddScoped<ITournamentRepository, TournamentRepository>();

            services.AddScoped<IStageService, StageService>();
            services.AddScoped<IStageRepository, StageRepository>();

            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IStatusRepository, StatusRepository>();

            services.AddSingleton<ILoggerManager, LoggerManager>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(Program).Assembly);
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            var serviceProvider = services.BuildServiceProvider();
            _scoreService = serviceProvider.GetService<IScoreService>();
            _homeTeamService = serviceProvider.GetService<IHomeTeamService>();
            _awayTeamService = serviceProvider.GetService<IAwayTeamService>();
            _matchService = serviceProvider.GetService<IMatchService>();
            _roundService = serviceProvider.GetService<IRoundService>();
            _tournamentService = serviceProvider.GetService<ITournamentService>();
            _stageService = serviceProvider.GetService<IStageService>();
            _statusService = serviceProvider.GetService<IStatusService>();
            _appDbContext = serviceProvider.GetService<BroadageDBContext>();


            var homeTeamScoreIdxx = await _scoreService.GetByMatchIdAndTeamIdAsync(1579291, 2200);



            string key = "842824df-e28b-4ed9-90b9-b01f12102538";
            string languageId = "2";

            var matches = new List<JsonMatch>();

            var todaysDate = DateTime.Now.ToShortDateString().Replace(".", "/");

            var day = todaysDate.IndexOf('/');
            if (day == 1)
            {
                todaysDate = String.Concat("0", todaysDate);
            }

            var url = $"https://s0-sports-data-api.broadage.com/soccer/match/list?date=03/06/2022";
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
            client.DefaultRequestHeaders.Add("languageId", languageId);

            Task<HttpResponseMessage> Res = client.GetAsync(url);

            if (Res.Result.IsSuccessStatusCode)
            {
                var EmpResponse = Res.Result.Content.ReadAsStringAsync().Result;

                matches = JsonConvert.DeserializeObject<List<JsonMatch>>(EmpResponse);
            }

            if (matches.Count != 0)
            {
                foreach (var match in matches)
                {
                    if (_matchService.GetByIdAsync(match.id).Result.Result == null)
                    {
                        await Console.Out.WriteLineAsync("Api'den gelen veriler DB yazılmaya başladı...");

                        await _scoreService.CreateAsync(new ScoreDTO
                        {
                            TeamId = match.awayTeam.id,
                            Current = match.awayTeam.score.current,
                            ExtraTime = match.awayTeam.score.extraTime,
                            MatchId = match.id,
                            Regular = match.awayTeam.score.regular,
                            HalfTime = match.awayTeam.score.halfTime,
                            Penalties = match.awayTeam.score.penalties,
                        });


                        await _scoreService.CreateAsync(new ScoreDTO
                        {
                            TeamId = match.homeTeam.id,
                            Current = match.homeTeam.score.current,
                            ExtraTime = match.homeTeam.score.extraTime,
                            MatchId = match.id,
                            Regular = match.homeTeam.score.regular,
                            HalfTime = match.homeTeam.score.halfTime,
                            Penalties = match.homeTeam.score.penalties,
                        });

                        var homeTeamScoreId = _scoreService.GetByMatchIdAndTeamIdAsync(match.id
                            , match.homeTeam.id).Result.Result.Id;

                        var awayTeamScoreId = _scoreService.GetByMatchIdAndTeamIdAsync(match.id
                          , match.awayTeam.id).Result.Result.Id;

                        await _homeTeamService.CreateAsync(new HomeTeamDTO
                        {
                            HomeTeamId = match.homeTeam.id,
                            Name = match.homeTeam.name,
                            MediumName = match.homeTeam.mediumName,
                            ShortName = match.homeTeam.shortName,
                            ScoreId = homeTeamScoreId
                        });

                        await _awayTeamService.CreateAsync(new AwayTeamDTO
                        {
                            AwayTeamId = match.awayTeam.id,
                            Name = match.awayTeam.name,
                            MediumName = match.awayTeam.mediumName,
                            ShortName = match.homeTeam.shortName,
                            ScoreId = awayTeamScoreId
                        });

                        if (_statusService.GetByIdAsync(match.status.id).Result.Result == null)
                        {
                            await _statusService.CreateAsync(new StatusDTO
                            {
                                Id = match.status.id,
                                Name = match.status.name,
                                ShortName = match.status.shortName
                            });
                        }

                        if (_tournamentService.GetByIdAsync(match.tournament.id).Result.Result == null)
                        {
                            await _tournamentService.CreateAsync(new TournamentDTO
                            {
                                Id = match.tournament.id,
                                Name = match.tournament.name,
                                ShortName = match.tournament.shortName
                            });
                        }
                        if (_stageService.GetByIdAsync(match.stage.id).Result.Result == null)
                        {
                            await _stageService.CreateAsync(new StageDTO
                            {
                                Id = match.stage.id,
                                Name = match.stage.name,
                                ShortName = match.stage.shortName
                            });
                        }
                        if (_roundService.GetByIdAsync(match.round.id).Result.Result == null)
                        {
                            await _roundService.CreateAsync(new RoundDTO
                            {
                                Id = match.round.id,
                                Name = match.round.name,
                                ShortName = match.round.shortName
                            });
                        }

                        var AwayTeamId = _appDbContext.AwayTeams.SingleOrDefaultAsync(x => x.ScoreId == awayTeamScoreId && x.AwayTeamId == x.Score.TeamId).Result;
                        var HomeTeamId = _appDbContext.HomeTeams.SingleOrDefaultAsync(x => x.ScoreId == homeTeamScoreId && x.HomeTeamId == x.Score.TeamId).Result;
                        await _matchService.CreateAsync(new MatchDTO
                        {
                            AwayTeamId = AwayTeamId.Id,
                            HomeTeamId = HomeTeamId.Id,
                            MatchId = match.id,
                            RoundId = match.round.id,
                            StageId = match.stage.id,
                            Date = match.date,
                            TournamentId = match.tournament.id,
                            Stoppage = match.times == null ? null : match.times.stoppage,
                            CurrentMinute = match.times == null ? null : match.times.currentMinute
                        }); ;


                        Console.WriteLine(match.id + "'li maç kaydı tamamlandı");
                    }
                    else
                    {
                        await Console.Out.WriteLineAsync("Daha önce kayıt yapılmış:" + match.id);
                    }

                }
            }
        }
    }
}
