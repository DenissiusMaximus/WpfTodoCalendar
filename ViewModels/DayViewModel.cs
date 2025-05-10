using System.ComponentModel;
using Calendar.Data;
using Calendar.Models;

namespace Calendar;

public class DayViewModel : EventsAssign
{
    public override DateTime Date { get; set; }
    public string FormattedDate { get; set; }
    public string FormattedShortDate { get; set; }
    public string FormattedTime { get; set; }

    public DayViewModel(DateTime date)
    {
        this.Date = date;
        this.FormattedDate = date.ToString("dd.MM.yyyy");
        this.FormattedShortDate = date.ToString("dd/MM");
        this.FormattedTime = date.ToString("HH:mm");
        
        LoadEventsAsync();
    }

    public async Task LoadEventsAsync()
    {
        var rep = new EventRepository();
        var events = await rep.GetByDateAsync(Date);
        
        foreach (var e in events)
        {
            AddSingleEvent(new DayEventViewModel(e));
        }
    }
}

public class WeekDayViewModel : DayViewModel, INotifyPropertyChanged
{
    private WeatherForecast? _weatherForecast;
    public string? Temperature => _weatherForecast != null ? $"{_weatherForecast?.Temperature}°C " : null;
    public string? Sky => _weatherForecast != null ? _weatherForecast.Sky : null;

    public WeekDayViewModel(DateTime date) : base(date)
    {
        LoadEventsAsync();
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