using System;
using System.ComponentModel;
using System.Windows;
using WeatherForecastInfrastructure;
using WeatherForecastInfrastructure.Properties;

namespace WeatherForecast.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void HandleException(Exception ex)
        {
            MessageBox.Show(Resources.msgExceptionOccured + " " + ex.Message, Resources.msgTitleException, MessageBoxButton.OK, MessageBoxImage.Error);

            // TODO - logging
        }
    }
}