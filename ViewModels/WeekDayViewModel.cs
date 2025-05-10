using Calendar;
using System.ComponentModel;

namespace WpfApp2.ViewModels
{
    public class WeekDayViewModel : DayViewModel, INotifyPropertyChanged
    {
        private WeatherForecast? _weatherForecast;
        public string? Temperature => _weatherForecast != null ? $"{_weatherForecast?.Temperature}°C " : null;
        public string? Sky => _weatherForecast != null ? _weatherForecast.Sky : null;

        public WeekDayViewModel(DateTime date) : base(date)
        {
            LoadWeatherForecastAsync(date);
        }


        private async Task LoadWeatherForecastAsync(DateTime date)
        {
            _weatherForecast = await WeatherForecasts.GetForecastsList(date);
            OnPropertyChanged(nameof(Temperature));
            OnPropertyChanged(nameof(Sky));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
