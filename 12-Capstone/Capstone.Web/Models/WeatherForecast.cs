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
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public string ImageName
        {
            get
            {
                //remove spaces from forecast to get image name
                string image = Forecast.Replace(" ", String.Empty);
                return image;
            }
        }

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
                    case "sun":
                        return "Pack sunblock.";
                    default:
                        return null;
                }
            }
        }
        public string TemperatureRecommendation
        {
            get
            {
                string recommendation = null;

                if (High > 75)
                {
                    recommendation += "Bring an extra gallon of water. ";
                }

                if (High - Low > 20)
                {
                    recommendation += "Wear breathable layers. ";
                }

                if (Low < 20)
                {
                    return "Danger: Exposure to frigid temperatures. ";
                }

                return recommendation;
            }
        }
    }
}
