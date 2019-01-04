using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models.Entities;

namespace WeatherForecast.Models
{
    public interface IWeatherForecastModel
    {
        ObservableCollection<City> ListCities();
    }
}
