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
            var data = ServiceContent<MK_Info_User>.SelectData(model, "MK_Info_User", "ValidateLogin");
            var userName = EncryptHelper.AES_Encrypt(model.UserName);
            CookieHelper.SetCookie("MoonlightGoddess", userName);
            //EncryptHelper.AES_Encrypt("");
            var result = new {
                code = Convert.ToInt32(data.Rows[0]["Code"]),
                message = data.Rows[0]["Message"].ToString() == "SUCCESS" 
                ? "../Index/Home"
                : data.Rows[0]["Message"].ToString()
            };
            return Json(result);
        }
    }
}