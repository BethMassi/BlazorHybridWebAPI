using BlazorHybridWebAPI.Shared.Models;
using BlazorHybridWebAPI.Shared.Services;

namespace BlazorHybridWebAPI.Web.Services
{
    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public async Task<WeatherForecast[]> GetWeatherForecastAsync(DateTime startDate)
        {
            // Simulate a delay for async operation so we can see the loading spinner
            await Task.Delay(1000);

            var rng = new Random();
            return await Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(startDate.AddDays(index)),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }

    }
}
