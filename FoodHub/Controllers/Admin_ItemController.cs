using FoodHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodHub.Models;
using System.Security.Cryptography;
using System.IO;

namespace FoodHub.Controllers
{
    public class Admin_ItemController : Controller
    {
        DbModel DB = new DbModel();
        //string path = @"C:\ItemImage";

        // GET: Admin_Item
        public ActionResult Index()
        {
            ItemEntry VE = new ItemEntry();
            //STATUS
            List<STATUS_DROPDOWN> STATUS = new List<STATUS_DROPDOWN>();
            STATUS_DROPDOWN STATUS3 = new STATUS_DROPDOWN();
            STATUS3.Text = "Available";
            STATUS3.Value = "Available";
            STATUS.Add(STATUS3);
            STATUS_DROPDOWN STATUS2 = new STATUS_DROPDOWN();
            STATUS2.Text = "Not Available";
            STATUS2.Value = "Not Available";
            STATUS.Add(STATUS2);
            VE.STATUS_DROPDOWN = STATUS;

            //ITEM_TYPE
            List<ITEM_TYPE_DROPDOWN> ITEMTYPE = new List<ITEM_TYPE_DROPDOWN>();
            ITEM_TYPE_DROPDOWN ITEMTYPE3 = new ITEM_TYPE_DROPDOWN();
            ITEMTYPE3.Text = "Veg";
            ITEMTYPE3.Value = "Veg";
            ITEMTYPE.Add(ITEMTYPE3);
            ITEM_TYPE_DROPDOWN ITEMTYPE2 = new ITEM_TYPE_DROPDOWN();
            ITEMTYPE2.Text = "Non-Veg";
            ITEMTYPE2.Value = "Non-Veg";
            ITEMTYPE.Add(ITEMTYPE2);
            VE.ITEM_TYPE_DROPDOWN = ITEMTYPE;

            //CATE_CD
            VE.CATE_CD_DROPDOWN = (from n in DB.CATEGORY
                                   select new CATE_CD_DROPDOWN() { Text = n.CATE_NM, Value = n.CATE_CD }).OrderBy(s => s.Value).Distinct().ToList();

            VE.ITEMLIST = (from a in DB.ITEM
                           join b in DB.CATEGORY on a.CATE_CD equals b.CATE_CD into x
                           from b in x.DefaultIfEmpty()
                           select new ITEMLIST()
                           {
                               ITEM_CD = a.ITEM_CD,
                               ITEM_NM = a.ITEM_NM,
                               ITEM_DESC = a.ITEM_DESC,
                               IMG = a.IMG,
                               PRICE = a.PRICE,
                               STATUS = a.STATUS,
                               CATE_CD = a.CATE_CD,
                               CATE_NM = b.CATE_NM,
                               ITEM_TYPE = a.ITEM_TYPE
                           }).ToList();
            for (int i = 0; i <= VE.ITEMLIST.Count - 1; i++)
            {
                VE.ITEMLIST[i].SLNO = Convert.ToInt32(i + 1);
                if (VE.ITEMLIST[i].IMG != null)
                {
                    string filenm = VE.ITEMLIST[i].IMG;
                    string filepath = Server.MapPath("~/Content/ItemImage/" + filenm.ToString());
                    VE.ITEMLIST[i].IMG_FILE = DocpathToBase64(filepath);
                    var mimetype = MimeMapping.GetMimeMapping(filenm);
                    var mimeurl = "data:" + mimetype + ";base64,";
                    VE.ITEMLIST[i].IMG_FILE = (mimeurl + VE.ITEMLIST[i].IMG_FILE);
                    //VE.ITEMLIST[i].IMG_FILE = "~/Content/ItemImage/" + VE.ITEMLIST[i].IMG;
                }
            }
            return View(VE);
        }
        public JsonResult Save(ItemEntry VE)
        {
            try
            {

                //string filename = path + "/"  + VE.ITEM.IMG;
                //SaveImage(VE.IMG_FILE, filename);

                ITEM CAT = new ITEM();
                Random rnd = new Random();
                int id = rnd.Next(0, 9999);
                string ext = Path.GetExtension(VE.ITEM.IMG);
                string filename = Server.MapPath("~/Content/ItemImage/" + id.ToString() + ext);// path + "/" + id.ToString() + ext;
                SaveImage(VE.IMG_FILE, filename);
                CAT.ITEM_CD = id;
                CAT.ITEM_NM = VE.ITEM.ITEM_NM;
                CAT.ITEM_DESC = VE.ITEM.ITEM_DESC;
                CAT.IMG = id.ToString() + ext;
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
                         where a.ITEM_CD == ItemCode
                         select new
                         {
                             ITEM_CD = a.ITEM_CD,
                             ITEM_NM = a.ITEM_NM,
                             ITEM_DESC = a.ITEM_DESC,
                             IMG = a.IMG,
                             PRICE = a.PRICE,
                             STATUS = a.STATUS,
                             CATE_CD = a.CATE_CD,
                             ITEM_TYPE = a.ITEM_TYPE,
                         }).FirstOrDefault();


                string IMG_FILE = "";
                if (Q.IMG != null)
                {
                    string filenm = Q.IMG;
                    string filepath = Server.MapPath("~/Content/ItemImage/" + filenm.ToString());
                    var IMG_FILE1 = DocpathToBase64(filepath);
                    var mimetype = MimeMapping.GetMimeMapping(filenm);
                    var mimeurl = "data:" + mimetype + ";base64,";
                    IMG_FILE = (mimeurl + IMG_FILE1);
                }
                string data = Q + "~~~" + IMG_FILE;

                return Json(data, JsonRequestBehavior.AllowGet);
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
            string ext = Path.GetExtension(VE.ITEM.IMG);
            string filename = Server.MapPath("~/Content/ItemImage/" + Q.ITEM_CD.ToString() + ext);// path + "/" + id.ToString() + ext;
            SaveImage(VE.IMG_FILE, filename);
            Q.ITEM_NM = VE.ITEM.ITEM_NM;
            Q.ITEM_DESC = VE.ITEM.ITEM_DESC;
            Q.IMG = Q.ITEM_CD.ToString() + ext;
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
        public string SaveImage(string DBImgString, string ImgPath)
        {
            try
            {
                if (DBImgString != "" || DBImgString.IndexOf(',') > 1)
                {
                    DBImgString = DBImgString.Substring(DBImgString.IndexOf(',') + 1);
                }
                var sPath = Path.Combine(ImgPath);


                //var sPath = HttpContext.Current.Server.MapPath(ImgPath);
                //String path = @"c:/Improvar";

                if (System.IO.File.Exists(sPath))
                {
                    System.IO.File.Delete(sPath); //Delete file if it  exist
                }
                byte[] imageBytes = Convert.FromBase64String(DBImgString);
                System.IO.File.WriteAllBytes(sPath, imageBytes);
                return sPath;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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