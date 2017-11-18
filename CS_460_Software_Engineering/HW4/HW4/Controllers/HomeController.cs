using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html5;
using HW4.Models;

namespace HW4.Controllers
{
    public class HomeController : Controller
    {
        //index page
        public ActionResult Index()
        {
            return View();
        }

        /*for both page 1 and page 2, I decided to do something that calculates how many days you have
         until your next birthday*/
        [HttpGet]
        public ActionResult Page1()
        {
            return View();
        }

        //for calculating the data we got from page 1
        public ActionResult Page1Result()
        {
            int nextAge = 0; //Your age as of your next birthday
            //Displays a different message if it's your birthday, so something to check if it's their birthday
            bool birthdayToday = false; 
            //What the age of their next birthday will end with ("th", "rd", "nd", "st")
            string ageEnding = "";
            string nextAgeString = ""; //string version of nextAge so we can check to see what ending we need
            int finalDigit = 0; //somewhere to store the final digit of the age, again so we can get the ageEnding
            int daysUntil = 0; //the number of days until their next birthday
            //their name so we can address them personally
            string firstname = Request.QueryString["firstname"].ToString();

            DateTime today = DateTime.Today; //today's date so we can compare it and see if it's their birthday

            int year = Int32.Parse(Request.QueryString["year"].ToString()); //the year they were born
            int month = Int32.Parse(Request.QueryString["month"].ToString()); //the month they were born
            int day = Int32.Parse(Request.QueryString["day"].ToString()); //the day they were born

            /* for calculating their age if they were born on 02/29; technically I'm counting not their age,
             * but how many birthdays they will have had, so this is different if they were born on 02/29*/
            if(month == 2 && day == 29)
            {
                int pastYears = today.Year - 1; //used as a condition for the while loop
                //The - 1 is because this year is accounted for later.

                //this calculates their age at their next birthday, since it is calculated differently
                while (pastYears > year) //while pastYears isn't the year you were born in
                {
                    if (DateTime.IsLeapYear(pastYears)) //if they had a birthday that year
                    {
                        nextAge += 1; //add a year to their age
                    }

                    pastYears -= 1; //counts down until it reaches their birth year
                }
            }

            /* This is required because I used a DateTime with this year's birthday to figure out
             * if it's their birthday, as well as what their next age will be (since that changes
             * depending on whether or not they've already had a birthday this year), but trying 
             * to create a DateTime for a date that doesn't exist in this year causes problems, so
             * a different method needs to be used if their birthday is Feb 29th and it isn't a leap year*/
            if (month == 2 && day == 29 && !DateTime.IsLeapYear(today.Year)) 
            {
                birthdayToday = false; //if their birthday doesn't exist this year, it can't be their birthday
            }
            else //if their birthday is not 02/29 OR the current year is a leap year
            {
                //create a new DateTime for this year's birthday, since we know it exists
                DateTime birthdayThisYear = new DateTime(today.Year, month, day);

                //if their birthday hasn't happened yet or is today
                if (birthdayThisYear.CompareTo(today) >= 0) 
                {
                    //if their birthday is, their age has already been calculated
                    if(month != 2 && day != 29)
                    { 
                        nextAge = today.Year - year;
                    }

                    if (birthdayThisYear.CompareTo(today) == 0)
                    {
                        if(month == 2 && day == 29)
                        {
                            nextAge += 1; //account for the fact that they are another year older
                        }
                        birthdayToday = true;
                    }
                    else
                    {
                        birthdayToday = false;
                    }
                }
                else //if their birthday has happened already this year
                {
                    //if their birthday's already happened, their next age needs to go up by 1
                    if(month == 2 && day == 29)
                    {
                        nextAge += 1;
                    }
                    else
                    {
                        nextAge = (today.Year - year) + 1;
                    }
                    birthdayToday = false;
                }
            }

            //if it isn't their birthday, we need to calculate how many more days there are until
            //their birthday
            if (birthdayToday == false)
            {
                //this is for keeping track of each month to check if it's their birthday month
                int monthIndex = today.Month; 
                //for keeping track of the year since their birthday may not be until next year
                //and February varies in length depending on the year
                int yearIndex = today.Year;

                //if their birthday is 02/29, they may have to go several years before it's their birthday
                if (month == 2 && day == 29)
                {
                    //We calculate the days while it's not their birth month or their birthday doesn't
                    //exist in their birth month that year
                    while (monthIndex != month || !DateTime.IsLeapYear(yearIndex))
                    {
                        //this is for the first time this is run because you have to subtract the days
                        //that have already passed from the days left in this month
                        if (yearIndex == today.Year && monthIndex == today.Month)
                        {
                            //add the days until the end of the month
                            daysUntil += DateTime.DaysInMonth(yearIndex, monthIndex) - today.Day;
                        }
                        else
                        {
                            //add the days in that month
                            daysUntil += DateTime.DaysInMonth(yearIndex, monthIndex);
                        }

                        //if it's December, the month resets to one and the year has to increase
                        if (monthIndex == 12)
                        {
                            monthIndex = 1;
                            yearIndex += 1;
                        }
                        else //otherwise we just increase the month
                        {
                            monthIndex += 1;
                        }
                    } //while it a month their birthday can happen in
                } //if their birthday is 02/29
                else //if it isn't
                {
                    //while it isn't their birth month
                    while (monthIndex != month)
                    {
                        //this is for the first time this is run because you have to subtract the days
                        //that have already passed from the days left in this month
                        if (yearIndex == today.Year && monthIndex == today.Month)
                        {
                            //add days until the end of that month
                            daysUntil += DateTime.DaysInMonth(yearIndex, monthIndex) - today.Day;
                        }
                        else
                        {
                            //add days in that month
                            daysUntil += DateTime.DaysInMonth(yearIndex, monthIndex);
                        }

                        //if it's December, the month resets to one and the year has to increase
                        if (monthIndex == 12)
                        {
                            monthIndex = 1;
                            yearIndex += 1;
                        }
                        else //otherwise we just increase the month
                        {
                            monthIndex += 1;
                        }
                    } //while it isn't their birth month
                }

                //this is to add the number of days in their birth month until their birthday
                if (daysUntil > 0)
                {
                    //if they weren't already in their birth month, they can just add the date of 
                    //their birthday to get the remaining number of days
                    daysUntil += day;
                }
                else
                {
                    //if they already were in their birth month, they need to take into account the 
                    //days that have already passed
                    daysUntil = day - today.Day;
                }
            } //if their birthday isn't today, calculate how many days there are until their birthday

            ageEnding = nextAge.ToString(); //time to figure out what the age ending will be

            //if their age ends in 11, 12, or one of the teens, it doesn't follow the usual rules,
            //so just set it to a number whose rules it does follow
            if (ageEnding.Length > 1 && ageEnding.Substring((ageEnding.Length - 2), 1) == "1")
            {
                ageEnding = "0";
            }
            else //if it's not in the teens, just get the last number in their age
            {
                ageEnding = ageEnding.Substring(ageEnding.Length - 1);
            }

            finalDigit = Int32.Parse(ageEnding); //turn it to an int so we can easily check it and 
            //figure out what the ending should be

            if (finalDigit == 1)
            {
                ageEnding = "st";
            }
            else if (finalDigit == 2)
            {
                ageEnding = "nd";
            }
            else if (finalDigit == 3)
            {
                ageEnding = "rd";
            }
            else
            {
                ageEnding = "th";
            }

            nextAgeString = nextAge.ToString() + ageEnding; //create a string for the age and age ending

            if (birthdayToday) //if their birthday's today
            {
                if (year == today.Year) //if they are somehow a prodigy that uses this calculator the same day they were born
                {
                    ViewBag.Message = "You were born today. You're just getting started, " + firstname + "!";
                }
                else //otherwise, wish them a happy birthday for whatever birthday this was
                {
                    ViewBag.Message = "It's your " + nextAgeString + " birthday today, " + firstname + ". Well, happy birthday!";
                }
            }
            else //if it's not their birthday...
            {
                //Tell them how many days there are until their next birthday
                ViewBag.Message = "There are " + daysUntil + " days until your " + nextAgeString + " birthday, " + firstname + ".";
            }

            return View();
        } //Page1Results

