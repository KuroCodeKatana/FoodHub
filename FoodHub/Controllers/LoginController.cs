using FoodHub.Models;
using FoodHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace FoodHub.Controllers
{
    public class LoginController : Controller
    {
        DbModel db = new DbModel();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //This action is called on pressing the "Register Now" button
        public ActionResult Register(LoginViewModel VE)
        {
            try
            {
                USER_DETAILS USERDETAILS = new USER_DETAILS();
                USERDETAILS.USER_ID = VE.USER_DETAILS.USER_ID;
                db.USER_DETAILS.Add(USERDETAILS);

                return Content("Save Sucessfull !!");
            }
            catch (Exception ex)
            {
                return Content(ex.Message + ex.InnerException);
            }
        }

        //This function is called on pressing the "Login" button 
        public ActionResult Signup(LoginViewModel VE)
        {
            try
            {
                string unm = VE.USER_NAME;
                string pass = VE.PASSWORD;
                var uid = db.USER_DETAILS.Where(a => a.USER_NAME == unm && a.PASSWORD == pass).Select(B => B.USER_ID).ToList();
                if (uid != null && uid.Count > 0)
                {
                    Session.Add("USER_ID", uid[0]);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Content("Invalid User Id and Password !!");
                }
            }
            catch(Exception ex)
            {
                return Content(ex.Message + ex.InnerException);

            }
            
        }

        public JsonResult GetState()
        {
            var Q = (from test in db.STATEs select new { test.STATE_ID, test.STATE_NAME }).ToList();
            return Json(Q, JsonRequestBehavior.AllowGet);
        }
    }
}