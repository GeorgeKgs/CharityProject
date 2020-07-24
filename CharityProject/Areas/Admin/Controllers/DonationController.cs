using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CharityProject.Database;
using CharityProject.Entities.DomainClasses;

namespace CharityProject.Areas.Admin.Controllers
{

    [Authorize(Roles = "admin")]
    public class DonationController : Controller
    {
        private CharityDBContext db;


        //Constructor
        public DonationController(CharityDBContext context)
        {
            db = context;
        }



        // GET: Admin/Donation
        public async Task<ActionResult> Index()
        {
            var donations = db.Donations.Include(d => d.Partner).Include(d => d.Plan);
            return View(await donations.ToListAsync());
        }

        // GET: Admin/Donation/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = await db.Donations.FindAsync(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // GET: Admin/Donation/Create
        public ActionResult Create()
        {
            ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name");
            ViewBag.PlanId = new SelectList(db.Plans, "PlanId", "Category");
            return View();
        }

        // POST: Admin/Donation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DonationId,Title,Description,Price,PlanId,PartnerId")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Donations.Add(donation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name", donation.PartnerId);
            ViewBag.PlanId = new SelectList(db.Plans, "PlanId", "Category", donation.PlanId);
            return View(donation);
        }

        // GET: Admin/Donation/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = await db.Donations.FindAsync(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name", donation.PartnerId);
            ViewBag.PlanId = new SelectList(db.Plans, "PlanId", "Category", donation.PlanId);
            return View(donation);
        }

        // POST: Admin/Donation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DonationId,Title,Description,Price,PlanId,PartnerId")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name", donation.PartnerId);
            ViewBag.PlanId = new SelectList(db.Plans, "PlanId", "Category", donation.PlanId);
            return View(donation);
        }

        // GET: Admin/Donation/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = await db.Donations.FindAsync(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Admin/Donation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Donation donation = await db.Donations.FindAsync(id);
            db.Donations.Remove(donation);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
