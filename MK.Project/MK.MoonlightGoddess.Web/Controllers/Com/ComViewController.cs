using MK.MoonlightGoddess.Models.EntityModels;
using MK.MoonlightGoddess.Models.ResultModels;
using MK.MoonlightGoddess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers.Com
{
    public class ComViewController : VerifyLoginController
    {
        // GET: /ComView/SelectedUserInfo
        public ActionResult SelectedUserInfo()
        {
            return View("../ComView/SelectedUserInfo");
        }

        // GET: /ComView/QuerySelectedUser
        public ActionResult SelectedIcon()
        {
            return View("../ComView/SelectedIcon");
        }

        public JsonResult GetLikeQueryUser(MK_Info_User model)
        {
            var jsonResult = ServiceContent<MK_Info_User>.Select(model, "ComView", "GetLikeQueryUser", true);
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserGroup()
        {
            var jsonTable = ServiceContent<dynamic>.SelectData(new { }, "ComView", "GetUserGroup");
            TextTree textTree = new TextTree();
            var jsonResult = textTree.PowerGroupChildNode(jsonTable);
            return Json(jsonResult);
        }
    }
}