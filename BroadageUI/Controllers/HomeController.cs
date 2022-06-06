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

        public HomeController(ILogger<HomeController> logger,IScoreService scoreService)
        {
            _logger = logger;
            _scoreService = scoreService;
          
        }

        public IActionResult Index()
        {
            var dene = _scoreService.GetAllAsync().Result;

            string key = "842824df-e28b-4ed9-90b9-b01f12102538";
            string languageId = "2";

            var matches = new List<Match>();

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

                matches = JsonConvert.DeserializeObject<List<Match>>(EmpResponse);
            }

            if (matches.Count != 0)
            {
                foreach (var match in matches)
                {

                }
            }
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
