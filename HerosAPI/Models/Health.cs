using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerosAPI.Models
{
    public class Health
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("totalDuration")]
        public string TotalDuration { get; set; }

        [JsonProperty("entries")]
        public List<Array[]> Entries { get; set; }
    }
}
