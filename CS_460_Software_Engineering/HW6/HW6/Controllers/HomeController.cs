using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HW6.Models;
using HW6.DAL;
using System.Text;

namespace HW6.Controllers
{
    public class HomeController : Controller
    {
        private volatile Type _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.ProductCategories.ToList());
        }

        public PartialViewResult Menu()
        {
            return PartialView("Menu", db.ProductCategories);
        }

        public ActionResult Bikes(string id = null, string product = null)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Bikes";
            ViewBag.Bikes = id;
            ViewBag.Id = product;
            StringBuilder htmlString = new StringBuilder("");
            var subCategories = db.ProductSubcategories.Where(p => p.ProductCategory.Name == "Bikes")
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    Name = p.Name,
                    Count = p.Products.Count()
                });
            
            //if this is the category view
            if(id == null && product == null)
            {
                ViewBag.Sub = "";
                ViewBag.Product = "";
                ViewBag.Title = "| " + ViewBag.Action;
                ViewBag.Header = ViewBag.Action;
                ViewBag.Type = "Category";

                foreach(var item in subCategories)
                {
                    string subCat = item.Name.Replace(" ", "-").ToLower();
                    htmlString.Append("<li><a href='bikes/" + subCat + "'>" + item.Name + "</a> (" + item.Count + ")</li>");
                }
                ViewBag.SideBar = htmlString.ToString();

                return View(db.ProductCategories.ToList());
            }
            else if(id != null && product == null) //if this is the subcat view
            {
                string subCat = id.Replace("-", " ");
                ViewBag.Sub = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(subCat);
                ViewBag.Product = "";
                ViewBag.Title = "| " + ViewBag.Sub;
                ViewBag.Header = ViewBag.Sub;
                ViewBag.Type = "SubCategory";

                return View(db.ProductCategories.ToList());
            }
            else //if this is the product view
            {
                string subCat = id.Replace("-", " ");
                ViewBag.Sub = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(subCat);
                string prodName = product.Replace("-", " ");
                ViewBag.Product = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(prodName);
                ViewBag.Title = "| " + ViewBag.Product;
                ViewBag.Header = ViewBag.Product;
                ViewBag.Type = "Product";

                return View(db.ProductCategories.ToList());
            }
        } //Bikes

        public ActionResult Components(string id = null, string product = null)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Components";
            ViewBag.Components = id;
            ViewBag.Id = product;
            ViewBag.Title = "| " + ViewBag.Action;
            ViewBag.Header = ViewBag.Action;

            if (id != null)
            {
                string subCat = id.Replace("-", " ");
                ViewBag.Sub = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(subCat);
                ViewBag.Title = "| " + ViewBag.Sub;
                ViewBag.Header = ViewBag.Sub;
            }
            else
            {
                ViewBag.Sub = "";
            }

            if (product != null)
            {
                string prodName = product.Replace("-", " ");
                ViewBag.Product = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(prodName);
                ViewBag.Title = "| " + ViewBag.Product;
                ViewBag.Header = ViewBag.Product;
            }
            else
            {
                ViewBag.Product = "";
            }
            return View(db.ProductCategories.ToList());
        } //Components

        public ActionResult Clothing(string id = null, string product = null)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Clothing";
            ViewBag.Clothing = id;
            ViewBag.Id = product;
            ViewBag.Title = "| " + ViewBag.Action;
            ViewBag.Header = ViewBag.Action;

            if (id != null)
            {
                string subCat = id.Replace("-", " ");
                subCat = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(subCat);
                if(subCat.Equals("Bib Shorts"))
                {
                    subCat = subCat.Replace(" ", "-");
                }
                ViewBag.Sub = subCat.ToString();
                ViewBag.Title = "| " + ViewBag.Sub;
                ViewBag.Header = ViewBag.Sub;
            }
            else
            {
                ViewBag.Sub = "";
            }

            if (product != null)
            {
                string prodName = product.Replace("-", " ");
                ViewBag.Product = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(prodName);
                ViewBag.Title = "| " + ViewBag.Product;
                ViewBag.Header = ViewBag.Product;
            }
            else
            {
                ViewBag.Product = "";
            }
            return View(db.ProductCategories.ToList());
        } //Clothing

        public ActionResult Accessories(string id = null, string product = null)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Accessories";
            ViewBag.Accessories = id;
            ViewBag.Id = product;
            ViewBag.Title = "| " + ViewBag.Action;
            ViewBag.Header = ViewBag.Action;

            if (id != null)
            {
                string subCat = id.Replace("-", " ");
                ViewBag.Sub = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(subCat);
                ViewBag.Title = "| " + ViewBag.Sub;
                ViewBag.Header = ViewBag.Sub;
            }
            else
            {
                ViewBag.Sub = "";
            }

            if (product != null)
            {
                string prodName = product.Replace("-", " ");
                ViewBag.Product = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(prodName);
                ViewBag.Title = "| " + ViewBag.Product;
                ViewBag.Header = ViewBag.Product;
            }
            else
            {
                ViewBag.Product = "";
            }
            return View(db.ProductCategories.ToList());
        } //Accessories
    }
}