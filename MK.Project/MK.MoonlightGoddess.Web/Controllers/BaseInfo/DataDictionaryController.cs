using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Models;
using MK.MoonlightGoddess.Models.EntityModels;
using MK.MoonlightGoddess.Models.ResultModels;
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
        public JsonResult GetQueryTypeWuLiuYeWu(MK_Type_WuLiuYeWu model)
        {
            var jsonResult = ServiceContent<MK_Type_WuLiuYeWu>.Query(model, "DataDictionary", "QueryTypeWuLiuYeWu");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult GetQueryInfoCurrency(MK_Info_Currency model)
        {
            var jsonResult = ServiceContent<MK_Info_Currency>.Query(model, "DataDictionary", "QueryInfoCurrency");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult GetQueryInfoWuLiuCompany(MK_Info_WuLiuCompany model)
        {
            var jsonResult = ServiceContent<MK_Info_WuLiuCompany>.Query(model, "DataDictionary", "QueryInfoWuLiuCompany");
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
        public JsonResult ExceInfoSupplier(MK_Info_Supplier model, List<SupelierWuLiaoDetail> detailModel, string name)
        {
            var _ID = name != "Insert" ? model.ID : Guid.NewGuid().ToString().ToUpper();
            model.ID = _ID;
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            bool _result = false;
            if (name == "Insert" || name == "Update")
            {
                List<MK_Info_Supplier_WuLiao> listSp = new List<MK_Info_Supplier_WuLiao>();
                foreach (SupelierWuLiaoDetail sp in detailModel)
                {
                    MK_Info_Supplier_WuLiao newObj = new MK_Info_Supplier_WuLiao()
                    {
                        ID = Guid.NewGuid().ToString().ToUpper(),
                        SupplierID = _ID,
                        ShangPinID = sp.val,
                        ShowMark = "Y",
                        CreateUser = CurrAccount.UserName,
                        CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                    listSp.Add(newObj);
                }
                var spWuLiaoTable = ConvertHelper.ListToTable(listSp, true, true);
                _result = ServiceContent<MK_Info_Supplier>.SelectSIDU(model, "DataDictionary", name + "InfoSupplier");
                if (_result) _result = ServiceContent<dynamic>.DataTableToSQLServer(spWuLiaoTable, "MK_Info_Supplier_WuLiao");
            }
            else { 
               _result = ServiceContent<MK_Info_Supplier>.SelectSIDU(model, "DataDictionary", name + "InfoSupplier");
            }
            return _result ? Json(AjaxResultModel.CreateMessage((!_result), "ssuccess", 1, _result))
                    : Json(AjaxResultModel.CreateMessage((!_result), "error", -1, _result));
        }

        [HttpPost]
        public JsonResult ExceTypeWuLiuYeWu(MK_Type_WuLiuYeWu model, string name)
        {
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var jsonResult = ServiceContent<MK_Type_WuLiuYeWu>.AjaxSIDU(model, "DataDictionary", name + "TypeWuLiuYeWu");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult ExceInfoWuLiuCompany(MK_Info_WuLiuCompany model, string name)
        {
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var jsonResult = ServiceContent<MK_Info_WuLiuCompany>.AjaxSIDU(model, "DataDictionary", name + "InfoWuLiuCompany");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult ExceInfoCurrency(MK_Info_Currency model, string name)
        {
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var jsonResult = ServiceContent<MK_Info_Currency>.AjaxSIDU(model, "DataDictionary", name + "InfoCurrency");
            return Json(jsonResult);
        }

        public ContentResult GetWuLiaoTypeID(string id)
        {
            var stringResult = ServiceContent<dynamic>.SelectSingle(new {ID = id }, "DataDictionary", "GetWuLiaoTypeID");
            return Content(stringResult);
        }

        public JsonResult GetShangPinBySupplier(string id)
        {
            var _dataSoruce = ServiceContent<dynamic>.SelectData(new { SupplierID = id }, "DataDictionary", "GetShangPinBySupplier");
            List<String> result = new List<String>();
            foreach (System.Data.DataRow row in _dataSoruce.Rows)
                result.Add(row["ShangPinID"].ToString());
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveWuLiaoImagePath(MK_Info_WuLiao model)
        {
            var jsonResult = ServiceContent<MK_Info_WuLiao>.AjaxSIDU(model, "DataDictionary", "SaveWuLiaoImagePath");
            return Json(jsonResult);
        }

        public JsonResult UpdateShowMark(string ID, string ShowMark, string name)
        {
            var jsonResult = ServiceContent<dynamic>.AjaxSIDU(new { ID = ID, ShowMark = ShowMark, name = name}, "DataDictionary", name);
            return Json(jsonResult);
        }
    }
}