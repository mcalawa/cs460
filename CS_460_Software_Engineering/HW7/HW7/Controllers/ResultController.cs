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
        private SearchLogContext db = new SearchLogContext();

        // GET: Result
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public JsonResult Search()
        {
            string key = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];
            string limit = Request.QueryString["limit"];
            string query = Request.QueryString["q"];

            DateTime timestamp = DateTime.Now;
            string userBrowserAgent = Request.UserAgent;
            string ipAddress = Request.UserHostAddress;

            var log = db.SearchLogs.Create();

            log.SearchQuery = query;
            log.NumberRequested = Int32.Parse(limit);
            log.TimeStamp = timestamp;
            log.RequesterIP = ipAddress;
            log.BrowserAgent = userBrowserAgent;

            db.SearchLogs.Add(log);
            db.SaveChanges();

            string url = "https://api.giphy.com/v1/gifs/search?api_key=" + key + "&q=" + query + "&limit=" + limit + "&rating=g&lang=en&fmt=json";

            Console.WriteLine(url);

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