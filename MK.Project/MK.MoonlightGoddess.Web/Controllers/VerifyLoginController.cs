using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Models.EntityModels;
using MK.MoonlightGoddess.Web.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers
{
    [MKExceptionFilter]
    public class VerifyLoginController : Controller
    {
        // GET: VerifyLogin

        public MK_Info_User CurrAccount { get; set; }
        
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var _userName = CookieHelper.GetCookieValue("MoonlightGoddess");
            if (!string.IsNullOrEmpty(_userName))
            {
                CurrAccount = new MK_Info_User() { UserName = EncryptHelper.AES_Decrypt(_userName) };
            }
            else
            {
                Response.Redirect("~/");
            }
        }
    }
}
