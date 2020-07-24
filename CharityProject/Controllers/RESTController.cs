using CharityProject.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharityProject.Controllers
{
    public class RESTController : Controller
    {
        private CharityDBContext db;


        //Constructor
        public RESTController(CharityDBContext context)
        {
            db = context;
        }



        [HttpPost]
        public JsonResult GetStats()
        {
            List<int> Numbers = new List<int>();

            var donations = db.Donations.Count();
            Numbers.Add(donations);
            var subscriptions = db.Subscriptions.Count();
            Numbers.Add(subscriptions);
            var partners = db.Partners.Count();
            Numbers.Add(partners);
            var signatures = db.Signatures.Count();
            Numbers.Add(signatures);
            var products = db.Products.Count();
            Numbers.Add(products);

            var data = Numbers.Sum();

            return Json(data, JsonRequestBehavior.AllowGet);

        }
    }
    
}