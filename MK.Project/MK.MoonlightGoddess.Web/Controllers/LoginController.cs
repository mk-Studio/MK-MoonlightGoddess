using MK.MoonlightGoddess.Models.EntityModels;
using MK.MoonlightGoddess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult OnLogin(MK_Info_User model)
        {
            var jsonResult = ServiceContent<MK_Info_User>.Select(model, "MK_Info_User", "QueryTest");
            return Json(jsonResult);
            //var jsonResult = ServiceContent<MK_Info_User>.SelectSingle(model, "MK_Info_User", "ValidateLogon");
            //return Json(jsonResult);
        }
    }
}