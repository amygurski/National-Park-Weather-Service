﻿using System;
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
        public HomeController(IParkDAO parkSqlDAO)
        {
            this.parkSqlDAO = parkSqlDAO;
        }

        /// <summary>
        /// Alphabetical listing of all the parks in the National Parks database.
        /// Displays image, name, and description
        /// </summary>
        public IActionResult Index()
        {
            IList<Park> park = parkSqlDAO.GetParks();
            return View(park);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
