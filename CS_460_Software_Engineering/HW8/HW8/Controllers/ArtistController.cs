using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW8.DAL;
using HW8.Models;
using System.Net;
using System.Data;

namespace HW8.Controllers
{
    public class ArtistController : Controller
    {
        private volatile Type _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        private ArtContext db = new ArtContext();

        // GET: Artist
        public ActionResult Index()
        {
            return View(db.Artists);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            var toUpdate = db.Artists.Where(i => i.ArtistId == id);

            if (TryUpdateModel(toUpdate, "",
                new string[] { "Name", "BirthCity", "DoB" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(toUpdate);
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}