        /*for both page 1 and page 2, I decided to do something that calculates how many days you have
         until your next birthday*/
        [HttpGet]
        public ActionResult Page2()
        {
            ViewBag.RequestMethod = "GET"; //used to tell whether we should display the form or the results
            return View();
        } //HttpGet Page2

        //receives the data we got from the form and manipulates it
        [HttpPost]
        public ActionResult Page2(FormCollection form)
        {
            ViewBag.RequestMethod = "POST"; //used to tell whether we should display the form or the results
            int nextAge = 0; //Your age as of your next birthday
            //Displays a different message if it's your birthday, so something to check if it's their birthday
            bool birthdayToday = false;
            //What the age of their next birthday will end with ("th", "rd", "nd", "st")
            string ageEnding = "";
            string nextAgeString = ""; //string version of nextAge so we can check to see what ending we need
            int finalDigit = 0; //somewhere to store the final digit of the age, again so we can get the ageEnding
            int daysUntil = 0; //the number of days until their next birthday
            //their name so we can address them personally

            DateTime today = DateTime.Today; //today's date so we can compare it and see if it's their birthday

            int year = Int32.Parse(form["year"]); //their birth year; assignment method differs from Page1Result
            int month = Int32.Parse(form["month"]); //their birth month; assignment method differs from Page1Result
            int day = Int32.Parse(form["day"]); //their birth day assignment method differs from Page1Result

            //The rest of this code is the same as the code used in Page1Result except that I don't make
            //a specific string for firstName and just grab it from the form collection

            /* for calculating their age if they were born on 02/29; technically I'm counting not their age,
             * but how many birthdays they will have had, so this is different if they were born on 02/29*/
            if (month == 2 && day == 29)
            {
                int pastYears = today.Year - 1; //used as a condition for the while loop
                //The - 1 is because this year is accounted for later.

                //this calculates their age at their next birthday, since it is calculated differently
                while (pastYears > year) //while pastYears isn't the year you were born in
                {
                    if (DateTime.IsLeapYear(pastYears)) //if they had a birthday that year
                    {
                        nextAge += 1; //add a year to their age
                    }

                    pastYears -= 1; //counts down until it reaches their birth year
                }
            }

            /* This is required because I used a DateTime with this year's birthday to figure out
             * if it's their birthday, as well as what their next age will be (since that changes
             * depending on whether or not they've already had a birthday this year), but trying 
             * to create a DateTime for a date that doesn't exist in this year causes problems, so
             * a different method needs to be used if their birthday is Feb 29th and it isn't a leap year*/
            if (month == 2 && day == 29 && !DateTime.IsLeapYear(today.Year))
            {
                birthdayToday = false; //if their birthday doesn't exist this year, it can't be their birthday
            }
            else //if their birthday is not 02/29 OR the current year is a leap year
            {
                //create a new DateTime for this year's birthday, since we know it exists
                DateTime birthdayThisYear = new DateTime(today.Year, month, day);

                //if their birthday hasn't happened yet or is today
                if (birthdayThisYear.CompareTo(today) >= 0)
                {
                    //if their birthday is, their age has already been calculated
                    if (month != 2 && day != 29)
                    {
                        nextAge = today.Year - year;
                    }

                    if (birthdayThisYear.CompareTo(today) == 0)
                    {
                        if (month == 2 && day == 29)
                        {
                            nextAge += 1; //account for the fact that they are another year older
                        }
                        birthdayToday = true;
                    }
                    else
                    {
                        birthdayToday = false;
                    }
                }
                else //if their birthday has happened already this year
                {
                    //if their birthday's already happened, their next age needs to go up by 1
                    if (month == 2 && day == 29)
                    {
                        nextAge += 1;
                    }
                    else
                    {
                        nextAge = (today.Year - year) + 1;
                    }
                    birthdayToday = false;
                }
            }

            //if it isn't their birthday, we need to calculate how many more days there are until
            //their birthday
            if (birthdayToday == false)
            {
                //this is for keeping track of each month to check if it's their birthday month
                int monthIndex = today.Month;
                //for keeping track of the year since their birthday may not be until next year
                //and February varies in length depending on the year
                int yearIndex = today.Year;

                //if their birthday is 02/29, they may have to go several years before it's their birthday
                if (month == 2 && day == 29)
                {
                    //We calculate the days while it's not their birth month or their birthday doesn't
                    //exist in their birth month that year
                    while (monthIndex != month || !DateTime.IsLeapYear(yearIndex))
                    {
                        //this is for the first time this is run because you have to subtract the days
                        //that have already passed from the days left in this month
                        if (yearIndex == today.Year && monthIndex == today.Month)
                        {
                            //add the days until the end of the month
                            daysUntil += DateTime.DaysInMonth(yearIndex, monthIndex) - today.Day;
                        }
                        else
                        {
                            //add the days in that month
                            daysUntil += DateTime.DaysInMonth(yearIndex, monthIndex);
                        }

                        //if it's December, the month resets to one and the year has to increase
                        if (monthIndex == 12)
                        {
                            monthIndex = 1;
                            yearIndex += 1;
                        }
                        else //otherwise we just increase the month
                        {
                            monthIndex += 1;
                        }
                    } //while it a month their birthday can happen in
                } //if their birthday is 02/29
                else //if it isn't
                {
                    //while it isn't their birth month
                    while (monthIndex != month)
                    {
                        //this is for the first time this is run because you have to subtract the days
                        //that have already passed from the days left in this month
                        if (yearIndex == today.Year && monthIndex == today.Month)
                        {
                            //add days until the end of that month
                            daysUntil += DateTime.DaysInMonth(yearIndex, monthIndex) - today.Day;
                        }
                        else
                        {
                            //add days in that month
                            daysUntil += DateTime.DaysInMonth(yearIndex, monthIndex);
                        }

                        //if it's December, the month resets to one and the year has to increase
                        if (monthIndex == 12)
                        {
                            monthIndex = 1;
                            yearIndex += 1;
                        }
                        else //otherwise we just increase the month
                        {
                            monthIndex += 1;
                        }
                    } //while it isn't their birth month
                }

                //this is to add the number of days in their birth month until their birthday
                if (daysUntil > 0)
                {
                    //if they weren't already in their birth month, they can just add the date of 
                    //their birthday to get the remaining number of days
                    daysUntil += day;
                }
                else
                {
                    //if they already were in their birth month, they need to take into account the 
                    //days that have already passed
                    daysUntil = day - today.Day;
                }
            } //if their birthday isn't today, calculate how many days there are until their birthday

            ageEnding = nextAge.ToString(); //time to figure out what the age ending will be

            //if their age ends in 11, 12, or one of the teens, it doesn't follow the usual rules,
            //so just set it to a number whose rules it does follow
            if (ageEnding.Length > 1 && ageEnding.Substring((ageEnding.Length - 2), 1) == "1")
            {
                ageEnding = "0";
            }
            else //if it's not in the teens, just get the last number in their age
            {
                ageEnding = ageEnding.Substring(ageEnding.Length - 1);
            }

            finalDigit = Int32.Parse(ageEnding); //turn it to an int so we can easily check it and 
            //figure out what the ending should be

            if (finalDigit == 1)
            {
                ageEnding = "st";
            }
            else if (finalDigit == 2)
            {
                ageEnding = "nd";
            }
            else if (finalDigit == 3)
            {
                ageEnding = "rd";
            }
            else
            {
                ageEnding = "th";
            }

            nextAgeString = nextAge.ToString() + ageEnding; //create a string for the age and age ending

            if (birthdayToday) //if their birthday's today
            {
                if (year == today.Year) //if they are somehow a prodigy that uses this calculator the same day they were born
                {
                    ViewBag.Message = "You were born today. You're just getting started, " + form["firstname"] + "!";
                }
                else //otherwise, wish them a happy birthday for whatever birthday this was
                {
                    ViewBag.Message = "It's your " + nextAgeString + " birthday today, " + form["firstname"] + ". Well, happy birthday!";
                }
            }
            else //if it's not their birthday...
            {
                //Tell them how many days there are until their next birthday
                ViewBag.Message = "There are " + daysUntil + " days until your " + nextAgeString + " birthday, " + form["firstname"] + ".";
            }

            return View();
        }
        //HttpPost Page2

