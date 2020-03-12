using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkDetailVM
    {
        public Park Park { get; set; }
        public IList<WeatherForecast> FiveDayWeather { get; set; }
        public string TemperatureUnit { get; set; }

    }
}
