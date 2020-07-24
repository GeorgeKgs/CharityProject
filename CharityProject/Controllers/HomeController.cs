using CharityProject.Database;
using CharityProject.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CharityProject.Controllers
{
    public class HomeController : Controller
    {
        private CharityDBContext db;



        //Constructor
        public HomeController(CharityDBContext context)
        {
            db = context;
        }



        public async Task<ActionResult> Index()
        {
            IndexVm viewModel = new IndexVm();

            viewModel.Donations = await db.Donations.ToListAsync();
            viewModel.Subscriptions = await db.Subscriptions.ToListAsync();
            viewModel.Partners = await db.Partners.Include(p => p.Donations).Include(p => p.Subscriptions).ToListAsync();           
            viewModel.Plans = await db.Plans.Include(p => p.Donations).Include(p => p.Subscriptions).ToListAsync();

            return View(viewModel);
        }


        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult AboutuS()
        {
            ViewBag.Message = "About Us page.";

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }


        public ActionResult Success()
        {
            return View();
        }

        
        public ActionResult Failure()
        {
            return View();
        }


        public ActionResult SetPage()
        {

            if (!User.IsInRole("admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Dashboard", "Home", new { area = "Admin" });
            }

        }


    }
}