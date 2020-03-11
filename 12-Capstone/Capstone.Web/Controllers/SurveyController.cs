using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private IParkDAO parkSqlDAO;
        public SurveyController(IParkDAO parkSqlDAO)
        {
            this.parkSqlDAO = parkSqlDAO;
        }
        [HttpGet]
        public IActionResult Index()
        {
            Survey survey = new Survey();

            return View(survey);
        }
    }
}