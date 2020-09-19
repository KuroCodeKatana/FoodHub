using FoodHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodHub.Models;
using System.Security.Cryptography;

namespace FoodHub.Controllers
{
    public class Admin_ItemController : Controller
    {
        DbModel DB = new DbModel();
        // GET: Admin_Item
        public ActionResult Index()
        {
            ItemEntry VE = new ItemEntry();
            VE.ITEMLIST = (from a in DB.ITEM
                           select new ITEMLIST()
                           {
                               ITEM_CD = a.ITEM_CD,
                               ITEM_NM = a.ITEM_NM,
                               ITEM_DESC = a.ITEM_DESC,
                               IMG = a.IMG,
                               PRICE = a.PRICE,
                               STATUS = a.STATUS,
                               CATE_CD = a.CATE_CD,
                               ITEM_TYPE = a.ITEM_TYPE
                           }).ToList();
            for (int i = 0; i <= VE.ITEMLIST.Count - 1; i++)
            {
                VE.ITEMLIST[i].SLNO = Convert.ToInt32(i + 1);
            }
            return View(VE);
        }
        public JsonResult Save(ItemEntry VE)
        {
            try
            {
                ITEM CAT = new ITEM();
                Random rnd = new Random();
                int id = rnd.Next(0, 9999);
                CAT.ITEM_CD = id;
                CAT.ITEM_NM = VE.ITEM.ITEM_NM;
                CAT.ITEM_DESC = VE.ITEM.ITEM_DESC;
                CAT.IMG = VE.ITEM.IMG;
                CAT.PRICE = VE.ITEM.PRICE;
                CAT.STATUS = VE.ITEM.STATUS;
                CAT.CATE_CD = VE.ITEM.CATE_CD;
                CAT.ITEM_TYPE = VE.ITEM.ITEM_TYPE;
                DB.ITEM.Add(CAT);
                DB.SaveChanges();
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message + ex.InnerException, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult GetItem(int ItemCode)
        {
            try
            {
                var Q = (from a in DB.ITEM
                         select new
                         {
                             ITEM_CD = a.ITEM_CD,
                             ITEM_NM = a.ITEM_NM,
                             ITEM_DESC = a.ITEM_DESC,
                             IMG = a.IMG,
                             PRICE = a.PRICE,
                             STATUS = a.STATUS,
                             CATE_CD = a.CATE_CD,
                             ITEM_TYPE = a.ITEM_TYPE

                         }).FirstOrDefault();
                
                return Json(Q, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message + ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Update(ItemEntry VE)
        {
            int code = VE.ITEM.ITEM_CD;
            var Q = DB.ITEM.Where(M => M.ITEM_CD == code).FirstOrDefault();
            Q.ITEM_NM = VE.ITEM.ITEM_NM;
            Q.ITEM_DESC = VE.ITEM.ITEM_DESC;
            Q.IMG = VE.ITEM.IMG;
            Q.PRICE = VE.ITEM.PRICE;
            Q.STATUS = VE.ITEM.STATUS;
            Q.CATE_CD = VE.ITEM.CATE_CD;
            Q.ITEM_TYPE = VE.ITEM.ITEM_TYPE;
            DB.SaveChanges();
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteUser(int ItemCode)
        {
            var Q = DB.ITEM.Where(M => M.ITEM_CD == ItemCode).FirstOrDefault();
            DB.ITEM.Remove(Q);
            DB.SaveChanges();
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}