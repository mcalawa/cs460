using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HW8
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ArtistDetails",
                url: "Artist/Details/{id}",
                defaults: new {controller = "Artist", action = "Details", id = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "ArtistEdit",
                url: "Artist/Edit/{id}",
                defaults: new { controller = "Artist", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ArtistDelete",
                url: "Artist/Delete/{id}",
                defaults: new { controller = "Artist", action = "Delete", id = UrlParameter.Optional }
            );
        }
    }
}
