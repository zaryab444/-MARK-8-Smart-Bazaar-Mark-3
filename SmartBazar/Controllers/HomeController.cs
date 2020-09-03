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

        
    }
}