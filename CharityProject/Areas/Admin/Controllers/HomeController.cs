using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharityProject.Areas.Admin.Controllers
{

    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}