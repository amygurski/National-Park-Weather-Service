using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class WeatherForecast
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; } //Default - Fahrenheit 
        public int High { get; set; } //Default - Fahrenheit
        public string Forecast { get; set; }

        //Derived properties for Celcius conversion
        public double LowCelcius
        {
            get
            {
                return (Low - 32) * (5.0/9.0);
            }
        }

        public double HighCelcius
        {
            get
            {
                return (High - 32) * (5.0/9.0);
            }
        }

        public string Image { get; set; }

        public string Day { get; set; } //Weather forecast day of week from API

        // Make recommendations to the page visitor depending on the forecast
        public string WeatherRecommendation
        {
            get
            {
                switch (Forecast)
                {
                    case "snow":
                        return "Pack snowshoes.";
                    case "rain":
                        return "Pack rain gear and wear waterproof shoes.";
                    case "thunderstorms":
                        return "Seek shelter and avoid hiking on exposed ridges.";
                    case "sunny":
                        return "Pack sunblock.";
                    default:
                        return null;
                }
            }
        }

        // Make recommendations to the page visitor for certain temperature conditions
        public string TemperatureRecommendation
        {
            get
            {
                string recommendation = null;

                if (High > 75)
                {
                    recommendation += "Bring an extra gallon of water.";
                }

                if (High - Low > 20)
                {
                    recommendation += "Wear breathable layers.";
                }

                if (Low < 20)
                {
                    return "Danger: Exposure to frigid temperatures.";
                }

                return recommendation;
            }
        }
    }
}
