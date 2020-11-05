using System;
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
        public JsonResult Cart(ItemEntry VE,int itemcd)
        {
            try
            {
                Random rnd = new Random();
                int id = rnd.Next(0, 9999);

                int uid = Convert.ToInt32(Session["USER_ID"].ToString());
                var cartid = DB.CART.Where(a => a.USER_ID == uid && a.STATUS == "A").Select(b => b.CART_ID).ToList();
                if(cartid!=null && cartid.Count() > 0)
                {
                    int cart_id = cartid[0];
                    var Q = DB.CART_ITEM.Where(M => M.CART_ID == cart_id).FirstOrDefault();
                    var max_qnty= DB.CART_ITEM.Where(M => M.CART_ID == cart_id).Max(b=>b.QNTY);
                    //Q.CI_ID =id ;
                    Q.CART_ID = cart_id;
                    Q.ITEM_CD = itemcd;
                    Q.QNTY = max_qnty+1;
                    DB.SaveChanges();
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
            ItemEntry VE = new ItemEntry();
            ITEM item = new ITEM();
            item = DB.ITEM.Where(a=>a.ITEM_CD==id).FirstOrDefault();
            VE.ITEM = item;
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

    }
}