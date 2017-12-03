using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW8.DAL;
using HW8.Models;

namespace HW8.Controllers
{
    public class HomeController : Controller
    {
        private volatile Type _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        private ArtContext db = new ArtContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Artists()
        {
            return View(db.Artists);
        }

        public ActionResult ArtWorks()
        {
            return View(db.ArtWorks);
        }

        public ActionResult Classifications()
        {
            return View(db.Classifications);
        }
    }
}