﻿using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
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
            ItemEntry VE = new ItemEntry();
            VE.BREAKFASTLIST = (from test in DB.ITEM
                                join b in DB.CATEGORY on test.CATE_CD equals b.CATE_CD
                                where b.CATE_NM.ToUpper() == "BREAKFAST" && test.STATUS == "Available"
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
            for (int i = 0; i <= VE.BREAKFASTLIST.Count - 1; i++)
            {
                if (VE.BREAKFASTLIST[i].IMG != null)
                {
                    string filenm = VE.BREAKFASTLIST[i].IMG;
                    string filepath = Server.MapPath("~/Content/ItemImage/" + filenm.ToString());
                    VE.BREAKFASTLIST[i].IMG_FILE = DocpathToBase64(filepath);
                    var mimetype = MimeMapping.GetMimeMapping(filenm);
                    var mimeurl = "data:" + mimetype + ";base64,";
                    VE.BREAKFASTLIST[i].IMG_FILE = (mimeurl + VE.BREAKFASTLIST[i].IMG_FILE);
                    //VE.ITEMLIST[i].IMG_FILE = "~/Content/ItemImage/" + VE.ITEMLIST[i].IMG;
                }
            }
            VE.LUNCHLIST = (from test in DB.ITEM
                            join b in DB.CATEGORY on test.CATE_CD equals b.CATE_CD
                            where b.CATE_NM.ToUpper() == "LUNCH" && test.STATUS == "Available"
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
            for (int i = 0; i <= VE.LUNCHLIST.Count - 1; i++)
            {
                if (VE.LUNCHLIST[i].IMG != null)
                {
                    string filenm = VE.LUNCHLIST[i].IMG;
                    string filepath = Server.MapPath("~/Content/ItemImage/" + filenm.ToString());
                    VE.LUNCHLIST[i].IMG_FILE = DocpathToBase64(filepath);
                    var mimetype = MimeMapping.GetMimeMapping(filenm);
                    var mimeurl = "data:" + mimetype + ";base64,";
                    VE.LUNCHLIST[i].IMG_FILE = (mimeurl + VE.LUNCHLIST[i].IMG_FILE);
                    //VE.ITEMLIST[i].IMG_FILE = "~/Content/ItemImage/" + VE.ITEMLIST[i].IMG;
                }
            }
            VE.DINNERLIST = (from test in DB.ITEM
                             join b in DB.CATEGORY on test.CATE_CD equals b.CATE_CD
                             where b.CATE_NM.ToUpper() == "DINNER" && test.STATUS == "Available"
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
            for (int i = 0; i <= VE.DINNERLIST.Count - 1; i++)
            {
                if (VE.DINNERLIST[i].IMG != null)
                {
                    string filenm = VE.DINNERLIST[i].IMG;
                    string filepath = Server.MapPath("~/Content/ItemImage/" + filenm.ToString());
                    VE.DINNERLIST[i].IMG_FILE = DocpathToBase64(filepath);
                    var mimetype = MimeMapping.GetMimeMapping(filenm);
                    var mimeurl = "data:" + mimetype + ";base64,";
                    VE.DINNERLIST[i].IMG_FILE = (mimeurl + VE.DINNERLIST[i].IMG_FILE);
                    //VE.ITEMLIST[i].IMG_FILE = "~/Content/ItemImage/" + VE.ITEMLIST[i].IMG;
                }
            }
            CartUpdate();
            return View(VE);
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
        public JsonResult AddToCart(ItemEntry VE, int itemcd)
        {
            try
            {
                Random rnd = new Random();
                int id = rnd.Next(0, 9999);

                int uid = Convert.ToInt32(Session["USER_ID"].ToString());
                var cartid = DB.CART.Where(a => a.USER_ID == uid && a.STATUS == "A").Select(b => b.CART_ID).ToList();
                if (cartid != null && cartid.Count() > 0)
                {
                    int cart_id = cartid[0];
                    var Q = DB.CART_ITEM.Where(M => M.CART_ID == cart_id && M.ITEM_CD == itemcd).FirstOrDefault();
                    if (Q != null)
                    {
                        var max_qnty = Q.QNTY;
                        Q.ITEM_CD = itemcd;
                        Q.QNTY = max_qnty + 1;
                        DB.SaveChanges();
                    }
                    else
                    {
                        CART_ITEM CARTITEM = new CART_ITEM();
                        CARTITEM.CI_ID = id;
                        CARTITEM.CART_ID = cart_id;
                        CARTITEM.ITEM_CD = itemcd;
                        CARTITEM.QNTY = 1;
                        DB.CART_ITEM.Add(CARTITEM);
                        DB.SaveChanges();
                    }
                }
                else
                {
                    CART CART = new CART();
                    CART.CART_ID = id;
                    CART.USER_ID = Convert.ToInt32(Session["USER_ID"].ToString());
                    CART.STATUS = "A";
                    CART.CART_TIME = System.DateTime.Now;
                    DB.CART.Add(CART);
                    DB.SaveChanges();

                    CART_ITEM CARTITEM = new CART_ITEM();
                    CARTITEM.CI_ID = id;
                    CARTITEM.CART_ID = CART.CART_ID;
                    CARTITEM.ITEM_CD = itemcd;
                    CARTITEM.QNTY = 1;
                    DB.CART_ITEM.Add(CARTITEM);
                    DB.SaveChanges();
                }




                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message + ex.InnerException, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("Home/Single_Item/{id?}")]
        public ActionResult Single_Item(int? id)
        {
            //if (id == null) { } ekhane 404 page e redirect kora uchit
            ItemEntry VE = new ItemEntry();
            ITEM item = new ITEM();
            item = DB.ITEM.Where(a => a.ITEM_CD == id).FirstOrDefault();
            VE.ITEM = item;
            return View(VE);

        }
        public ActionResult Cart()
        {
            CartEntry VE = new CartEntry();
            int uid = Convert.ToInt32(Session["USER_ID"].ToString());
            VE.CARTITEMLIST = (from a in DB.CART_ITEM
                               join b in DB.CART on a.CART_ID equals b.CART_ID into x
                               from b in x.DefaultIfEmpty()
                               join c in DB.ITEM on a.ITEM_CD equals c.ITEM_CD
                               where b.USER_ID == uid && b.STATUS == "A"
                               select new CARTITEMLIST()
                               {
                                   ITEM_CD = a.ITEM_CD,
                                   ITEM_NM = c.ITEM_NM,
                                   PRICE = c.PRICE,
                                   QNTY = a.QNTY.ToString(),
                                   IMG = c.IMG,
                                   CART_ID = a.CART_ID,
                               }).ToList();
            if (VE.CARTITEMLIST != null && VE.CARTITEMLIST.Count() > 0)
            {
                VE.CART_ID = VE.CARTITEMLIST[0].CART_ID;
            }

            double total = 0;
            double totalgst = 0;
            for (int i = 0; i <= VE.CARTITEMLIST.Count - 1; i++)
            {
                if (VE.CARTITEMLIST[i].IMG != null)
                {
                    string filenm = VE.CARTITEMLIST[i].IMG;
                    string filepath = Server.MapPath("~/Content/ItemImage/" + filenm.ToString());
                    VE.CARTITEMLIST[i].IMG_FILE = DocpathToBase64(filepath);
                    var mimetype = MimeMapping.GetMimeMapping(filenm);
                    var mimeurl = "data:" + mimetype + ";base64,";
                    VE.CARTITEMLIST[i].IMG_FILE = (mimeurl + VE.CARTITEMLIST[i].IMG_FILE);
                    //VE.ITEMLIST[i].IMG_FILE = "~/Content/ItemImage/" + VE.ITEMLIST[i].IMG;
                }
                double price = Convert.ToDouble(VE.CARTITEMLIST[i].QNTY) * Convert.ToDouble(VE.CARTITEMLIST[i].PRICE);
                VE.CARTITEMLIST[i].GSTAMT = ((Convert.ToDouble(VE.CARTITEMLIST[i].PRICE)) * 0.18).ToString("F2");
                VE.CARTITEMLIST[i].TOTALPRICE = price.ToString("F2");
                total += Convert.ToDouble(VE.CARTITEMLIST[i].TOTALPRICE);
                totalgst += Convert.ToDouble(VE.CARTITEMLIST[i].GSTAMT);
            }
            ViewBag.totalgst = (total * 0.18).ToString("C2");
            ViewBag.total = total.ToString("C2");
            ViewBag.totalamt = (total + (total * 0.18)).ToString("C2");
            CartUpdate();
            return View(VE);
        }
        public string DocpathToBase64(string path)
        {
            try
            {
                var Docpath = Path.Combine(path);
                byte[] imageBytes = System.IO.File.ReadAllBytes(Docpath);
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public JsonResult UpdateQnty(int ITCD, string BTNID, int CARTID)
        {
            int uid = Convert.ToInt32(Session["USER_ID"].ToString());

            var data = (from a in DB.CART
                        join b in DB.CART_ITEM on a.CART_ID equals b.CART_ID
                        where a.USER_ID == uid && b.ITEM_CD == ITCD
                        select new { b.QNTY, b.CART_ID }
                    ).FirstOrDefault();
            var Q = DB.CART_ITEM.Where(M => M.CART_ID == data.CART_ID && M.ITEM_CD == ITCD).FirstOrDefault();
            int max_qnty = 0;
            if (Q != null)
            {

                if (BTNID == "ADD")
                {
                    max_qnty = Q.QNTY + 1;
                }
                else
                {
                    max_qnty = Q.QNTY - 1;
                }
                Q.QNTY = max_qnty;
                DB.SaveChanges();
            }
            return Json(max_qnty.ToString(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult RemoveCart(int ITCD)
        {
            int uid = Convert.ToInt32(Session["USER_ID"].ToString());

            var data = (from a in DB.CART
                        join b in DB.CART_ITEM on a.CART_ID equals b.CART_ID
                        where a.USER_ID == uid && b.ITEM_CD == ITCD
                        select new { b.CART_ID }
                    ).FirstOrDefault();
            var cart_count = DB.CART_ITEM.Where(M => M.CART_ID == data.CART_ID && M.ITEM_CD != ITCD).ToList();
            var Q = DB.CART_ITEM.Where(M => M.CART_ID == data.CART_ID && M.ITEM_CD == ITCD).FirstOrDefault();
            DB.CART_ITEM.Remove(Q);
            DB.SaveChanges();
            if (cart_count != null && cart_count.Count() == 0)
            {
                var R = DB.CART.Where(M => M.CART_ID == data.CART_ID && M.USER_ID == uid).FirstOrDefault();
                DB.CART.Remove(R);
                DB.SaveChanges();
            }
            return Json("1", JsonRequestBehavior.AllowGet);
        }
        public void CartUpdate()
        {
            int uid = Convert.ToInt32(Session["USER_ID"].ToString());
            ViewBag.CartCount = (from a in DB.CART
                                 join b in DB.CART_ITEM on a.CART_ID equals b.CART_ID
                                 where a.USER_ID == uid && a.STATUS == "A"
                                 select new { b.ITEM_CD }
                    ).Distinct().Count();
        }
        public ActionResult OrderPlace(ItemEntry VE, int CARTID)
        {
            int uid = Convert.ToInt32(Session["USER_ID"].ToString());
            Random rnd = new Random();
            int id = rnd.Next(0, 9999);
            ORDER ORDER_ITM = new ORDER();
            ORDER_ITM.ORDER_ID = id;
            ORDER_ITM.USER_ID = uid;
            ORDER_ITM.CART_ID = CARTID;
            ORDER_ITM.AMOUNT =Convert.ToDecimal(ViewBag.totalamt);
            ORDER_ITM.START_TIME = System.DateTime.Now.Date;
            ORDER_ITM.STATUS = "Order";
            ORDER_ITM.REMARKS = "Order Sucessfull";
            DB.ORDER.Add(ORDER_ITM);
            DB.SaveChanges();

            var Q = DB.CART.Where(M => M.CART_ID == CARTID && M.USER_ID == uid).FirstOrDefault();
            Q.STATUS = "O";
            DB.SaveChanges();

            return Content("1");
        }

    }
}