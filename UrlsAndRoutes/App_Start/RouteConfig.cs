using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // default: 
            // http://localhost:9006/home/index
            // http://localhost:9006/home
            // http://localhost:9006
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            // sciezka statyczna: 
            // http://localhost:9006/test/home/index
            routes.MapRoute(
                name: "Default1",
                url: "Test/{controller}/{action}");
        }
    }
}