using BroadcaseConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BroadageConsoleApp
{
    public class Program
    {
        public static  void Main(string[] args)
        {
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
            var url = $"https://s0-sports-data-api.broadage.com/soccer/match/list?date=29/05/2022";
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
                    var matchID = match.id;
                    var away = match.awayTeam.id;
                    var home=match.homeTeam.id;
                    Console.WriteLine("Maç ID:" + matchID+" Misarif:" + away+ " Evsahibi:" + home + "\n");
                    //var dbControlMatches = EfCoreMatchRepository.ControlMatchDetails(match).Result;
                    // var dbControlMatches = ControlMatchDetails(match).Result;
                }
            }
        }
    }
}
