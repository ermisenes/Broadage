using BroadageBusiness.Logger;
using BroadageEntity.IServices;
using BroadageUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace BroadageUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IMatchService _matchService;
        public HomeController(ILoggerManager loggerManager, IMatchService matchService)
        {
            _loggerManager = loggerManager;
            _matchService = matchService;
        }

        public  IActionResult Index()
        {
            var result = _matchService.GetMatchListAll().Result.Result;
            _loggerManager.LogInfo("Veri getirildi");
            return View(result);
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
