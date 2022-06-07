using BroadageBusiness;
using BroadageEntity.DTOs;
using BroadageEntity.IServices;
using BroadageUI.Models;
using BroadcaseConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BroadageUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IScoreService _scoreService;
        private readonly IMatchService _matchService;
        private readonly IHomeTeamService _homeTeamService;
        private readonly IAwayTeamService _awayTeamService;


        public HomeController(ILogger<HomeController> logger, IMatchService matchService, IHomeTeamService homeTeamService, IAwayTeamService awayTeamService)
        {
            _logger = logger;
            _matchService = matchService;
            _homeTeamService = homeTeamService;
            _awayTeamService = awayTeamService;
        }

        public IActionResult Index()
        {
            var dfsasd = _matchService.GetByIdAsync(10).Result;
            var derw = _matchService.GetAllAsync().Result;

            var qwe = _homeTeamService.GetAllAsync().Result;
            var qwqwe = _awayTeamService.GetAllAsync().Result;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
