namespace WpfApp2.Weather;

public class WeatherForecast
{
    public DateTime Date { get; set; }
    public string Sky { get; set; }

    private List<decimal> _temperatures = new();

    public int Temperature => _temperatures.Count == 0 ? 0 : (int)Math.Round(_temperatures.Sum() / _temperatures.Count);

    public WeatherForecast(DateTime date, decimal temperature, string sky)
    {
        Date = date;
        Sky = sky;
        _temperatures.Add(temperature);
    }

    public void AddTemperature(decimal temperature)
    {
        _temperatures.Add(temperature);
    }
}