using CharityProject.Areas.Admin.AdminModels;
using CharityProject.Areas.Admin;
using CharityProject.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CharityProject.Areas.Admin.Controllers
{

    [Authorize(Roles = "admin")]
    public class StatisticsController : Controller
    {

        private CharityDBContext db;

        //Constructor
        public StatisticsController(CharityDBContext context)
        {
            db = context;
        }




        [HttpPost]
        public JsonResult GetSignatures()
        {

            var signatures = db.Signatures.Count();

            return Json(signatures, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult GetProducts()
        {

            var products = db.Products.Count();

            return Json(products, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GetPartners()
        {

            var partners = db.Partners.Count();

            return Json(partners, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult GetDonations()
        {

            var donations = db.Donations.Count();

            return Json(donations, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GetSubscriptions()
        {

            var subscriptions = db.Donations.Count();

            return Json(subscriptions, JsonRequestBehavior.AllowGet);

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


            return Json(Numbers, JsonRequestBehavior.AllowGet);

        }



        [HttpPost]
        public JsonResult PartnersDonations()
        {
            JsonObject jsonList = new JsonObject();


            foreach (var item in db.Partners.ToList())
            {

                jsonList.Names.Add(item.Name);
                jsonList.Numbers.Add(item.Donations.Count());
  
            }

            return  Json(jsonList, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult PartnersSubs()
        {
            JsonObject jsonList = new JsonObject();


            foreach (var item in db.Partners.ToList())
            {

                jsonList.Names.Add(item.Name);
                jsonList.Numbers.Add(item.Subscriptions.Count());

            }

            return Json(jsonList, JsonRequestBehavior.AllowGet);

        }



        [HttpPost]
        public JsonResult PartnersCountries()
        {
            AdminCountries countries = new AdminCountries();


            foreach (var item in db.Partners.ToList())
            {

                countries.Names.Add(item.Name);
                countries.Numbers.Add(item.Subscriptions.Count() + item.Donations.Count());
                countries.Countries.Add(item.Country);
            }

            return Json(countries, JsonRequestBehavior.AllowGet);

        }

    }



}