using System.Net.Http;
using System.Text.Json;

namespace WpfApp2.Weather;

static class WeatherForecasts
{
    public static async Task<WeatherForecast> GetForecastsList(DateTime date)
    {
        string apiKey = "a4d2b540f3a4b1856213f73aed1da230";
        string city = "Zhytomyr";
        string url = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={apiKey}&units=metric&lang=ua";

        using var client = new HttpClient();
        var json = await client.GetStringAsync(url);

        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        WeatherForecast? forecast = null;

        foreach (var item in root.GetProperty("list").EnumerateArray())
        {
            var dt = item.GetProperty("dt_txt").GetString();
            var temp_feels_like = item.GetProperty("main").GetProperty("feels_like").GetDecimal();
            var sky = item.GetProperty("weather")[0].GetProperty("description").GetString();
            DateTime dateTime_dt = DateTime.Parse(dt);

            if (dateTime_dt.Date == date.Date)
            {
                if (dateTime_dt.TimeOfDay > new TimeSpan(6, 0, 0))
                {
                    if (forecast is null)
                    {
                        forecast = new WeatherForecast(dateTime_dt, temp_feels_like, sky);
                    }
                    else
                    {
                        forecast.AddTemperature(temp_feels_like);
                    }
                }
            }
        }

        return forecast;
    }

}