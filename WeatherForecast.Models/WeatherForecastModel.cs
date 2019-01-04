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
        public ObservableCollection<City> ListCities()
        {
            ObservableCollection<City> cities = new ObservableCollection<City>();

            cities.Add(new City
            {
                Id = 1,
                Name = "Budapest",
                Latitude = 37.8267,
                Longitude = -122.4233
            });

            cities.Add(new City
            {
                Id = 1,
                Name = "Luxembourg",
                Latitude = 37.8267,
                Longitude = -122.4233
            });

            return cities;
        }
    }
}
