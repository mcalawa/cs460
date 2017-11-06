using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW5.Models;

namespace HW5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeAddressForm()
        {
            return View(new AddressChangeForm());
        }

        [HttpPost]
        public ActionResult ChangeAddressForm(AddressChangeForm form)
        {
            return View();
        }

        public ActionResult AddressChanges()
        {
            return View();
        }
    }
}