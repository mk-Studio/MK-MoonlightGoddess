using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Models;
using MK.MoonlightGoddess.Models.EntityModels;
using MK.MoonlightGoddess.Service;
using System;
using System.Collections.Generic;
using System.Data;
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

        public ActionResult UnitestLogin()
        {
            return View("../Login/UnitestLogin");
        }

        [HttpPost]
        public JsonResult OnLogin(MK_Info_User model)
        {
            model.Password = EncryptHelper.GetMD5_16(model.Password);
            var user = ServiceContent<MK_Info_User>.SelectSingle(model, "MK_Info_User", "ValidateLogin");
            if (Convert.ToInt32(user) > 0)
            {
                var userName = EncryptHelper.AES_Encrypt(model.UserName);
                CookieHelper.SetCookie("MoonlightGoddess", userName);
                //EncryptHelper.AES_Encrypt("");
                return Json(new { result = "Y" });
            }
            else
            {
                return Json(new { result = "N" });
            }
        }
    }
}