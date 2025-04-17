using BlazorHybridWebAPI.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridWebAPI.Shared.Services
{
    public interface IWeatherService
    {
        Task<WeatherForecast[]> GetWeatherForecastAsync(DateTime startDate);
    }
}
