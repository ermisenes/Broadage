using BroadageConsoleApp.Models;
using Newtonsoft.Json;
using System;

namespace BroadcaseConsoleApp.Models
{
    public class Match
    {
        public HomeTeam homeTeam { get; set; }
        public AwayTeam awayTeam { get; set; }
        public Status status { get; set; }
        public string date { get; set; }
        public int id { get; set; }
        public Tournament tournament { get; set; }
        public Stage stage { get; set; }
        public Round round { get; set; }
        [JsonProperty("times")]
        public Times times { get; set; }
    }

    /*
    public partial class Match
    {
        [JsonProperty("homeTeam")]
        public Team HomeTeam { get; set; }

        [JsonProperty("awayTeam")]
        public Team AwayTeam { get; set; }

        [JsonProperty("status")]
        public Round Status { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("tournament")]
        public Round Tournament { get; set; }

        [JsonProperty("stage")]
        public Round Stage { get; set; }

        [JsonProperty("round")]
        public Round Round { get; set; }

        [JsonProperty("times")]
        public Times Times { get; set; }
    }

    public partial class Team
    {
        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        public Score Score { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("mediumName")]
        public string MediumName { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public partial class Score
    {
        [JsonProperty("regular")]
        public long? Regular { get; set; }

        [JsonProperty("halfTime")]
        public long? HalfTime { get; set; }

        [JsonProperty("current")]
        public long? Current { get; set; }

        [JsonProperty("extraTime")]
        public long? ExtraTime { get; set; }

        [JsonProperty("penalties")]
        public long? Penalties { get; set; }

    }

    public partial class Round
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public partial class Times
    {
        [JsonProperty("currentMinute")]
        public int? CurrentMinute { get; set; }

        [JsonProperty("stoppage")]
        public int? Stoppage { get; set; }
    }*/
}


