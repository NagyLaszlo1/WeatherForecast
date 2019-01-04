using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;
using WeatherForecast.Models.Entities;

namespace WeatherForecast.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private IWeatherForecastModel wfModel { get; set; }
        public MainViewModel(IWeatherForecastModel weatherFModel)
        {
            wfModel = weatherFModel;
        }

        private ObservableCollection<City> _cities;
        public ObservableCollection<City> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                OnPropertyChanged("Cities"); // TODO -- Repleace buildable property
            }
        }

        private City _selectedCity;
        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity = value;
                OnPropertyChanged("SelectedCity"); // TODO -- Repleace buildable property
            }
        }

        public void Init()
        {
            Cities = wfModel.ListCities();
        }
    }
}
