using CharityProject.Database;
using CharityProject.Entities.DomainClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CharityProject.Controllers
{
    public class MapController : Controller
    {
        private CharityDBContext db;

        //Constructor
        public MapController(CharityDBContext context)
        {
            db = context;
        }


        public JsonResult GetLocations()
        {

            var pointers = from partner in db.Partners
                        select new { partner.Name, 
                                     partner.Country, 
                                     partner.Description,
                                     partner.Latitude, 
                                     partner.Longitude,
                                     partner.ImageUrl
                        };

            return Json(pointers, JsonRequestBehavior.AllowGet);

        }
    }
}