using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Models;
using MK.MoonlightGoddess.Models.EntityModels;
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

        [HttpPost]
        public JsonResult Select(MK_Type_WuLiao model)
        {
            var jsonResult = ServiceContent<MK_Type_WuLiao>.Select(model, "MK_Type_WuLiao", "QueryTest");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult GetSingleResult(MK_Type_WuLiao model)
        {
            var jsonResult = ServiceContent<MK_Type_WuLiao>.AjaxSingle(model, "MK_Type_WuLiao", "QuerySingleTest");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult GetSelectOptions(MK_Type_WuLiao model)
        {
            var jsonResult = ServiceContent<MK_Type_WuLiao>.GetSelectOptionsBySqlName(model, "WuLiaoType");
            return Json(jsonResult);
        }
    }
}