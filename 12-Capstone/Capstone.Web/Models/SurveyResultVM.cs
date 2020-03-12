using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyResultVM
    {
        public int Votes { get; set; }
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
    }
}
