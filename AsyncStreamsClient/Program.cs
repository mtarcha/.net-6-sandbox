// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using AsyncStreamsClient;

using var httpClient = new HttpClient();

using var forecastResponse = await httpClient.GetAsync(
    "http://localhost:5209/WeatherForecast",
    HttpCompletionOption.ResponseHeadersRead);

var stream = await forecastResponse.Content.ReadAsStreamAsync();
IAsyncEnumerable<WeatherForecast> forecasts = JsonSerializer.DeserializeAsyncEnumerable<WeatherForecast>(
    stream,
    new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        DefaultBufferSize = 128
    });

await foreach (var forecast in forecasts)
{
    Console.WriteLine(JsonSerializer.Serialize(forecast));
}