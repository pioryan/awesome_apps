using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smartass.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //// POST api/test
        //[HttpPost]
        //public ActionResult Test(HttpPostedFileBase encoded_image, string btnG)
        //{
        //    return View();
        //}
    }
}
