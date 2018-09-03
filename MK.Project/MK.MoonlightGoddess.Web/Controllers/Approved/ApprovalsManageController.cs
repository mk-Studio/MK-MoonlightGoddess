using MK.MoonlightGoddess.Models.EntityModels;
using MK.MoonlightGoddess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers.Approved
{
    public class ApprovalsManageController : VerifyLoginController
    {
        // GET: ApprovalsManage
        #region ViewPage
        // 审批管理（审批申请模板）
        public ActionResult ApprovedManage()
        {
            return View("../Approvals/ApprovedManage");
        }

        public ActionResult FormApprovedGroup()
        {
            return View("../Approvals/Form/FormApprovedGroup");
        }

        public ActionResult FormApprovedType()
        {
            return View("../Approvals/Form/FormApprovedType");
        }

        public ActionResult FormApprovedTemplate()
        {
            return View("../Approvals/Form/FormApprovedTemplate");
        }
        
        #endregion


        #region Action

        public JsonResult GetQueryGroup(MK_Type_ApprovedGroup model)
        {
            var jsonResult = ServiceContent<MK_Type_ApprovedGroup>.Select(model, "MK_ApprovedManage", "GetQueryGroup");
            return Json(jsonResult,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetQueryType(MK_Type_ApprovedType model)
        {
            var jsonResult = ServiceContent<MK_Type_ApprovedType>.Query(model, "MK_ApprovedManage", "GetQueryType");
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetQueryTemplate(MK_Type_ApprovedTemplate model)
        {
            var jsonResult = ServiceContent<MK_Type_ApprovedTemplate>.Query(model, "MK_ApprovedManage", "GetQueryTemplate");
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        //

        [HttpPost]
        public JsonResult ExecuteCommand(MK_Type_ApprovedTemplate model, string name)
        {
            model.CreateUser = CurrAccount.UserName;
            model.CreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var jsonResult = ServiceContent<MK_Type_ApprovedTemplate>.AjaxSingle(model, "MK_ApprovedManage", name);
            return Json(jsonResult);
        }

        #endregion

    }
}