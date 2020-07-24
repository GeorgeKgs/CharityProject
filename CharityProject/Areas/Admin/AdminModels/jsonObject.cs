using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharityProject.Areas.Admin.AdminModels
{

    public class JsonObject
    {
        public List<string> Names { get; set; }
        public List<int> Numbers { get; set; }

        public JsonObject()
        {
            Names = new List<string>();
            Numbers = new List<int>();
        }
    }
}