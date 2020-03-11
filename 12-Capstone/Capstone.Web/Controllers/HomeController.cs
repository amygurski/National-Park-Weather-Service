using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

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

        public IActionResult Detail(string parkCode)
        {
            ParkDetailVM vm = new ParkDetailVM();
            vm.Park = parkSqlDAO.GetPark(parkCode);
            vm.FiveDayWeather = weatherSqlDAO.GetFiveDayWeatherForecast(parkCode);

            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
