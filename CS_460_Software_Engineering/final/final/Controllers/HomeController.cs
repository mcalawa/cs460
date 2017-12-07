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

        public JsonResult ByActor(int id)
        {
            var actor = db.Actors.Where(i => i.ActorId == id)
                            .Select(m => m.Casts)
                            .FirstOrDefault()
                            .Select(m => new
                            {
                                Actor = m.Actors.Name,
                                Movie = m.Movies.Title,
                                Director = m.Movies.Directors.Name
                            });

            return Json(actor, JsonRequestBehavior.AllowGet);
        }
    }
}