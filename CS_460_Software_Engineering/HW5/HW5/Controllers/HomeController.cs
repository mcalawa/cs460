﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }

        public ActionResult AddressChanges()
        {
            return View();
        }
    }
}