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

        //public string WeatherRecommendation
        //{
        //    get
        //    {
        //        switch (Forecast)
        //        {
        //            case "snow":
        //                return "Pack snowshoes.";
        //            case "rain":
        //                return "Pack rain gear and wear waterproof shoes.";
        //            case "thunderstorms":
        //                return "Seek shelter and avoid hiking on exposed ridges.";
        //            case "sun":
        //                return "Pack sunblock.";
        //            default:
        //                return null;
        //        }
        //    }
        //}
        //public string TemperatureRecommendation
        //{
        //    get
        //    {
        //        if (High > 75 && High-Low > 20)
        //        {
        //            return "Bring an extra gallon of water and wear breathable layers.";
        //        }
        //        else if (High > 75)
        //        {
        //            return "Bring an extra gallon of water.";
        //        }
        //        else if (Low < 20 && High-Low > 20)
        //        {
        //            return "Wear breathable layers. Danger: Exposure to frigid temperatures.";
        //        }
        //        else if (Low < 20)
        //        {
        //            return "Danger: Exposure to frigid temperatures.";
        //        }

        //        return null;
        //    }
        //}
    }
}
