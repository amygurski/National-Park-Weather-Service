using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Park
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int ElevationInFeet { get; set; }
        public double MilesOfTrail { get; set; } 
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string InspirationalQuote { get; set; }
        public string InspirationalQuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public int EntryFee { get; set; }
        public int NumberOfAnimalSpecies { get; set; }
        public string LatLong //Latitude and Longitude for National Weather API by ParkCode
        {
            get
            {
                switch(ParkCode)
                {
                    case "CVNP":
                        return "41.2492,-81.7098";
                    case "ENP":
                        return "25.3471,-81.5055";
                    case "GCNP":
                        return "36.0910,-113.4050";
                    case "GNP":
                        return "48.6587,-114.4077";
                    case "GSMNP":
                        return "35.5807,-83.8121";
                    case "GTNP":
                        return "43.7616,-110.7852";
                    case "MRNP":
                        return "46.8597,-121.9958";
                    case "RMNP":
                        return "40.3503,-105.9573";
                    case "YNP":
                        return "44.5802,-111.6381";
                    case "YNP2":
                        return "37.8529,-119.832";
                    default:
                        return null;
                }
            }
        }

    }
}
