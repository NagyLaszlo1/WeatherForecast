using Newtonsoft.Json;
using System.Collections.Generic;

namespace Agents
{
    public class DailyData
    {
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<ForecastData> Data { get; set; }
    }
}