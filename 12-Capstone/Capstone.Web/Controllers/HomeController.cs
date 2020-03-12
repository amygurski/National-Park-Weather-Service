using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAO parkSqlDAO;
        private IWeatherDAO weatherSqlDAO;
        public HomeController(IParkDAO parkSqlDAO, IWeatherDAO weatherSqlDAO)
        {
            this.parkSqlDAO = parkSqlDAO;
            this.weatherSqlDAO = weatherSqlDAO;
        }

        /// <summary>
        /// Alphabetical listing of all the parks in the National Parks database.
        /// Displays image, name, and description
        /// </summary>
        public IActionResult Index()
        {
            IList<Park> parks = parkSqlDAO.GetParks();
            return View(parks);
        }

        /// <summary>
        /// Detailed view of the selected park 
        /// </summary>
        [HttpGet]
        public IActionResult Detail(string parkCode)
        {
            //Get the selected park
            ParkDetailVM vm = new ParkDetailVM();
            vm.Park = parkSqlDAO.GetPark(parkCode);

            //Get the user's preferred temperature units from session and store in view
            vm.TemperatureUnit = HttpContext.Session.GetString("TemperatureUnit");
            
            //If not set yet, set to default of Fahrenheit
            if (String.IsNullOrEmpty(vm.TemperatureUnit))
            {
               vm.TemperatureUnit = "F";
            }

            //Get weather forecast for selected park
            vm.FiveDayWeather = weatherSqlDAO.GetFiveDayWeatherForecast(parkCode);

            return View(vm);
        }

        /// <summary>
        /// For if the user changes temperature
        /// </summary>
        [HttpPost]
        public IActionResult Detail(string parkCode, string unit)
        {
            // Write the NEW LastAccess time to session so we can get it next time
            HttpContext.Session.SetString("TemperatureUnit", unit);

            return RedirectToAction("Detail", new { parkCode });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
