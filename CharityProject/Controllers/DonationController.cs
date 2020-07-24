using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CharityProject.Database;
using CharityProject.Entities.DomainClasses;
using CharityProject.Services;

namespace CharityProject.Controllers
{
    public class DonationController : Controller
    {
      
        private IGenericRepository<Donation> db;

        
        //Constructor
        public DonationController(IGenericRepository<Donation> repository)
        {
            this.db = repository;
          
        }


        // GET: Donation
        public async Task<ActionResult> Index()
        {           
            var donations = db.GetAll();
            return View(await donations);
        }

        // GET: Donation/Details/5

        [Authorize]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation =await db.GetById(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

           
    }
}
