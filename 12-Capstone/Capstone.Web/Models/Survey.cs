﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {

        //User selections and inputs to record for survey entry: Park Code, State of Residence, Email Address, and Activity Level
        //All 4 fields are required to submit the survey
        [Required(ErrorMessage = "* Required")]
        public string ParkCode { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string ResidenceState { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "enter email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string ActivityLevel { get; set; }

        //Options to display to user for activity levels (radio buttons), Parks (drop-down menu), and States (drop-down menu)
        public List<string> ActivityLevelOptions { get; } = new List<string> {"Inactive", "Sedentary", "Active", "Extremely Active"};
        public List<SelectListItem> Parks { get; set; }

        public List<SelectListItem> States = new List<SelectListItem>
        {
            new SelectListItem() {Text = "Alabama", Value = "AL"},
            new SelectListItem() {Text = "Alaska", Value = "AK"},
            new SelectListItem() {Text = "Arizona", Value = "AZ"},
            new SelectListItem() {Text = "Arkansas", Value = "AR"},
            new SelectListItem() {Text = "California", Value = "CA"},
            new SelectListItem() {Text = "Colorado", Value = "CO"},
            new SelectListItem() {Text = "Connecticut", Value = "CT"},
            new SelectListItem() {Text = "District of Columbia", Value = "DC"},
            new SelectListItem() {Text = "Delaware", Value = "DE"},
            new SelectListItem() {Text = "Florida", Value = "FL"},
            new SelectListItem() {Text = "Georgia", Value = "GA"},
            new SelectListItem() {Text = "Hawaii", Value = "HI"},
            new SelectListItem() {Text = "Idaho", Value = "ID"},
            new SelectListItem() {Text = "Illinois", Value = "IL"},
            new SelectListItem() {Text = "Indiana", Value = "IN"},
            new SelectListItem() {Text = "Iowa", Value = "IA"},
            new SelectListItem() {Text = "Kansas", Value = "KS"},
            new SelectListItem() {Text = "Kentucky", Value = "KY"},
            new SelectListItem() {Text = "Louisiana", Value = "LA"},
            new SelectListItem() {Text = "Maine", Value = "ME"},
            new SelectListItem() {Text = "Maryland", Value = "MD"},
            new SelectListItem() {Text = "Massachusetts", Value = "MA"},
            new SelectListItem() {Text = "Michigan", Value = "MI"},
            new SelectListItem() {Text = "Minnesota", Value = "MN"},
            new SelectListItem() {Text = "Mississippi", Value = "MS"},
            new SelectListItem() {Text = "Missouri", Value = "MO"},
            new SelectListItem() {Text = "Montana", Value = "MT"},
            new SelectListItem() {Text = "Nebraska", Value = "NE"},
            new SelectListItem() {Text = "Nevada", Value = "NV"},
            new SelectListItem() {Text = "New Hampshire", Value = "NH"},
            new SelectListItem() {Text = "New Jersey", Value = "NJ"},
            new SelectListItem() {Text = "New Mexico", Value = "NM"},
            new SelectListItem() {Text = "New York", Value = "NY"},
            new SelectListItem() {Text = "North Carolina", Value = "NC"},
            new SelectListItem() {Text = "North Dakota", Value = "ND"},
            new SelectListItem() {Text = "Ohio", Value = "OH"},
            new SelectListItem() {Text = "Oklahoma", Value = "OK"},
            new SelectListItem() {Text = "Oregon", Value = "OR"},
            new SelectListItem() {Text = "Pennsylvania", Value = "PA"},
            new SelectListItem() {Text = "Rhode Island", Value = "RI"},
            new SelectListItem() {Text = "South Carolina", Value = "SC"},
            new SelectListItem() {Text = "South Dakota", Value = "SD"},
            new SelectListItem() {Text = "Tennessee", Value = "TN"},
            new SelectListItem() {Text = "Texas", Value = "TX"},
            new SelectListItem() {Text = "Utah", Value = "UT"},
            new SelectListItem() {Text = "Vermont", Value = "VT"},
            new SelectListItem() {Text = "Virginia", Value = "VA"},
            new SelectListItem() {Text = "Washington", Value = "WA"},
            new SelectListItem() {Text = "West Virginia", Value = "WV"},
            new SelectListItem() {Text = "Wisconsin", Value = "WI"},
            new SelectListItem() {Text = "Wyoming", Value = "WY"}
        };
    }
}
