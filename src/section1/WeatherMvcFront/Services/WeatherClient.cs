using WeatherApi;

namespace WeatherMvcFront.Services;

public class WeatherClient : IWeatherClient
{
    private readonly HttpClient _httpClient;

    public WeatherClient(HttpClient httpClient )
    {
        _httpClient = httpClient ?? throw new AggregateException(nameof(httpClient));
    }
    public async Task<IEnumerable<WeatherForecast>?> GetWeather(string requestUri, CancellationToken cancellationToken)
        => await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>(requestUri,cancellationToken);

}