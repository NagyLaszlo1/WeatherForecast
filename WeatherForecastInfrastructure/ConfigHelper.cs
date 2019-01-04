using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastInfrastructure
{
    public class ConfigHelper
    {
        public static string GetDarkSkyUrl()
        {
            // TODO Use AppConfig !!!!
            return "https://api.darksky.net/forecast";
        }

        public static string GetDarkSkyKey()
        {
            // TODO Use AppConfig !!!!
            return "82d6033efe051b1620778e61c8901f3c";
        }
    }
}
