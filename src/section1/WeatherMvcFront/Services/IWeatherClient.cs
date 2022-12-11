using WeatherApi;

namespace WeatherMvcFront.Services;

public interface IWeatherClient
{
    Task<IEnumerable<WeatherForecast>?> GetWeather(string requestUri, CancellationToken cancellationToken);
}