using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CharityProject.Controllers
{
    public class RouteAngularController : Controller
    {
        // GET: RouteAngular
        public ActionResult Events()
        {
            return PartialView();
        }


        public ActionResult Gallery()
        {
            return PartialView();
        }


        public ActionResult GetView(string View)
        {
            return PartialView(View);
        }
    }
} 
    