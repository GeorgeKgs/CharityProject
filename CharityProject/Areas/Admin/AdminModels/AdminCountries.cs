using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharityProject.Areas.Admin.AdminModels
{
    public class AdminCountries
    {

        public List<string> Names { get; set; }
        public List<int> Numbers { get; set; }
        public List<string> Countries { get; set; }


        public AdminCountries()
        {
            Names = new List<string>();
            Countries = new List<string>();
            Numbers = new List<int>();
        }

    }
}