using Microsoft.AspNetCore.Mvc;

namespace AsyncStreamsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IAsyncEnumerable<WeatherForecast> Get()
    {
        return AsyncEnumerable.Range(1, 6)
            .Do(async x => await Task.Delay(2000))
            .Select(i => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(i),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
    }
    private async IAsyncEnumerable<WeatherForecast> Get_v2()
    {
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            yield return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(i),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }
    }
}