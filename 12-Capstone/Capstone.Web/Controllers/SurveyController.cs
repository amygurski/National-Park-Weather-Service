using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private IParkDAO parkSqlDAO;
        public SurveyController(IParkDAO parkSqlDAO)
        {
            this.parkSqlDAO = parkSqlDAO;
        }

        /// <summary>
        /// Displays user survey
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> parks = parkSqlDAO.GetParkNames();
            Survey survey = new Survey(parks);
            return View(survey);
        }
    }
}