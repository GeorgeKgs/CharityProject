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
    public class SubscriptionController : Controller
    {

        private IGenericRepository<Subscription> db;


        //Constructor
        public SubscriptionController(IGenericRepository<Subscription> repository)
        {
            this.db = repository;
        }




        // GET: Subscription
        public async Task<ActionResult> Index()
        {          
            return View(await db.GetAll());
        }

        // GET: Subscription/Details/5
        [Authorize]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = await db.GetById(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }
     

    
    }
}
