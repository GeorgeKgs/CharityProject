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
    public class SubscriptionController : Controller
    {
        private CharityDBContext db;


        //Constructor
        public SubscriptionController(CharityDBContext context)
        {
            db = context;
        }


        // GET: Admin/Subscription
        public async Task<ActionResult> Index()
        {
            var subscriptions = db.Subscriptions.Include(s => s.Partner).Include(s => s.Plan);
            return View(await subscriptions.ToListAsync());
        }

        // GET: Admin/Subscription/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = await db.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // GET: Admin/Subscription/Create
        public ActionResult Create()
        {
            ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name");
            ViewBag.PlanId = new SelectList(db.Plans, "PlanId", "Category");
            return View();
        }

        // POST: Admin/Subscription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,PlanId,PartnerId")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Subscriptions.Add(subscription);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name", subscription.PartnerId);
            ViewBag.PlanId = new SelectList(db.Plans, "PlanId", "Category", subscription.PlanId);
            return View(subscription);
        }

        // GET: Admin/Subscription/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = await db.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name", subscription.PartnerId);
            ViewBag.PlanId = new SelectList(db.Plans, "PlanId", "Category", subscription.PlanId);
            return View(subscription);
        }

        // POST: Admin/Subscription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,PlanId,PartnerId")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscription).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name", subscription.PartnerId);
            ViewBag.PlanId = new SelectList(db.Plans, "PlanId", "Category", subscription.PlanId);
            return View(subscription);
        }

        // GET: Admin/Subscription/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = await db.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // POST: Admin/Subscription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Subscription subscription = await db.Subscriptions.FindAsync(id);
            db.Subscriptions.Remove(subscription);
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
