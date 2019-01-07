using Agents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models.Entities;

namespace WeatherForecast.Models
{
    public class WeatherForecastModel : IWeatherForecastModel
    {
        IDarkSkyAgent darkSkyAgent;
        public WeatherForecastModel(IDarkSkyAgent dsAgent)
        {
            darkSkyAgent = dsAgent;
        }

        public ObservableCollection<Language> ListLanguages()
        {
            ObservableCollection<Language> languages = new ObservableCollection<Language>();

            languages.Add(new Language
            {
                Code = "hu-Hu",
                Name = "Magyar"
            });

            languages.Add(new Language
            {
                Code = "en-GB",
                Name = "English"
            });

            return languages;
        }

        public ObservableCollection<City> ListCities()
        {
            ObservableCollection<City> cities = new ObservableCollection<City>();

            cities.Add(new City
            {
                Id = 1,
                Name = "Budapest",
                Latitude = 47.497913,
                Longitude = 19.040236
            });

            cities.Add(new City
            {
                Id = 1,
                Name = "Luxembourg",
                Latitude = 49.815273,
                Longitude = 6.129583
            });

            cities.Add(new City
            {
                Id = 1,
                Name = "Debrecen",
                Latitude = 47.533340,
                Longitude = 21.625210
            });
            cities.Add(new City
            {
                Id = 1,
                Name = "Pécs",
                Latitude = 46.071301,
                Longitude = 18.233141
            });
            cities.Add(new City
            {
                Id = 1,
                Name = "Wienna",
                Latitude = 48.209209,
                Longitude = 16.372780
            });
            cities.Add(new City
            {
                Id = 1,
                Name = "Prague",
                Latitude = 50.075539,
                Longitude = 14.437800
            });
            cities.Add(new City
            {
                Id = 1,
                Name = "München",
                Latitude = 48.135124,
                Longitude = 11.581981
            });
            cities.Add(new City
            {
                Id = 1,
                Name = "Amsterdam",
                Latitude = 52.370216,
                Longitude = 4.895168
            });

            return cities;
        }

        public ForecastResult LoadWeatherForecast(double lat, double lon)
        {
            return darkSkyAgent.GetForecast(lat, lon);
        }
    }
}
