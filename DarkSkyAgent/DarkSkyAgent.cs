using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastInfrastructure;

namespace Agents
{
    public class DarkSkyAgent : IDarkSkyAgent
    {
        public ForecastResult GetForecast(double lat, double lon, string langCode)
        {
            ForecastResult result = null;
            //"https://api.darksky.net/forecast/82d6033efe051b1620778e61c8901f3c/37.8267,-122.4233";
            string url = $"{ConfigHelper.GetDarkSkyUrl()}/{ConfigHelper.GetDarkSkyKey()}/{lat},{lon}?exclude=minutely,hourly,alerts&units=si&lang={langCode}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";

            string jsonResult;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                jsonResult = reader.ReadToEnd();
            }

            result = JsonConvert.DeserializeObject<ForecastResult>(jsonResult, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            return result;
        }
    }
}
