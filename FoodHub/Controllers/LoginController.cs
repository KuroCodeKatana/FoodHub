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
        //DbModel db;

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //This action is called on pressing the "Register Now" button
        public ActionResult Register() 
        {
            return null;
        }

        //This function is called on pressing the "Login" button 
        public ActionResult Login()
        {
            return null;
        }
    }
}