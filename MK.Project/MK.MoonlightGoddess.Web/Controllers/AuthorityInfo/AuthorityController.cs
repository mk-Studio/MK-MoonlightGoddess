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
        public ActionResult MenuManagement()
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
        public JsonResult UpdateStatus(MK_Info_PowerAllot model, string Status)
        {
            model.Status = Status;
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            List<MK_Info_PowerAllot> listSp = new List<MK_Info_PowerAllot>();
            MK_Info_PowerAllot newObj = new MK_Info_PowerAllot()
            {
                ID = Guid.NewGuid().ToString().ToUpper(),
                Status = Status,
                CreateUser = CurrAccount.UserName,
                CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            listSp.Add(newObj);
            var BoolResult = ServiceContent<MK_Info_PowerAllot>.SelectSIDU(model, "MK_Info_PowerAllot", "UpdateStatus");
            return BoolResult ? Json(AjaxResultModel.CreateMessage((!BoolResult), "ssuccess", 1, BoolResult))
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
        public JsonResult SelectAccredit(MK_Info_PowerAllot model)
        {
            var jsonResult = ServiceContent<MK_Info_PowerAllot>.Select(model, "MK_Info_PowerAllot", "SelectAccredit");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult InsertGroupInfo(MK_Info_PowerGroup model)
        {
            model.CreateUser = CurrAccount.UserName;
            var jsonResult = ServiceContent<MK_Info_PowerGroup>.SelectData(model, "MK_Info_PowerGroup", "InsertGroupInfo");
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
            var selectGroupRowCount = ServiceContent<MK_Info_PowerGroup>.SelectData(model, "MK_Info_PowerGroup", "selectGroupNameRow");
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
        [HttpPost]
        public JsonResult SelectFunctionList(MK_Type_FunctionList model)
        {
            var jsonResult = ServiceContent<MK_Type_FunctionList>.Select(model, "MK_Type_FunctionList", "SelectFunctionList");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult UpdateFunctionListStatus(MK_Type_FunctionList model)
        {
            model.CreateUser = CurrAccount.UserName;
            var jsonResult = ServiceContent<MK_Type_FunctionList>.AjaxSIDU(model, "MK_Type_FunctionList", "UpdateFunctionListStatus");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult SelectNavigation(MK_Info_Navigationbar model)
        {
            var jsonTable = ServiceContent<MK_Info_Navigationbar>.SelectData(model, "MK_Info_Navigationbar", "SelectNavigation");
            NavigationbarTree textTree = new NavigationbarTree();
            var jsonResult = textTree.Navigation(jsonTable);
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult SelectPower(MK_Type_Power model)
        {
            var jsonResult = ServiceContent<MK_Type_Power>.Select(model, "MK_Type_Power", "SelectPower");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult QueryNavigation(MK_Info_Navigationbar model)
        {
            var jsonResult = ServiceContent<MK_Info_Navigationbar>.Query(model, "MK_Info_Navigationbar", "QueryNavigation");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult InsertPower(MK_Type_Power model)
        {
            model.CreateUser = CurrAccount.UserName;
            var jsonResult = ServiceContent<MK_Type_Power>.SelectData(model, "MK_Type_Power", "InsertPower");
            return Json(new
            {
                result = jsonResult.Rows[0]["Result"].ToString().Trim(),
                number = jsonResult.Rows[0]["Number"].ToString().Trim()
            });
        }

        [HttpPost]
        public JsonResult UpdatePower(MK_Type_Power model)
        {
            model.CreateUser = CurrAccount.UserName;
            var jsonResult = ServiceContent<MK_Type_Power>.SelectData(model, "MK_Type_Power", "UpdatePower");
            return Json(new
            {
                result = jsonResult.Rows[0]["Result"].ToString().Trim(),
                number = jsonResult.Rows[0]["Number"].ToString().Trim()
            });
        }

        [HttpPost]
        public JsonResult DelPower(MK_Type_Power model)
        {
            model.CreateUser = CurrAccount.UserName;
            var jsonResult = ServiceContent<MK_Type_Power>.SelectData(model, "MK_Type_Power", "DelPower");
            return Json(new
            {
                result = jsonResult.Rows[0]["Result"].ToString().Trim(),
                number = jsonResult.Rows[0]["Number"].ToString().Trim()
            });
        }

        [HttpPost]
        public JsonResult SelectFeatures(MK_Info_Features model)
        {
            var jsonResult = ServiceContent<MK_Info_Features>.Select(model, "MK_Info_Features", "SelectFeatures");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult InsertFunction(MK_Info_Features model)
        {
            model.CreateUser = CurrAccount.UserName;
            var jsonResult = ServiceContent<MK_Info_Features>.SelectData(model, "MK_Info_Features", "InsertFunction");
            return Json(new
            {
                result = jsonResult.Rows[0]["Result"].ToString().Trim(),
                number = jsonResult.Rows[0]["Number"].ToString().Trim()
            });
        }

        [HttpPost]
        public JsonResult VerificationFeaturesName(MK_Info_Features model)
        {
            model.CreateUser = CurrAccount.UserName;
            var jsonResult = ServiceContent<MK_Info_Features>.SelectData(model, "MK_Info_Features", "VerificationFeaturesName");
            return Json(new { number = Convert.ToInt32(jsonResult.Rows[0]["Number"].ToString().Trim()) });
        }

        [HttpPost]
        public JsonResult Updateunction(MK_Info_Features model)
        {
            model.CreateUser = CurrAccount.UserName;
            var jsonResult = ServiceContent<MK_Info_Features>.AjaxSIDU(model, "MK_Info_Features", "Updateunction");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult DelFunction(MK_Info_Features model)
        {
            model.CreateUser = CurrAccount.UserName;
            var jsonResult = ServiceContent<MK_Info_Features>.SelectData(model, "MK_Info_Features", "DelFunction");
            return Json(new
            {
                result = jsonResult.Rows[0]["Result"].ToString().Trim(),
                number = jsonResult.Rows[0]["Number"].ToString().Trim()
            });
        }


        /**/
        public JsonResult UpdateShowMark(string ID, string ShowMark, string name)
        {
            var jsonResult = ServiceContent<dynamic>.AjaxSIDU(new { ID, ShowMark, name }, "MK_Info_Navigationbar", name);
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult AddNavigationInfo(MK_Info_Navigationbar model)
        {
            model.CreateUser = CurrAccount.UserName;
            var jsonResult = ServiceContent<MK_Info_Navigationbar>.AjaxSIDU(model, "MK_Info_Navigationbar", "AddNavigationInfo");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult UpdateNavigationInfo(MK_Info_Navigationbar model)
        {
            model.CreateUser = CurrAccount.UserName;
            var jsonResult = ServiceContent<MK_Info_Navigationbar>.AjaxSIDU(model, "MK_Info_Navigationbar", "UpdateNavigationInfo");
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult DelNavigation(string ID)
        {
            var jsonResult = ServiceContent<dynamic>.AjaxSingle(new { ID}, "MK_Info_Navigationbar", "DelNavigation");
            return Json(jsonResult);
        }
    }
}