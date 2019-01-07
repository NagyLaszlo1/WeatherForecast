using System;
using System.ComponentModel;
using System.Windows;
using WeatherForecastInfrastructure;

namespace WeatherForecast.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void HandleException(Exception ex)
        {
            MessageBox.Show("A exception occurred: " + ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);

            // TODO - logging
        }
    }
}