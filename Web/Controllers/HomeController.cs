﻿using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {            
            this.ViewBag.Title = "Order Page";
            return View();
        }
               

    }
}
