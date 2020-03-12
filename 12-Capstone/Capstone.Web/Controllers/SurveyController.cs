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
        /// Displays the user survey
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            Survey survey = new Survey();

            //Get the park names for the drop-down selection
            List<SelectListItem> parks = parkSqlDAO.GetParkNames();
            survey.Parks = parks;

            return View(survey);
        }

        /// <summary>
        /// Save the survey to the database and redirect back to the park Detail page
        /// </summary>
        [HttpPost]
        public IActionResult Index(Survey survey)
        {
            //Check that user input is valid. If not, remember entries but return survey page for user to complete form
            if (!ModelState.IsValid)
            {
                List<SelectListItem> parks = parkSqlDAO.GetParkNames();
                survey.Parks = parks;
                return View(survey);
            }
            
            //Save survey to database
            bool surveySaved = surveyResultsSqlDAO.SaveSurvey(survey);

            //Save this message temporarily to show success on top of survey results page
            TempData["Message"] = "Your vote has been logged.";

            return RedirectToAction("SurveyResults");
        }

        /// <summary>
        /// Display survey results from the park with the most votes to least.
        /// Parks that haven't been voted for aren't shown.
        /// </summary>
        public IActionResult SurveyResults()
        {
            IList<SurveyResultVM> results = surveyResultsSqlDAO.GetSurveyResults();
            return View(results);
        }
    }
}