using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using final.DAL;
using final.Models;

namespace final.Controllers
{
    public class MovieController : Controller
    {
        private volatile Type _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        private FilmContext db = new FilmContext();

        // GET: Movie
        public ActionResult Index()
        {
            return View(db.Movies);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}