---
title: CS 460 Homework 7
layout: hw7
---
## About Homework 7

In homework 7, the goal was to learn ajax by connecting the Giphy API. The original assignment can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW7.html) and the code itself can be found [here](https://github.com/mcalawa/senior_project/tree/master/CS_460_Software_Engineering/HW7).

## A Single-Page Web App

Part of the goal of the project was to create an app that was only a single page. In order to do this in MVC, you are required to have, at the very least, one controller, a view, and a script. Additionally, we were required to have some sort of non-default routing in our RouteConfig file and the ability to process Json results. 

Since we needed a non-default route anyway, I decided to have two controllers: a Home controller and a Result controller. The Home controller has the sole purpose of returning a view. The Result controller, on the other hand, is where all the actual work of getting and returning the Json results is accomplished. Since the Home controller doesn't really do anything special, I will start by showing you the Result controller:

```cs
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
```
As you can see, the only thing the Index view of the Result controller does is return the view of the Home controller's Index.

## A Video Demo

Instead of screenshots, I've uploaded a demo video that shows the completed homework in action. A trigger warning for some body horror, I guess, since one of the things I searched was the excellent philosophical anime series Mushishi and some of the results may have involved animated eyes falling out of heads.

<iframe width="560" height="315" src="https://www.youtube.com/embed/-hVu7lIxGR4" frameborder="0" gesture="media" allow="encrypted-media" allowfullscreen></iframe>