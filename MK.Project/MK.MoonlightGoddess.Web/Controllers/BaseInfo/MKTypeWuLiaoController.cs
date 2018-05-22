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

        public ActionResult Select()
        {
            return Content(ServiceMKTypeWuLiao.SelectWuLiaoType());
        }

        public ActionResult Select2(string sqlName)
        {
            return Content(ServiceMKTypeWuLiao.SelectWuLiaoType("MK_Type_WuLiao", sqlName));
        }
    }
}