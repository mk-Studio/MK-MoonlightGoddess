using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers
{
    public class VerifyLoginController : Controller
    {
        // GET: VerifyLogin

        public ActionResult Login()
        {
            return View();
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            AuthorizationContext test = filterContext;
            base.OnAuthorization(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ActionExecutingContext test = filterContext;
            base.OnActionExecuting(filterContext);
        }
    }
}
