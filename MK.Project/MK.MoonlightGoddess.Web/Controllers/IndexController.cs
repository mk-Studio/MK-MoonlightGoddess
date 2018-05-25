using MK.MoonlightGoddess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers
{
    public class IndexController : VerifyLoginController
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            ViewBag.UserName = CookieHelper.GetCookieValue("UserName");
            return View("../Index/Home");
        }

        public ActionResult Admin()
        {
            return View("../Index/Admin");
        }
    }
}