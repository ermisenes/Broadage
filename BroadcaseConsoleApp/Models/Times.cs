using Newtonsoft.Json;
using System;

namespace BroadageConsoleApp.Models
{
    public class Times
    {
        [JsonProperty("currentMinute")]
        public Nullable<int> currentMinute { get; set; }
        [JsonProperty("stoppage")]
        public Nullable<int> stoppage { get; set; }
    }
}
