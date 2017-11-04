using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Homework4.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Page1()
        {
            return View();
        }


        public ActionResult Page1Result()
        {
            int nextAge = 0;
            bool birthdayToday = false;
            string firstname = Request.Query["firstname"].ToString();
            ViewBag.Name = firstname;

            DateTime today = DateTime.Today;

            int year = Int32.Parse(Request.Query["year"].ToString());
            int month = Int32.Parse(Request.Query["month"].ToString());
            int day = Int32.Parse(Request.Query["day"].ToString());

            DateTime birthdayThisYear = new DateTime(today.Year, month, day);

            if(birthdayThisYear.CompareTo(today) >= 0)
            {
                nextAge = today.Year - year;

                if(birthdayThisYear.CompareTo(today) == 0)
                {
                    birthdayToday = true;
                }
                else
                {
                    birthdayToday = false;
                }
            }
            else
            {
                nextAge = (today.Year - year) + 1;
                birthdayToday = false;
            }



            return View();
        }
    }
}