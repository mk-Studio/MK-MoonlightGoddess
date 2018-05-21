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
        public JsonResult OnLogin(string title,string password)
        {
            if (title == "mk" && password == "123")
            {
                return Json(new { result = "Y" });
            }
            else
            {
                return Json(new { result = "N" });
            }
        }
    }
}