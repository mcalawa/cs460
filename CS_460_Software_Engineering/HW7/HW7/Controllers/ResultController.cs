using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using HW7.Models;
using HW7.DAL;

namespace HW7.Controllers
{
    public class ResultController : Controller
    {
        //the database for recording requests
        private SearchLogContext db = new SearchLogContext();

        // GET: Result
        /// <summary>
        /// Returns a view of the HomeController's index, 
        /// since this doesn't actually have any views created.
        /// </summary>
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        /// <summary>
        /// The JsonResult that gets everything from the Giphy API.
        /// </summary>
        public JsonResult Search()
        {
            /* The API key isn't actually found anywhere in this project. 
             * It is kept in a config file located outside of the repository
             * and linked to by the Web.config file. */
            string key = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];
            /* limit is the number of results to return, which was what I decided to have be the 
             * additional thing that was part of the search instead of just a query to search for.
             * This is especially useful if you are like me and will end up trying to view all of the
             * results returned even though there are a million of them and you have a limited amount of 
             * time. */
            string limit = Request.QueryString["limit"];
            //The search terms we are searching for
            string query = Request.QueryString["q"];

            //The information logging all the searches
            DateTime timestamp = DateTime.Now;
            string userBrowserAgent = Request.UserAgent;
            string ipAddress = Request.UserHostAddress;

            //Creating the search log, so it can be added to the db
            var log = db.SearchLogs.Create();

            log.SearchQuery = query;
            log.NumberRequested = Int32.Parse(limit);
            log.TimeStamp = timestamp;
            log.RequesterIP = ipAddress;
            log.BrowserAgent = userBrowserAgent;

            db.SearchLogs.Add(log);
            db.SaveChanges();

            //The url of the request we are making to the Giphy API
            string url = "https://api.giphy.com/v1/gifs/search?api_key=" + key + "&q=" + query + "&limit=" + limit + "&rating=g&lang=en&fmt=json";

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            string reader = new StreamReader(responseStream).ReadToEnd();

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var results = serializer.DeserializeObject(reader);

            responseStream.Close();
            response.Close();

            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}