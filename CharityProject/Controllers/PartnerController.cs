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
using PagedList;

namespace CharityProject.Controllers
{
    public class PartnerController : Controller
    {
        private CharityDBContext db;


        //Constructor
        public PartnerController(CharityDBContext context)
        {
            db = context;
        }


        // GET: Partner
        public async Task<ActionResult> Index(string searchPartner, int? page, int? pageSizedrop)
        {
            

            IQueryable<Partner> partners = null;
            ViewBag.NumberOfItems = new List<string> { "3", "6", "9", "12", "24" };
            int counter = db.Partners.Count();

            if (!String.IsNullOrEmpty(searchPartner))
            {
               
                page = 1;
                partners = db.Partners                             
                               .Where(p => p.Name.Contains(searchPartner))
                               .Include(p => p.Donations)
                               .Include(p => p.Subscriptions);

                return View(await partners.ToListAsync());
            }

            partners = db.Partners.Include(p => p.Donations).Include(p => p.Subscriptions).OrderBy(p => p.PartnerId);

            int pageSize = 3;

            if (pageSizedrop!=null && pageSizedrop <= counter)
                pageSize =(int)pageSizedrop;

            if (pageSizedrop > counter)
                pageSize = counter;

            ViewBag.pageSizedrop = pageSizedrop;
            int pageNumber = (page ?? 1);
            return View(partners.ToPagedList(pageNumber, pageSize ));
         
        }


        // GET: Partner/Details/5
        [Authorize]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = await db.Partners.FindAsync(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
