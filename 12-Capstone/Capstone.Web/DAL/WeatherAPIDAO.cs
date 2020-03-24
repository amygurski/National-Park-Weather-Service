using Capstone.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static Capstone.Web.Models.Forecast_Root;

namespace Capstone.Web.DAL
{
    public class WeatherAPIDAO : IWeatherAPIDAO
    {
        public List<WeatherForecast> GetFiveDayWeatherForecast(string location)
        {
            List<WeatherForecast> output = new List<WeatherForecast>();

            //Use latitude and longitude for initial API request
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Only a test!");
            string response = client.DownloadString("https://api.weather.gov/points/" + location);

            //Get forecast details from that response
            WeatherLatToPoint root = JsonConvert.DeserializeObject<WeatherLatToPoint>(response);
            client = new WebClient();
            client.Headers.Add("user-agent", "Only a test!");
            response = client.DownloadString(root.properties.forecast);
            Forecast_Root forecast = JsonConvert.DeserializeObject<Forecast_Root>(response);


            int tempHigh = 0;
            string tempForecast = "", tempImage = "", tempDay = "";
            //Read each of the 5 days weather and add them to the weather forecast list
            //The API has 2 periods per day, one daytime and one nighttime
            foreach (Period period in forecast.properties.periods)
            {
                WeatherForecast weather = new WeatherForecast();

                //Found an issue that if it's before the start time (early morning, 7 or 8 am), it shows the overnight temperature first
                //We want to start with a part visit that day, so just skip the overnight temperature
                //This has it start with the next day and will automatically print the next Day over the forecast rather than Today
                if (period.number == 1 && !period.isDaytime)
                {
                    continue;
                }

                //Temporarily store daytime forecast to record on the next iteration
                if (period.isDaytime)
                {
                    tempHigh = period.temperature;
                    tempForecast = period.shortForecast;
                    tempImage = period.icon;
                    tempDay = period.name;
                }

                //Store overnight temperatures as lows and add to the daily weather forecast list
                if (!period.isDaytime)
                {
                    weather.Low = period.temperature;
                    weather.High = tempHigh;
                    weather.Forecast = tempForecast;
                    weather.Image = tempImage;
                    weather.Day = tempDay;
                    weather.FiveDayForecastValue = output.Count() + 1;
                    output.Add(weather);
                }

                //API contains 7 day forecast but we only want 5 days
                if (weather.FiveDayForecastValue == 5)
                {
                    break;
                }
            }
            return output;
        }
    }
}
