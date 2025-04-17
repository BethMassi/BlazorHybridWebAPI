using BlazorHybridWebAPI.Shared.Models;
using BlazorHybridWebAPI.Shared.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridWebAPI.Services
{
    public class WeatherService : IWeatherService
    {
        public async Task<WeatherForecast[]> GetWeatherForecastAsync(DateTime dateTime)
        {
            var forecasts = Array.Empty<WeatherForecast>();
            try
            {
                var httpClient = HttpClientHelper.GetHttpClient();
                var weatherUrl = $"{HttpClientHelper.WeatherUrl}?startDate={dateTime.ToShortDateString()}"; 

                forecasts = (await httpClient.GetFromJsonAsync<WeatherForecast[]>(weatherUrl)) ?? [];
            }
            catch (HttpRequestException httpEx)
            {
                Debug.WriteLine($"HTTP Request error: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }

            return forecasts;
        }
    }
}
