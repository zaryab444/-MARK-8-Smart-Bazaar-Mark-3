using SmartBazar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartBazar.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        EcommerceEntities db = new EcommerceEntities();
        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_Admin avm)
        {
            tbl_Admin ad = db.tbl_Admin.Where(x => x.ad_username == avm.ad_username && x.ad_password == avm.ad_password).SingleOrDefault();
            if (ad != null)
            {

                Session["ad_id"] = ad.ad_id.ToString();
                return RedirectToAction("Dashboard");

            }
            else
            {
                ViewBag.error = "Invalid username or password";

            }
            return View();

        }

        public ActionResult Add_Category()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Category(tbl_Category cvm)
        {
            
                tbl_Category cat = new tbl_Category();
                cat.cat_name = cvm.cat_name;
                cat.cat_color = cvm.cat_color;
                cat.cat_icon = cvm.cat_icon;
                cat.cat_createdon = DateTime.Now;
                cat.cat_fk_Ad_id = cvm.cat_fk_Ad_id;
                db.tbl_Category.Add(cat);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            
        }

        public string uploadimgfile(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {

                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);

                        //    ViewBag.Message = "File uploaded successfully";E:\Alumni_Student_Portal\Alumni_Student_Portal\Content\upload\
                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");
                }
            }

            else
            {
                Response.Write("<script>alert('Please select a file'); </script>");
                path = "-1";
            }



            return path;
        }
    }
}