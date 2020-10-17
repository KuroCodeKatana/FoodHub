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
                               ITEM_NM = test.ITEM_NM,
                               ITEM_DESC = test.ITEM_DESC,
                               IMG = test.IMG,
                               PRICE = test.PRICE,
                               STATUS = test.STATUS,
                               CATE_CD = test.CATE_CD,
                               ITEM_TYPE = test.ITEM_TYPE
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
        public ActionResult Single_Item()
        {
            ItemEntry VE = new ItemEntry();
            string Item_Code = Session["itcs"].ToString();
            ITEM item = new ITEM();
            item = DB.ITEM.Find(Item_Code);
            VE.ITEM = item;
            return View(VE);

        }

    }
}