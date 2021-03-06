﻿using System;
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
            if (!string.IsNullOrEmpty(Properties.Settings.Default.DarkSkyUrl))
                return Properties.Settings.Default.DarkSkyUrl;
            else
                return "https://api.darksky.net/forecast"; // Default Value
        }

        public static string GetDarkSkyKey()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.DarkSkyKey))
                return Properties.Settings.Default.DarkSkyKey;
            else
                return "82d6033efe051b1620778e61c8901f3c"; // Default Value
        }

        public static string GetLanguage()
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Language))
                return Properties.Settings.Default.Language;
            else
                return "en-GB"; // Default Value
        }

        public static void SaveLanguage(string languageCode)
        {
            Properties.Settings.Default.Language = languageCode;
            Properties.Settings.Default.Save();
        }
    }
}
