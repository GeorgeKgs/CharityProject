using CharityProject.Database;
using CharityProject.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CharityProject.Controllers
{
    public class CauseController : Controller
    {
        private CharityDBContext db;

        //Constructor
        public CauseController(CharityDBContext context)
        {
            db = context;
        }


        // GET: Cause

        public async Task<ActionResult> Index(string category, string NumberOfItems)
        {
            ViewBag.NumberOfItems = new List<string> { "3", "6", "9", "12", "24" };
            ViewBag.Categories = db.Plans.Select(p => p.Category.ToString()).Distinct();

            IndexVm viewModel = new IndexVm();

            if (category == "" || category == "Select Plan" || category == null)
            {
                if (NumberOfItems == "" || NumberOfItems == "All" || NumberOfItems == null)
                {
                    viewModel.Donations = await db.Donations.ToListAsync();
                    viewModel.Partners = await db.Partners.ToListAsync();
                    viewModel.Subscriptions = await db.Subscriptions.ToListAsync();
                    viewModel.Plans = await db.Plans.ToListAsync();
                }
                else 
                {
                    viewModel.Donations = await db.Donations.Take(Convert.ToInt32(NumberOfItems)).ToListAsync();
                    viewModel.Partners = await db.Partners.Take(Convert.ToInt32(NumberOfItems)).ToListAsync();
                    viewModel.Subscriptions = await db.Subscriptions.Take(Convert.ToInt32(NumberOfItems)).ToListAsync();
                    viewModel.Plans = await db.Plans.Take(Convert.ToInt32(NumberOfItems)).ToListAsync();
                }
            }
            else
            {
                if (NumberOfItems == "" || NumberOfItems == "Number of Items" || NumberOfItems == null)
                {
                    var Donations = await db.Donations.ToListAsync();
                    viewModel.Donations = Donations.Where(d => d.Plan.Category == category).ToList();
                    var Subscriptions = await db.Subscriptions.ToListAsync();
                    viewModel.Subscriptions = Subscriptions.Where(d => d.Plan.Category == category).ToList();
                    viewModel.Partners = await db.Partners.ToListAsync();
                    viewModel.Plans = await db.Plans.ToListAsync();
                }
                else
                {
                    var Donations = await db.Donations.ToListAsync();
                    viewModel.Donations = Donations.Where(d => d.Plan.Category == category).Take(Convert.ToInt32(NumberOfItems)).ToList();
                    var Subscriptions = await db.Subscriptions.ToListAsync();
                    viewModel.Subscriptions = Subscriptions.Where(d => d.Plan.Category == category).Take(Convert.ToInt32(NumberOfItems)).ToList();
                    viewModel.Partners = await db.Partners.Take(Convert.ToInt32(NumberOfItems)).ToListAsync();
                    viewModel.Plans = await db.Plans.Take(Convert.ToInt32(NumberOfItems)).ToListAsync();

                }

            }

              
            return View(viewModel);
        }

    }
}