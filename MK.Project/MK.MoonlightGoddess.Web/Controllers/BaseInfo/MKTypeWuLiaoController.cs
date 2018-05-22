using MK.MoonlightGoddess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers.BaseInfo
{
    public class MKTypeWuLiaoController : Controller
    {
        // GET: MKTypeWuLiao
        public ActionResult Index()
        {
            return View("../BaseInfoViews/MKTypeWuLiao");
        }

        public JsonResult Select(string sqlName)
        {
            return Json(ServiceMKTypeWuLiao.SelectWuLiaoType("MK_Type_WuLiao", sqlName));
        }
    }
}