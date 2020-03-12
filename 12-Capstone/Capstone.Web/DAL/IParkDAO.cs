using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.DAL
{
    public interface IParkDAO
    {
        IList<Park> GetParks();
        Park GetPark(string parkCode);
        List<SelectListItem> GetParkNames();
    }
}
