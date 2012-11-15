using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            config.Routes.MapHttpRoute(
              name: "Api UriPathExtension",
              routeTemplate: "api/{controller}.{extension}/{id}",
              defaults: new { id = RouteParameter.Optional, extension = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "Api UriPathExtension 1",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional, extension = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "API Default",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
