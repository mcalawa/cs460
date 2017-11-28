using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HW6
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "BikesRoute",
                url: "bikes",
                defaults: new { controller = "Home", action = "Bikes" }
            );

            routes.MapRoute(
                name: "ComponentsRoute",
                url: "components",
                defaults: new { controller = "Home", action = "Components" }
            );

            routes.MapRoute(
                name: "ClothingRoute",
                url: "clothing",
                defaults: new { controller = "Home", action = "Clothing" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{action}/{id}/{product}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, product = UrlParameter.Optional }
            );
        }
    }
}
