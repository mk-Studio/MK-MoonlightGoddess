using MK.MoonlightGoddess.Models.EntityModels;
using MK.MoonlightGoddess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers.BaseInfo
{
    /// <summary>
    /// 数据字典
    /// </summary>
    public class DataDictionaryController : Controller
    {
        // GET: DataDictionary
        public ActionResult Index()
        {
            return View("../BaseInfoViews/DataDictionary");
        }

        [HttpPost]
        public JsonResult GetQueryInfoWuLiao(MK_Info_WuLiao model)
        {
            var jsonResult = ServiceContent<MK_Info_WuLiao>.Select(model, "MK_Info_WuLiao", "QueryToInfoWuLiao");
            return Json(jsonResult);
        }


    }
}