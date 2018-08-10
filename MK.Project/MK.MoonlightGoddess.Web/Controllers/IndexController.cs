using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Models.ResultModels;
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
            ViewBag.UserName = CurrAccount.UserName;
            return View("../Index/Home");
        }

        public ActionResult Exit()
        {
            CookieHelper.ClearCookie("MoonlightGoddess");
            return View("../Index/Home");
        }

        public ActionResult Admin()
        {
            return View("../Index/Admin");
        }

        [HttpGet]
        public JsonResult GetMenus()
        {
            var data = Service.ServiceContent<dynamic>.SelectData(new { UserName = CurrAccount.UserName},"Home", "GetMenus");
            var result = WebSiteMenusResultModel.GetMenus(data);
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}