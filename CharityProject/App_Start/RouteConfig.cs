using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CharityProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                        name: "RouteAngular",
                        url: "RouteAngular/{action}/{id}",
                        defaults: new { controller = "RouteAngular", action = "GetView", id = UrlParameter.Optional }
                        );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "SetPage", id = UrlParameter.Optional },
                namespaces: new string[] { "CharityProject.Controllers" }
            );

        }
    }
}
