using MK.MoonlightGoddess.Models.EntityModels;
using MK.MoonlightGoddess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers.BaseInfo
{
    public class DictionaryManageController : VerifyLoginController
    {
        // GET: DictionaryManage/ViewManage
        public ActionResult ViewManage()
        {
            return View("../BaseInfoViews/DictionaryManage");
        }
        
        public JsonResult GetQueryDictionaryLabel(MK_Type_DictionaryLabel model)
        {
            var jsonResult = ServiceContent<MK_Type_DictionaryLabel>.Select(model, "DataDictionary", "GetQueryDictionaryLabel", true);
            return Json(jsonResult);
        }

        public JsonResult GetQueryDataDictionary(MK_Type_DataDictionary model)
        {
            var jsonResult = ServiceContent<MK_Type_DataDictionary>.Query(model, "DataDictionary", "GetQueryDataDictionary", true);
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult ExecuteDictionaryLabel(MK_Type_DictionaryLabel model, string name)
        {
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var jsonResult = ServiceContent<MK_Type_DictionaryLabel>.AjaxSingle(model, "DataDictionary", name + "TypeDictionaryLabel");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult ExecuteDataDictionary(MK_Type_DataDictionary model, string name)
        {
            model.DataDesc = model.DataDesc == null ? "" : model.DataDesc;
            model.DataPlaceholder = model.DataPlaceholder == null ? "" : model.DataPlaceholder;
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var jsonResult = ServiceContent<MK_Type_DataDictionary>.AjaxSIDU(model, "DataDictionary", name + "TypeDataDictionary");
            return Json(jsonResult);
        }
    }
}