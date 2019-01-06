using Agents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherForecast.Commands;
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

        private List<ForecastData> _dailyForecastData;
        public List<ForecastData> DailyForecastData
        {
            get { return _dailyForecastData; }
            set
            {
                _dailyForecastData = value;
                OnPropertyChanged("DailyForecastData"); // TODO -- Repleace buildable property
            }
        }

        private ForecastData _currentForecastData;
        public ForecastData CurrentForecastData
        {
            get { return _currentForecastData; }
            set
            {
                _currentForecastData = value;
                OnPropertyChanged("CurrentForecastData"); // TODO -- Repleace buildable property
            }
        }

        private ICommand _weatherRequestCommand;
        public ICommand WeatherRequestCommand
        {
            get
            {
                return _weatherRequestCommand ?? (_weatherRequestCommand = new ClickCommand(() => LoadWeatherForecast(), true));
            }
        }

        public void LoadWeatherForecast()
        {
            if (SelectedCity != null)
            {
                var forecastResult = wfModel.LoadWeatherForecast(SelectedCity.Latitude, SelectedCity.Longitude);
                DailyForecastData = forecastResult.Daily.Data;
                CurrentForecastData = forecastResult.Currently;
            }
        }

        public void Init()
        {
            Cities = wfModel.ListCities();
        }
    }
}
