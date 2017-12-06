using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using final.DAL;
using final.Models;

namespace final.Controllers
{
    public class HomeController : Controller
    {
        private volatile Type _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        private FilmContext db = new FilmContext();

        public ActionResult Index()
        {
            return View(db.Actors);
        }

        public ActionResult Actor()
        {
            return View(db.Actors);
        }

        public ActionResult Cast()
        {
            return View(db.Casts);
        }
    }
}