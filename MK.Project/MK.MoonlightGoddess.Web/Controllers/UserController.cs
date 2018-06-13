using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Models;
using MK.MoonlightGoddess.Models.EntityModels;
using MK.MoonlightGoddess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers
{
    public class UserController : VerifyLoginController
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserManage()
        {
            return View();
        }

        public ActionResult FormInfoUser()
        {
            return View("../User/Form/FormInfoUser");
        }

        public ActionResult QueryFormInfoUser()
        {
            return View("../User/QueryForm/QueryFormInfoUser");
        }

        public JsonResult GetUsersInfo(MK_Info_User model)
        {
            var jsonResult = ServiceContent<MK_Info_User>.Query( model,"MK_Info_User", "GetUsersInfo",true);
            return Json(jsonResult,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ExceInfoUser(MK_Info_User model,List<FormSelectes> approve, List<FormSelectes> cc, string commandName)
        {
            bool[] result = new bool[3] { false, false, false };
            model.ID = model.ID == "Insert" ? Guid.NewGuid().ToString().ToUpper() : model.ID;
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            result[0] = ServiceContent<MK_Info_User>.SelectSIDU(model, "MK_Info_User", commandName + "InfoUser");

            if (result[0])
            {
                MK_Info_Approve m_approve = new MK_Info_Approve()
                {
                    ID = Guid.NewGuid().ToString().ToUpper(),
                    UserID = model.ID,
                    ApproveID = approve[0].val,
                    ApproveName = approve[0].name,
                    CreateUser = CurrAccount.UserName,
                    CreateDate = model.CreateDate
                };
                result[1] = ServiceContent<MK_Info_Approve>.SelectSIDU(m_approve, "MK_Info_User", "InsertInfoApprove");
                List<MK_Info_CC> listCC = new List<MK_Info_CC>();
                foreach ( FormSelectes select in cc )
                {
                    MK_Info_CC m_CC = new MK_Info_CC() {
                        ID = Guid.NewGuid().ToString().ToUpper(),
                        UserID = model.ID,
                        CCID = select.val,
                        CCName = select.name,
                        CreateUser = CurrAccount.UserName,
                        CreateDate = model.CreateDate
                    };
                    listCC.Add(m_CC);
                }
                var CCTable = ConvertHelper.ListToTable(listCC, true, true);
                result[2] = ServiceContent<dynamic>.DataTableToSQLServer(CCTable, "MK_Info_CC");
            }
            var jsonResult = AjaxResultModel.CreateMessage(true, "error", -1, result);
            if ( result[0] && result[1] && result[2] )
                jsonResult = AjaxResultModel.CreateMessage(false, "ssuccess", 3, result);
            return Json(jsonResult);
        }

        public JsonResult UpdateMark(string ID, string Mark, string name)
        {
            var jsonResult = ServiceContent<dynamic>.AjaxSIDU(new {  ID, ShowMark = Mark, name }, "MK_Info_User", name);
            return Json(jsonResult);
        }

        public ActionResult SecuritySettings()
        {
            var jsonResult = ServiceContent<MK_Info_User>.SelectSingleModel
                (
                    new MK_Info_User() { UserName = CurrAccount.UserName },
                    "MK_Info_User",
                    "GetUserInfoByAccount"
                );
            ViewBag.UserName = jsonResult.UserName;
            ViewBag.NickName = jsonResult.NickName;
            return View();
        }

        public JsonResult GetUserInfo()
        {
            var jsonResult = ServiceContent<MK_Info_User>.AjaxSingleModel
                (
                    new MK_Info_User() { UserName = CurrAccount.UserName },
                    "MK_Info_User",
                    "GetUserInfoByAccount"
                );
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveSecuritySettings(MK_Info_User model)
        {
            model.Password = EncryptHelper.GetMD5_16(model.Password);
            var jsonResult = ServiceContent<MK_Info_User>.AjaxSIDU(model, "MK_Info_User", "SaveSecuritySettings");
            return Json(jsonResult);
        }

        public JsonResult GetCCInfo(string userID)
        {
            var _dataSoruce = ServiceContent<dynamic>.SelectData(new { UserID = userID }, "MK_Info_User", "GetCCIDByUserID");
            List<String> result = new List<String>();
            foreach ( System.Data.DataRow row in _dataSoruce.Rows )
                result.Add(row["CCID"].ToString());
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetApproveInfo(string userID)
        {
            var _dataSoruce = ServiceContent<dynamic>.SelectData(new { UserID = userID }, "MK_Info_User", "GetApproveIDByUserID");
            List<String> result = new List<String>();
            foreach ( System.Data.DataRow row in _dataSoruce.Rows )
                result.Add(row["ApproveID"].ToString());
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}