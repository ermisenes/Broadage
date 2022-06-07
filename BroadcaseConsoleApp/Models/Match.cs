using BroadageConsoleApp.Models;
using Newtonsoft.Json;
using System;

namespace BroadcaseConsoleApp.Models
{
    public class JsonMatch
    {
        public JsonHomeTeam homeTeam { get; set; }
        public JsonAwayTeam awayTeam { get; set; }
        public JsonStatus status { get; set; }
        public DateTime date { get; set; }
        public int id { get; set; }
        public JsonTournament tournament { get; set; }
        public JsonStage stage { get; set; }
        public JsonRound round { get; set; }

        [JsonProperty("times")]
        public JsonTimes times { get; set; }
    }
}


