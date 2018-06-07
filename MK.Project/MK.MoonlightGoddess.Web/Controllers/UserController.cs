using MK.MoonlightGoddess.Core;
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
        public JsonResult ExceInfoUser(MK_Info_User model, string commandName)
        {
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var jsonResult = ServiceContent<MK_Info_User>.AjaxSIDU(model, "MK_Info_User", commandName + "InfoUser");
            return Json(jsonResult);
        }

        public JsonResult UpdateShowMark(string ID, string ShowMark, string name)
        {
            var jsonResult = ServiceContent<dynamic>.AjaxSIDU(new {  ID, ShowMark, name }, "MK_Info_User", name);
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
    }
}