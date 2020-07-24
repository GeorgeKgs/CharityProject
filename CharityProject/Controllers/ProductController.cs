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

   
    public class ProductController : Controller
    {

        private IGenericRepository<Product> db;


        //Constructor
        public ProductController(IGenericRepository<Product> repository)
        {
            this.db = repository;
        }



        // GET: Product
        public async Task<ActionResult> Index()
        {
            return View(await db.GetAll());
        }

        // GET: Product/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

      
    }
}
