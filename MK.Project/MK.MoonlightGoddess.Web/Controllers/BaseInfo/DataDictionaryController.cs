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
        public JsonResult GetQueryTypeWuLiao(MK_Type_WuLiao model)
        {
            var jsonResult = ServiceContent<MK_Type_WuLiao>.Query(model, "DataDictionary", "QueryTypeWuLiao");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult GetQueryInfoSupplier(MK_Info_Supplier model)
        {
            var jsonResult = ServiceContent<MK_Info_Supplier>.Query(model, "DataDictionary", "QueryInfoSupplier");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult GetInfoWuLiaoExists(MK_Info_WuLiao model)
        {
            var jsonResult = ServiceContent<MK_Info_WuLiao>.AjaxSingle(model, "DataDictionary", "CheckInfoWuLiaoEXISTS");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult ExceInfoWuLiao(MK_Info_WuLiao model, string name)
        {
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var jsonResult = ServiceContent<MK_Info_WuLiao>.AjaxSIDU(model, "DataDictionary", name + "InfoWuLiao");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult ExceTypeWuLiao(MK_Type_WuLiao model,  string name)
        {
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var jsonResult = ServiceContent<MK_Type_WuLiao>.AjaxSIDU(model, "DataDictionary", name + "TypeWuLiao");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult ExceInfoSupplier(MK_Info_Supplier model, MK_Info_Supplier_WuLiao detailModel, string name)
        {
            var _ID = Guid.NewGuid().ToString().ToUpper();
            model.ID = _ID;
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var jsonResult = ServiceContent<MK_Info_Supplier>.AjaxSIDU(model, "DataDictionary", name + "TypeWuLiao");

            return Json(jsonResult);
        }

        public ContentResult GetWuLiaoTypeID(string id)
        {
            var stringResult = ServiceContent<dynamic>.SelectSingle(new {ID = id }, "DataDictionary", "GetWuLiaoTypeID");
            return Content(stringResult);
        }
    }
}