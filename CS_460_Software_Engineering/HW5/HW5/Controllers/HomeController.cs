using System;
using System.Data.Entity.Core;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW5.Models;
using HW5.DAL;

namespace HW5.Controllers
{
    public class HomeController : Controller
    {
        private volatile Type _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        private DriverContext database = new DriverContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeAddressForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeAddressForm([Bind(Include = "DriverID,DateOfBirth,FullName,Address,City,State,ZipCode,County,DateOfChange")]
        Driver driver)
        {
            if (ModelState.IsValid)
            {
                database.Drivers.Add(driver);
                database.SaveChanges();
                return RedirectToAction("AddressChanges");
            }
            return View(driver);
        }

        public ActionResult AddressChanges()
        {
            return View(database.Drivers.ToList());
        }
    }
}