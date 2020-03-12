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
        private ISurveyResultsDAO surveyResultsSqlDAO;
        public SurveyController(IParkDAO parkSqlDAO, ISurveyResultsDAO surveyResultsSqlDAO)
        {
            this.parkSqlDAO = parkSqlDAO;
            this.surveyResultsSqlDAO = surveyResultsSqlDAO;
        }

        /// <summary>
        /// Displays user survey
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            Survey survey = new Survey();
            List<SelectListItem> parks = parkSqlDAO.GetParkNames();
            survey.Parks = parks;

            return View(survey);
        }

        [HttpPost]
        public IActionResult Index(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> parks = parkSqlDAO.GetParkNames();
                survey.Parks = parks;
                return View(survey);
            }

            bool surveySaved = surveyResultsSqlDAO.SaveSurvey(survey);

            TempData["Message"] = "Your vote has been logged.";

            return RedirectToAction("SurveyResults");
        }

        public IActionResult SurveyResults()
        {
            IList<SurveyResultVM> results = surveyResultsSqlDAO.GetSurveyResults();
            return View(results);
        }
    }
}