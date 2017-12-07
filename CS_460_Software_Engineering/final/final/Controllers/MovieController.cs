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
            return View(db.Movies);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "DirectorId,Name,Year")] Movies movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        public ActionResult Details(int id)
        {
            var movieDetails = db.Movies.Where(i => i.MovieId == id);

            return View(movieDetails);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var toEdit = db.Movies.Where(i => i.MovieId == id);

            return View(toEdit);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            var toEdit = db.Movies.Where(i => i.MovieId == id);

            toEdit.FirstOrDefault().Title = form["Title"];
            toEdit.FirstOrDefault().Year = Int32.Parse(form["Year"]);
            toEdit.FirstOrDefault().DirectorId = Int32.Parse(form["DirectorId"]);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var toDelete = db.Movies.Where(i => i.MovieId == id);

            return View(toDelete);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Movies.Remove(db.Movies.Find(id));
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}