using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodHub.Models;
using FoodHub.ViewModels;

namespace FoodHub.Controllers
{
    public class Admin_CategoryController : Controller
    {
        DbModel DB = new DbModel();
        // GET: Admin_Category
        public ActionResult Admin_Category()
        {
            CategoryEntry VE = new CategoryEntry();
            VE.CATEGORYLIST = (from a in DB.CATEGORY
                               select new CATEGORYLIST()
                               {
                                   CATE_CD = a.CATE_CD,
                                   CATE_NM = a.CATE_NM,
                                   CATE_DESC = a.CATE_DESC
                               }).ToList();
            for (int i = 0; i <= VE.CATEGORYLIST.Count - 1; i++)
            {
                VE.CATEGORYLIST[i].SLNO = Convert.ToInt32(i + 1);
            }
            return View(VE);
        }
        public JsonResult Save(CategoryEntry VE)
        {
            try
            {
                CATEGORY CAT = new CATEGORY();
                Random rnd = new Random();
                int id = rnd.Next(0, 9999);
                CAT.CATE_CD = id;
                CAT.CATE_NM = VE.CATEGORY.CATE_NM;
                CAT.CATE_DESC = VE.CATEGORY.CATE_DESC;
                DB.CATEGORY.Add(CAT);
                DB.SaveChanges();
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message + ex.InnerException, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult GetCategory(int CateCode)
        {
            var Q = DB.CATEGORY.Where(M => M.CATE_CD == CateCode).FirstOrDefault();
            return Json(Q, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(CategoryEntry VE)
        {
            int code = VE.CATEGORY.CATE_CD;
            var Q = DB.CATEGORY.Where(M => M.CATE_CD == code).FirstOrDefault();
            Q.CATE_NM = VE.CATEGORY.CATE_NM;
            Q.CATE_DESC = VE.CATEGORY.CATE_DESC;
            DB.SaveChanges();
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteUser(int CateCode)
        {
            var Q = DB.CATEGORY.Where(M => M.CATE_CD == CateCode).FirstOrDefault();
            DB.CATEGORY.Remove(Q);
            DB.SaveChanges();
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}