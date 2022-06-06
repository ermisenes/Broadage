using AutoMapper;
using BroadageBusiness.AutoMapping;
using BroadageBusiness.Logger;
using BroadageBusiness.Services;
using BroadageData;
using BroadageData.Repositories;
using BroadageEntity;
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
using System.Threading.Tasks;

namespace BroadageConsoleApp
{
    public class Program
    {
        private static IScoreService _scoreService;
        private static IHomeTeamService _homeTeamService;
        private static IAwayTeamService _awayTeamService;
        private static BroadageDBContext _appDbContext;
        private static ILoggerManager _loggerManager;
        public Program(IScoreService scoreService, IHomeTeamService homeTeamService, IAwayTeamService awayTeamService, ILoggerManager loggerManager, BroadageDBContext broadageDBContext)
        {
            _appDbContext = broadageDBContext;
            _scoreService = scoreService;
            _homeTeamService = homeTeamService;
            _awayTeamService = awayTeamService;
            _loggerManager = loggerManager;
        }
         static void Main(string[] args)
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
            _appDbContext = serviceProvider.GetService<BroadageDBContext>();
            try
            {
                
                var de = _appDbContext.Scores.Find(1);
                var dene = _appDbContext.Set<Score>().Find(1);
                var dfsds = _appDbContext.Scores.FindAsync(1).Result;
                var dfsdas = _scoreService.GetAllAsync().Result;

                int gdfgfd = 1;
            }
            catch (Exception ex)
            {

            }


            string key = "842824df-e28b-4ed9-90b9-b01f12102538";
            string languageId = "2";

            var matches = new List<string>();

            //TODO: URL'e tarih yollamalıyız 7 gün önceki ve 7 gün sonraki maçlar olmak üzere bütün maçları çekecek bir uygulama yazılmalı.
            var todaysDate = DateTime.Now.ToShortDateString().Replace(".", "/");

            //Eğer gün tek haneli ise başına 0 ekle. Çünkü requestte başında 0 olması lazım.
            var day = todaysDate.IndexOf('/');
            if (day == 1)
            {
                todaysDate = String.Concat("0", todaysDate);
            }
            var url = $"https://s0-sports-data-api.broadage.com/soccer/match/list?date=05/06/2022";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
            client.DefaultRequestHeaders.Add("languageId", languageId);

            Task<HttpResponseMessage> Res = client.GetAsync(url);

            if (Res.Result.IsSuccessStatusCode)
            {

                var EmpResponse = Res.Result.Content.ReadAsStringAsync().Result;

                // matches = JsonConvert.DeserializeObject<List<Match>>(EmpResponse);
            }

            if (matches.Count != 0)
            {
                foreach (var match in matches)
                {

                }
            }
        }
    }
}
