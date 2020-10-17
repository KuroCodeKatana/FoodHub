using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FoodHub.Models;
using FoodHub.ViewModels;

namespace FoodHub.Controllers
{
    public class HomeController : Controller
    {
        //Default Home Page
        DbModel DB = new DbModel();

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Menu()
        {
            ItemEntry VE = new ItemEntry();
            VE.ITEMLIST = (from test in DB.ITEM

                     select new ITEMLIST
                     {
                         ITEM_CD = test.ITEM_CD,
                         ITEM_NM=test.ITEM_NM,
                         ITEM_DESC=test.ITEM_DESC,
                         IMG=test.IMG,
                         PRICE=test.PRICE,
                         STATUS=test.STATUS,
                         CATE_CD=test.CATE_CD,
                         ITEM_TYPE=test.ITEM_TYPE
                     }).ToList();
            
            return View(VE);
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
      public JsonResult Single_Item()
        {
            string Item_Name = Session["nm"].ToString();
            var Q = DB.ITEM.Where(m => m.ITEM_NM == Item_Name).FirstOrDefault();
            return Json(Q, JsonRequestBehavior.AllowGet);
            
        }
        
    }
}