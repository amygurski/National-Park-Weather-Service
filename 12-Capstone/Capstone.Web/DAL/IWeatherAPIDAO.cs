using Capstone.Web.Models;
using System.Collections.Generic;

namespace Capstone.Web.DAL
{
    public interface IWeatherAPIDAO
    {
        List<WeatherForecast> GetFiveDayWeatherForecast(string location);
    }
}