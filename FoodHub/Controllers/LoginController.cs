using FoodHub.Models;
using FoodHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodHub.Controllers
{
    public class LoginController : Controller
    {
        DbModel db;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(RegistrationModel rm)
        {
            rm.USER_DETAILS.USER_NAME = db.USER_DETAILS.
        }
    }
}