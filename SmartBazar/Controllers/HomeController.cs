using SmartBazar.Models.Repository;
using SmartBazar.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartBazar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CategoryRepository cr = new CategoryRepository();
            List<Category> li = cr.ViewCategory();
            ViewBag.Categorylist = li;
            return View();
        }

        public ActionResult product(int?id)
        {
            ProductRepository pr = new ProductRepository();
            List<Product> li = pr.ViewProduct().Where(x => x.pro_fk_cat_id == id).ToList();
            ViewBag.productlist = li;

            return View();
        }
        public ActionResult productdetails(int?id)
        {

            ProductRepository pr = new ProductRepository();
            if (id == null)
            {
                ViewData["data"] = pr.GetProductById((int)id);
            }


            return View();
        }
    }
}