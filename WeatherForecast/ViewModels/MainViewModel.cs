using Agents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WeatherForecast.Commands;
using WeatherForecast.Models;
using WeatherForecast.Models.Entities;
using WeatherForecastInfrastructure;
using WeatherForecastInfrastructure.Properties;

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
                OnPropertyChanged(nameof(Cities));
            }
        }

        private City _selectedCity;
        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity = value;
                OnPropertyChanged(nameof(SelectedCity));
            }
        }

        private ObservableCollection<Language> _languages;
        public ObservableCollection<Language> Languages
        {
            get { return _languages; }
            set
            {
                _languages = value;
                OnPropertyChanged(nameof(Languages));
            }
        }

        private Language _selectedLanguage;
        public Language SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged(nameof(SelectedLanguage));
            }
        }

        private List<ForecastData> _dailyForecastData;
        public List<ForecastData> DailyForecastData
        {
            get { return _dailyForecastData; }
            set
            {
                _dailyForecastData = value;
                OnPropertyChanged(nameof(DailyForecastData));
            }
        }

        private ForecastData _currentForecastData;
        public ForecastData CurrentForecastData
        {
            get { return _currentForecastData; }
            set
            {
                _currentForecastData = value;
                OnPropertyChanged(nameof(CurrentForecastData));
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

        private ICommand _languageChangeCommand;
        public ICommand LanguageChangeCommand
        {
            get
            {
                return _languageChangeCommand ?? (_languageChangeCommand = new ClickCommand(() => ChangeLanguage(), true));
            }
        }

        private void ChangeLanguage()
        {
            try
            {
                if (SelectedLanguage != null)
                {
                    ConfigHelper.SaveLanguage(SelectedLanguage.Code);
                    MessageBox.Show(Resources.msgRestartTheApp, Resources.lblNotification, MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void LoadWeatherForecast()
        {
            try
            {
                if (SelectedCity != null && SelectedLanguage != null)
                {
                    var forecastResult = wfModel.LoadWeatherForecast(SelectedCity.Latitude, SelectedCity.Longitude);
                    DailyForecastData = forecastResult.Daily.Data;
                    CurrentForecastData = forecastResult.Currently;
                }
            }
            catch(Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Init()
        {
            try
            {
                Cities = wfModel.ListCities();
                SelectedCity = Cities.First();
                Languages = wfModel.ListLanguages();
                SelectedLanguage = Languages.FirstOrDefault(x => x.Code == ConfigHelper.GetLanguage());
                LoadWeatherForecast();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
    }
}
