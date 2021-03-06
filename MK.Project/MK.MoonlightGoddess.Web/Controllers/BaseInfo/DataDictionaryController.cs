﻿using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Models;
using MK.MoonlightGoddess.Models.EntityModels;
using MK.MoonlightGoddess.Models.ResultModels;
using MK.MoonlightGoddess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var jsonResult = ServiceContent<MK_Info_WuLiao>.Query(model, "DataDictionary", "QueryInfoWuLiao",true);
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult GetQueryTypeWuLiao(MK_Type_WuLiao model)
        {
            var jsonResult = ServiceContent<MK_Type_WuLiao>.Query(model, "DataDictionary", "QueryTypeWuLiao",true);
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult GetQueryInfoSupplier(MK_Info_Supplier model, List<SupelierWuLiaoDetail> detailModel)
        {
            StringBuilder spliceSql = new StringBuilder();
            if (detailModel == null || detailModel.Count == 0)
                spliceSql.Append(" = ISNULL(NULL,b.ShangPinID)");
            else
            {
                if (detailModel.Count == 1)
                {
                    spliceSql.Append(" = ISNULL('" + detailModel[0].val + "',b.ShangPinID)");
                }
                else
                {
                    spliceSql.Append(" in ( ");
                    for (int i = 0; i < detailModel.Count; i++)
                    {
                        if (i == (detailModel.Count - 1))
                        {
                            spliceSql.AppendFormat($"'{detailModel[i].val}'");
                            break;
                        }
                        spliceSql.AppendFormat($"'{detailModel[i].val}',");
                    }
                    spliceSql.Append(" ) ");
                }
            }
            var jsonResult = ServiceContent<MK_Info_Supplier>.Query(model, "DataDictionary", "QueryInfoSupplier", spliceSql.ToString(), true);
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult GetQueryTypeWuLiuYeWu(MK_Type_WuLiuYeWu model)
        {
            var jsonResult = ServiceContent<MK_Type_WuLiuYeWu>.Query(model, "DataDictionary", "QueryTypeWuLiuYeWu", true);
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult GetQueryInfoCurrency(MK_Info_Currency model)
        {
            var jsonResult = ServiceContent<MK_Info_Currency>.Query(model, "DataDictionary", "QueryInfoCurrency", true);
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult GetQueryInfoWuLiuCompany(MK_Info_WuLiuCompany model)
        {
            var jsonResult = ServiceContent<MK_Info_WuLiuCompany>.Query(model, "DataDictionary", "QueryInfoWuLiuCompany", true);
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

        public JsonResult GetImageResult(string imgVirtualPath)
        {
            string src = ConfigHelper.AppSetting("WebSitePath") + imgVirtualPath.Replace("~","").Replace(@"\","/");
            string imgName = src.Substring(src.LastIndexOf('/')+1, src.Length - src.LastIndexOf('/') -1);
            List<data> data = new List<data>();
            data.Add(new data { alt = imgName, pid = 0, src = src, thumb = "" });
            return Json(LayuiPhotosResultModel.CreateResult("物料图片查看", 0, 0, data),JsonRequestBehavior.AllowGet);
        }
    }
}