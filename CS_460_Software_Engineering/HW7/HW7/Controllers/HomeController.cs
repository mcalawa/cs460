using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW7.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>
        /// The index page. This just returns a view;
        /// all the heavy duty stuff is done in the ResultController.
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }
    }
}