using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaderTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
     
        public ActionResult Products()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ProductsList()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Order()
        {
            return View();
        }


    }
}