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
        
        /// <summary>
        /// 重写控制器访问之前的处理
        /// 暂留，后面再写
        /// 2018.5.20
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}