        //Created an investment calculator because debt is depressing; uses model binding to collect data
        public ActionResult Page3()
        {
            return View(new InvestmentCalculator());
        }

        //receives the data we got through the form using model binding and manipulates it
        [HttpPost]
        public ActionResult Page3(InvestmentCalculator c)
        {
            double total = Math.Round(c.Principle, 2); //dollar amount of your total
            double n = c.Term * c.Time; //n, or the number of periods
            double interest = c.Interest / 100; //changes percentage to form used for calculations
            double totalEarned = 0; //dollar amount of interest earned
            string interestType = ""; //compound or simple
            string termString = ""; //string for how often it was calculated or compounded
            string yearString = ""; //whether it's a year or multiple years

            if(c.Time == 1)
            {
                yearString = " year";
            }
            else
            {
                yearString = " years";
            }

            if(c.Term == 365)
            {
                termString = "daily";
            }
            else if(c.Term == 52)
            {
                termString = "weekly";
            }
            else if(c.Term == 12)
            {
                termString = "monthly";
            }
            else
            {
                termString = "annually";
            }

            if(c.Compound)
            {
                totalEarned = Math.Round((c.Principle * Math.Pow((1 + interest), n) - c.Principle), 2);
                interestType = " compounded ";
            }
            else
            {
                totalEarned = Math.Round((c.Principle * interest * n), 2);
                interestType = " calculated ";
            }

            total += totalEarned;

            ViewBag.Message = "An investment of $" + Math.Round(c.Principle, 2) + " with a " + c.Interest + "% interest rate " + interestType + termString + " over " + c.Time + yearString + " would earn $" + String.Format("{0:n}", totalEarned) + " for a total ending balance of $" + String.Format("{0:n}", total) + ".";

            return View("Page3Result", "~/Views/Shared/_Layout.cshtml", ViewBag.Message);
        } //manipulation of data from Page3

        public ActionResult Page3Result(string m)
        {
            ViewBag.Message = m;

            return View();
        }
    }
}