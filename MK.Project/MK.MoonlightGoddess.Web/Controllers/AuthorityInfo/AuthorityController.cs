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

namespace MK.MoonlightGoddess.Web.Controllers.AuthorityInfo
{
    public class AuthorityController : VerifyLoginController
    {
        // GET: Authority
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Grouping()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Select(MK_Type_Power model)
        {
            var jsonResult = ServiceContent<MK_Type_Power>.Select(model, "MK_Info_Authority", "SelectAuthority");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult SelectPowerGroup(MK_Type_Power model)
        {
            var jsonTable = ServiceContent<MK_Type_Power>.SelectData(model, "MK_Info_PowerGroup", "SelectPowerGroupTree");
            TextTree textTree = new TextTree();
            var jsonResult = textTree.PowerGroup(jsonTable);
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult SelectPowerAllot(MK_Info_PowerAllot model)
        {
            var jsonResult = ServiceContent<MK_Info_PowerAllot>.Select(model, "MK_Info_PowerAllot", "SelectPowerAllot");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult UpdateStatus(MK_Info_PowerAllot model,string Status)
        {
            model.Status = Status;
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            List<MK_Info_PowerAllot> listSp = new List<MK_Info_PowerAllot>();
            MK_Info_PowerAllot newObj = new MK_Info_PowerAllot()
            {
                ID= Guid.NewGuid().ToString().ToUpper(),
                Status = Status,
                CreateUser= CurrAccount.UserName,
                CreateDate= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            listSp.Add(newObj);
            var BoolResult = ServiceContent<MK_Info_PowerAllot>.SelectSIDU(model, "MK_Info_PowerAllot", "UpdateStatus");
            return BoolResult? Json(AjaxResultModel.CreateMessage((!BoolResult), "ssuccess", 1, BoolResult))
                    : Json(AjaxResultModel.CreateMessage((!BoolResult), "error", -1, BoolResult));
        }

        [HttpPost]
        public JsonResult UpdateAllStatus(MK_Info_PowerAllot model)
        {
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            List<MK_Info_PowerAllot> listSp = new List<MK_Info_PowerAllot>();
            MK_Info_PowerAllot newObj = new MK_Info_PowerAllot()
            {
                PowerGroupID = Guid.NewGuid().ToString().ToUpper(),
                CreateUser = CurrAccount.UserName,
                CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            listSp.Add(newObj);
            var BoolResult = ServiceContent<MK_Info_PowerAllot>.SelectSIDU(model, "MK_Info_PowerAllot", "UpdateAllStatus");
            return BoolResult ? Json(AjaxResultModel.CreateMessage((!BoolResult), "ssuccess", 1, BoolResult))
                    : Json(AjaxResultModel.CreateMessage((!BoolResult), "error", -1, BoolResult));
        }

        [HttpPost]
        public JsonResult SelectAccredit(MK_Info_PowerAllot model) {
            var jsonResult = ServiceContent<MK_Info_PowerAllot>.Select(model, "MK_Info_PowerAllot", "SelectAccredit");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult InsertGroupInfo(MK_Info_PowerGroup model)
        {
            model.CreateUser = CurrAccount.UserName;
            var  jsonResult = ServiceContent<MK_Info_PowerGroup>.SelectData(model, "MK_Info_PowerGroup","InsertGroupInfo");
            return Json(new
            {
                result = jsonResult.Rows[0]["Result"].ToString().Trim(),
                number = jsonResult.Rows[0]["Number"].ToString().Trim()
            });
        }

        [HttpPost]
        public JsonResult DelGroupInfo(MK_Info_PowerGroup model)
        {
            model.CreateUser = CurrAccount.UserName;
            var jsonResult = ServiceContent<MK_Info_PowerGroup>.SelectData(model, "MK_Info_PowerGroup", "PR_DeleInfo_PowerAllot_Uers");
            return Json(new
            {
                result = jsonResult.Rows[0]["Result"].ToString().Trim(),
                number = jsonResult.Rows[0]["Number"].ToString().Trim()
            });
        }
        [HttpPost]
        public JsonResult EditGroupInfo(MK_Info_PowerGroup model)
        {
            var selectGroupRowCount = ServiceContent<MK_Info_PowerGroup>.SelectData(model,"MK_Info_PowerGroup","selectGroupNameRow");
            int number = (int)selectGroupRowCount.Rows[0]["Number"];
            if (number > 0)
            {
                return Json(new
                {
                    result = "组名[" + model.PowerGroupName + "]已存在",
                    bl = false
                });
            }
            else
            {
                model.CreateUser = CurrAccount.UserName;
                var jsonResult = ServiceContent<MK_Info_PowerGroup>.SelectSIDU(model, "MK_Info_PowerGroup", "UpdateGroupInfo");
                if (jsonResult == true)
                    return Json(new { result = "修改成功", bl = true });
                else
                    return Json(new { result = "修改失败", bl = false });
            }
           
        }
    }
}