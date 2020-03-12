using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyResultVM
    {
        public int Votes { get; set; } //Count of the votes per park
        public string ParkCode { get; set; } //For the image (matches file name)
        public string ParkName { get; set; }
    }
}
