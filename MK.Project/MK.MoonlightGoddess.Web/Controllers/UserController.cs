using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers
{
    public class UserController : VerifyLoginController
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SecuritySettings()
        {
            return View();
        }
    }
}