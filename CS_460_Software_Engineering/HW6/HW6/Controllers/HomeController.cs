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
            return View();
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
            
            //if this is the category view
            if(id == null && product == null)
            {
                ViewBag.Sub = "";
                ViewBag.Product = "";
                ViewBag.Title = "| " + ViewBag.Action;
                ViewBag.Header = ViewBag.Action;
                ViewBag.Type = "Category";

                var products = db.Products.Where(p => p.ProductSubcategory.ProductCategory.Name == "Bikes"
                    && p.FinishedGoodsFlag == true
                    && p.SellEndDate == null
                    && p.DiscontinuedDate == null).GroupBy(p => new { p.ProductModelID, p.ListPrice })
                    .OrderBy(g => g.Key.ProductModelID).Select(g => g.FirstOrDefault());
                
                ViewBag.Matches = "(" + products.Count() + " matches)";
                if (products.Count() > 0)
                {
                    if(products.Count() == 1)
                    {
                        ViewBag.Matches = "(" + products.Count() + " match)";
                    }

                    return View(products);
                }
                else
                {
                    return View();
                }
            }
            else if(id != null && product == null) //if this is the subcat view
            {

                ViewBag.Product = "";
                ViewBag.Type = "SubCategory";
                var products = db.Products.Where(p => p.ProductSubcategory.Name.Replace(" ", "-").ToLower() == id
                    && p.FinishedGoodsFlag == true
                    && p.SellEndDate == null
                    && p.DiscontinuedDate == null).GroupBy(p => new { p.ProductModelID, p.ListPrice })
                    .OrderBy(g => g.Key.ProductModelID).Select(g => g.FirstOrDefault());

                ViewBag.Matches = "(" + products.Count() + " matches)";
                if (products.Count() > 0)
                {
                    if (products.Count() == 1)
                    {
                        ViewBag.Matches = "(" + products.Count() + " match)";
                    }
                    ViewBag.Sub = products.FirstOrDefault().ProductSubcategory.Name;
                    ViewBag.Title = "| " + ViewBag.Sub;
                    ViewBag.Header = ViewBag.Sub;

                    return View(products);
                }
                else
                {
                    string subCat = id.Replace("-", " ");
                    ViewBag.Sub = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(subCat);
                    ViewBag.Title = "| " + ViewBag.Sub;
                    ViewBag.Header = ViewBag.Sub;
                    return View();
                }
            }
            else //if this is the product view
            {
                ViewBag.Type = "Product";
                var products = db.Products.Where(p => p.ProductModel.Name.Replace(" ", "-").ToLower() == product
                    && p.FinishedGoodsFlag == true
                    && p.SellEndDate == null
                    && p.DiscontinuedDate == null);

                if(products.Count() > 0)
                {
                    ViewBag.Sub = products.FirstOrDefault().ProductSubcategory.Name;
                    ViewBag.Product = products.FirstOrDefault().ProductModel.Name;
                    ViewBag.Title = "| " + ViewBag.Product;
                    ViewBag.Header = ViewBag.Product;
                    ViewBag.ProductItem = products.FirstOrDefault();

                    return View(products);
                }
                else
                {
                    ViewBag.Product = "Product Not Found";
                    ViewBag.Title = "| " + ViewBag.Product;
                    ViewBag.Header = ViewBag.Product;

                    return View();
                }
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

            //if this is the category view
            if (id == null && product == null)
            {
                ViewBag.Sub = "";
                ViewBag.Product = "";
                ViewBag.Title = "| " + ViewBag.Action;
                ViewBag.Header = ViewBag.Action;
                ViewBag.Type = "Category";

                var products = db.Products.Where(p => p.ProductSubcategory.ProductCategory.Name == "Components"
                    && p.FinishedGoodsFlag == true
                    && p.SellEndDate == null
                    && p.DiscontinuedDate == null).GroupBy(p => new { p.ProductModelID, p.ListPrice })
                    .OrderBy(g => g.Key.ProductModelID).Select(g => g.FirstOrDefault());

                ViewBag.Matches = "(" + products.Count() + " matches)";
                if (products.Count() > 0)
                {
                    if (products.Count() == 1)
                    {
                        ViewBag.Matches = "(" + products.Count() + " match)";
                    }

                    return View(products);
                }
                else
                {
                    return View();
                }
            }
            else if (id != null && product == null) //if this is the subcat view
            {
                ViewBag.Product = "";
                ViewBag.Type = "SubCategory";
                var products = db.Products.Where(p => p.ProductSubcategory.Name.Replace(" ", "-").ToLower() == id
                    && p.FinishedGoodsFlag == true
                    && p.SellEndDate == null
                    && p.DiscontinuedDate == null).GroupBy(p => new { p.ProductModelID, p.ListPrice })
                    .OrderBy(g => g.Key.ProductModelID).Select(g => g.FirstOrDefault());

                ViewBag.Matches = "(" + products.Count() + " matches)";
                if (products.Count() > 0)
                {
                    if (products.Count() == 1)
                    {
                        ViewBag.Matches = "(" + products.Count() + " match)";
                    }
                    ViewBag.Sub = products.FirstOrDefault().ProductSubcategory.Name;
                    ViewBag.Title = "| " + ViewBag.Sub;
                    ViewBag.Header = ViewBag.Sub;

                    return View(products);
                }
                else
                {
                    string subCat = id.Replace("-", " ");
                    ViewBag.Sub = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(subCat);
                    ViewBag.Title = "| " + ViewBag.Sub;
                    ViewBag.Header = ViewBag.Sub;
                    return View();
                }
            }
            else //if this is the product view
            {
                ViewBag.Type = "Product";
                var products = db.Products.Where(p => p.ProductModel.Name.Replace(" ", "-").ToLower() == product
                    && p.FinishedGoodsFlag == true
                    && p.SellEndDate == null
                    && p.DiscontinuedDate == null);

                if (products.Count() > 0)
                {
                    ViewBag.Sub = products.FirstOrDefault().ProductSubcategory.Name;
                    ViewBag.Product = products.FirstOrDefault().ProductModel.Name;
                    ViewBag.Title = "| " + ViewBag.Product;
                    ViewBag.Header = ViewBag.Product;
                    ViewBag.ProductItem = products.FirstOrDefault();

                    return View(products);
                }
                else
                {
                    ViewBag.Product = "Product Not Found";
                    ViewBag.Title = "| " + ViewBag.Product;
                    ViewBag.Header = ViewBag.Product;

                    return View();
                }
            }
        } //Components

        public ActionResult Clothing(string id = null, string product = null)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Clothing";
            ViewBag.Clothing = id;
            ViewBag.Id = product;
            ViewBag.Title = "| " + ViewBag.Action;
            ViewBag.Header = ViewBag.Action;

            //if this is the category view
            if (id == null && product == null)
            {
                ViewBag.Sub = "";
                ViewBag.Product = "";
                ViewBag.Title = "| " + ViewBag.Action;
                ViewBag.Header = ViewBag.Action;
                ViewBag.Type = "Category";

                var products = db.Products.Where(p => p.ProductSubcategory.ProductCategory.Name == "Clothing"
                    && p.FinishedGoodsFlag == true
                    && p.SellEndDate == null
                    && p.DiscontinuedDate == null).GroupBy(p => new { p.ProductModelID, p.ListPrice })
                    .OrderBy(g => g.Key.ProductModelID).Select(g => g.FirstOrDefault());

                ViewBag.Matches = "(" + products.Count() + " matches)";
                if (products.Count() > 0)
                {
                    if (products.Count() == 1)
                    {
                        ViewBag.Matches = "(" + products.Count() + " match)";
                    }

                    return View(products);
                }
                else
                {
                    return View();
                }
            }
            else if (id != null && product == null) //if this is the subcat view
            {
                ViewBag.Product = "";
                ViewBag.Type = "SubCategory";
                var products = db.Products.Where(p => p.ProductSubcategory.Name.Replace(" ", "-").ToLower() == id
                    && p.FinishedGoodsFlag == true
                    && p.SellEndDate == null
                    && p.DiscontinuedDate == null).GroupBy(p => new { p.ProductModelID, p.ListPrice })
                    .OrderBy(g => g.Key.ProductModelID).Select(g => g.FirstOrDefault());

                ViewBag.Matches = "(" + products.Count() + " matches)";
                if (products.Count() > 0)
                {
                    if (products.Count() == 1)
                    {
                        ViewBag.Matches = "(" + products.Count() + " match)";
                    }
                    ViewBag.Sub = products.FirstOrDefault().ProductSubcategory.Name;
                    ViewBag.Title = "| " + ViewBag.Sub;
                    ViewBag.Header = ViewBag.Sub;

                    return View(products);
                }
                else
                {
                    string subCat = id.Replace("-", " ");
                    ViewBag.Sub = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(subCat);
                    ViewBag.Title = "| " + ViewBag.Sub;
                    ViewBag.Header = ViewBag.Sub;
                    return View();
                }
            }
            else //if this is the product view
            {
                ViewBag.Type = "Product";
                var products = db.Products.Where(p => p.ProductModel.Name.Replace(" ", "-").ToLower() == product
                    && p.FinishedGoodsFlag == true
                    && p.SellEndDate == null
                    && p.DiscontinuedDate == null);

                if (products.Count() > 0)
                {
                    ViewBag.Sub = products.FirstOrDefault().ProductSubcategory.Name;
                    ViewBag.Product = products.FirstOrDefault().ProductModel.Name;
                    ViewBag.Title = "| " + ViewBag.Product;
                    ViewBag.Header = ViewBag.Product;
                    ViewBag.ProductItem = products.FirstOrDefault();

                    return View(products);
                }
                else
                {
                    ViewBag.Product = "Product Not Found";
                    ViewBag.Title = "| " + ViewBag.Product;
                    ViewBag.Header = ViewBag.Product;

                    return View();
                }
            }
        } //Clothing

        public ActionResult Accessories(string id = null, string product = null)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "Accessories";
            ViewBag.Accessories = id;
            ViewBag.Id = product;
            ViewBag.Title = "| " + ViewBag.Action;
            ViewBag.Header = ViewBag.Action;

            //if this is the category view
            if (id == null && product == null)
            {
                ViewBag.Sub = "";
                ViewBag.Product = "";
                ViewBag.Title = "| " + ViewBag.Action;
                ViewBag.Header = ViewBag.Action;
                ViewBag.Type = "Category";

                var products = db.Products.Where(p => p.ProductSubcategory.ProductCategory.Name == "Accessories"
                    && p.FinishedGoodsFlag == true
                    && p.SellEndDate == null
                    && p.DiscontinuedDate == null).GroupBy(p => new { p.ProductModelID, p.ListPrice })
                    .OrderBy(g => g.Key.ProductModelID).Select(g => g.FirstOrDefault());

                ViewBag.Matches = "(" + products.Count() + " matches)";
                if (products.Count() > 0)
                {
                    if (products.Count() == 1)
                    {
                        ViewBag.Matches = "(" + products.Count() + " match)";
                    }

                    return View(products);
                }
                else
                {
                    return View();
                }
            }
            else if (id != null && product == null) //if this is the subcat view
            {
                ViewBag.Product = "";
                ViewBag.Type = "SubCategory";
                var products = db.Products.Where(p => p.ProductSubcategory.Name.Replace(" ", "-").ToLower() == id
                    && p.FinishedGoodsFlag == true
                    && p.SellEndDate == null
                    && p.DiscontinuedDate == null).GroupBy(p => new { p.ProductModelID, p.ListPrice })
                    .OrderBy(g => g.Key.ProductModelID).Select(g => g.FirstOrDefault());

                ViewBag.Matches = "(" + products.Count() + " matches)";
                if (products.Count() > 0)
                {
                    if (products.Count() == 1)
                    {
                        ViewBag.Matches = "(" + products.Count() + " match)";
                    }
                    ViewBag.Sub = products.FirstOrDefault().ProductSubcategory.Name;
                    ViewBag.Title = "| " + ViewBag.Sub;
                    ViewBag.Header = ViewBag.Sub;

                    return View(products);
                }
                else
                {
                    string subCat = id.Replace("-", " ");
                    ViewBag.Sub = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(subCat);
                    ViewBag.Title = "| " + ViewBag.Sub;
                    ViewBag.Header = ViewBag.Sub;
                    return View();
                }
            }
            else //if this is the product view
            {
                ViewBag.Type = "Product";
                var products = db.Products.Where(p => p.ProductModel.Name.Replace(" ", "-").ToLower() == product
                    && p.FinishedGoodsFlag == true
                    && p.SellEndDate == null
                    && p.DiscontinuedDate == null);

                if (products.Count() > 0)
                {
                    ViewBag.Sub = products.FirstOrDefault().ProductSubcategory.Name;
                    ViewBag.Product = products.FirstOrDefault().ProductModel.Name;
                    ViewBag.Title = "| " + ViewBag.Product;
                    ViewBag.Header = ViewBag.Product;
                    ViewBag.ProductItem = products.FirstOrDefault();

                    return View(products);
                }
                else
                {
                    ViewBag.Product = "Product Not Found";
                    ViewBag.Title = "| " + ViewBag.Product;
                    ViewBag.Header = ViewBag.Product;

                    return View();
                }
            }
        } //Accessories
    }
}