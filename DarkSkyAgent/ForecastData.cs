using Newtonsoft.Json;

namespace Agents
{
    public class ForecastData
    {
        [JsonProperty(PropertyName = "time")]
        public double Time { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "temperature")]
        public double Temperature { get; set; }

        [JsonProperty(PropertyName = "apparentTemperature")]
        public double ApparentTemperature { get; set; }

        [JsonProperty(PropertyName = "pressure")]
        public double Pressure { get; set; }

        [JsonProperty(PropertyName = "windSpeed")]
        public double WindSpeed { get; set; }

        [JsonProperty(PropertyName = "humidity")]
        public double Humidity { get; set; }

        [JsonProperty(PropertyName = "uvIndex")]
        public double UVIndex { get; set; }

        public string IconPath
        {
            get
            {
                return $"../Images/{Icon}.png";
            }
        }
    }


    //"time": 1546600165,
        //    "summary": "Partly Cloudy",
        //    "icon": "partly-cloudy-night",
        //    "nearestStormDistance": 1,
        //    "nearestStormBearing": 31,
        //    "precipIntensity": 0,
        //    "precipProbability": 0,
        //    "temperature": 45.39,
        //    "apparentTemperature": 44.4,
        //    "dewPoint": 33.22,
        //    "humidity": 0.62,
        //    "pressure": 1018.61,
        //    "windSpeed": 3.06,
        //    "windGust": 5.46,
        //    "windBearing": 94,
        //    "cloudCover": 0.28,
        //    "uvIndex": 0,
        //    "visibility": 8.32,
        //    "ozone": 262.5
}