using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodHub.Controllers
{
    public class HomeController : Controller
    {
        //Default Home Page
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

    }
}