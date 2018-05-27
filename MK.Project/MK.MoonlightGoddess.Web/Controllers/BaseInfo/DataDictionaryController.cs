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
    public class DataDictionaryController : VerifyLoginController
    {
        // GET: DataDictionary
        public ActionResult Index()
        {
            return View("../BaseInfoViews/DataDictionary");
        }

        [HttpPost]
        public JsonResult GetQueryInfoWuLiao(MK_Info_WuLiao model)
        {
            var jsonResult = ServiceContent<MK_Info_WuLiao>.Query(model, "DataDictionary", "QueryInfoWuLiao");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult GetInfoWuLiaoExists(MK_Info_WuLiao model)
        {
            var jsonResult = ServiceContent<MK_Info_WuLiao>.AjaxSingle(model, "DataDictionary", "CheckInfoWuLiaoEXISTS");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult ExceResult(MK_Info_WuLiao model)
        {
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd");
            var jsonResult = ServiceContent<MK_Info_WuLiao>.AjaxSIDU(model, "DataDictionary", "InsertInfoWuLiao");
            return Json(jsonResult);
        }

    }
}