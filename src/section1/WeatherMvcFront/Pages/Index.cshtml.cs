using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherMvcFront.Services;

namespace WeatherMvcFront.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IWeatherClient _client;
    public IndexModel(ILogger<IndexModel> logger, IWeatherClient client)
    {
        _logger = logger;
        _client = client;
    }

    public async  Task OnGet()
    {
        await _client.GetWeather("/weatherforecast",new CancellationToken());

    }
}