using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Models.EntityModels;
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

        public MK_Info_User CurrAccount { get; set; }
        
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var _id = SessionHelper.GetSession("ID");
            var _username = SessionHelper.GetSession("UserName");
            if (_id == null || _username == null)
            {
                CurrAccount.ID = _id.ToString();
                CurrAccount.UserName = _username.ToString();
                filterContext.Result = RedirectToRoute(new { Controller = "Login", Action = "Index" });
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
