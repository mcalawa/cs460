using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW8.DAL;
using HW8.Models;
using System.Net;
using System.Data;
using System.Text;

namespace HW8.Controllers
{
    public class ArtistController : Controller
    {
        private volatile Type _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        private ArtContext db = new ArtContext();

        // GET: Artist
        public ActionResult Index()
        {
            return View(db.Artists.ToList());
        }

        public ActionResult Create()
        {
            return View(db.Artists.ToList());
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,BirthCity,DoB")] Artists artist)
        {
            if(ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        public ActionResult Details(int id)
        {
            var toDisplay = db.Artists.Where(i => i.ArtistId == id).ToList();

            return View(toDisplay);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var toUpdate = db.Artists.Where(i => i.ArtistId == id).ToList();

            return View(toUpdate);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            var toUpdate = db.Artists.Where(i => i.ArtistId == id);

            toUpdate.FirstOrDefault().Name = form["Name"];
            toUpdate.FirstOrDefault().BirthCity = form["BirthCity"];
            toUpdate.FirstOrDefault().DoB = DateTime.Parse(form["DoB"]);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var toDelete = db.Artists.Where(i => i.ArtistId == id).ToList();

            return View(toDelete);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Artists.Remove(db.Artists.Find(id));
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}