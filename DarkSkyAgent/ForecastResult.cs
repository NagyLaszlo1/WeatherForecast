using Newtonsoft.Json;

namespace Agents
{
    public class ForecastResult
    {
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }
    }
}