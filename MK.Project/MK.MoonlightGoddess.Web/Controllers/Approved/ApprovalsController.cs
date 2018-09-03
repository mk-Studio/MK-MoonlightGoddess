using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Models.EntityModels;
using MK.MoonlightGoddess.Models.ResultModels;
using MK.MoonlightGoddess.Models.SerializableModels;
using MK.MoonlightGoddess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers.Approved
{
    public class ApprovalsController : VerifyLoginController
    {
        // GET: Approvals

        #region ViewPage
        // 发起审批
        public ActionResult InitiateApprovals()
        {
            return View();
        }

        // 待我审批的
        public ActionResult WaitingMyApprovals()
        {
            return View();
        }

        // 我已审批的
        public ActionResult IHaveApprovals()
        {
            return View();
        }

        // 我发起的
        public ActionResult MyInitiateApprovals()
        {
            return View();
        }

        // 抄送我的
        public ActionResult CCMyApprovals()
        {
            return View();
        }

        // 审批申请页面
        public ActionResult FormApprovals(string id)
        {
            ViewBag.ApprovalsTypeID = id;

            ViewBag.Template = ServiceContent<MK_Type_ApprovedTemplate>.AjaxSingleModel(
                new MK_Type_ApprovedTemplate() { ApprovedTypeID = id }, "MK_Info_Approve", "GetApprovalsTemplate");
            //ViewBag.ApprovalsorDataSet
            var _data = ServiceContent<ApprovalsorInfo>.SelectSingleModel(
               new ApprovalsorInfo() { UserName = CurrAccount.UserName}, "MK_Info_Approve", "GetApprovalsorInfo");
            _data.CCInfo = _data.CCInfo.TrimEnd(';');
            _data.ApproveInfo = _data.ApproveInfo.TrimEnd(';');
            ViewBag.ApprovalsorInfo = _data;
            return View("../Approvals/Form/FormApprovals");
        }

        public ActionResult FormApprovalsResult()
        {
            return View("../Approvals/Form/FormApprovalsResult");
        }

        public ActionResult GetApprovedTaskDetail(string id)
        {
            return View("../Approvals/ApprovedTaskDetail");
        }

        public ActionResult GetApprovedTaskImages(string id)
        {
            return View("../Approvals/ApprovedTaskImages");
        }

        #endregion

        #region Action

        // GET: /Approvals/GetApprovalsColla
        public JsonResult GetApprovalsColla()
        {
            var data = ServiceContent<dynamic>.SelectData(new {}, "MK_Info_Approve", "GetApprovalsColla");
            var result = ApprovalsCollaResultModel.GetApprovalsGroups(data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: /Approvals/GetQueryMyInitiate
        public JsonResult GetQueryMyInitiate(MK_Info_ApprovedTask model)
        {
            model.CreateUser = CurrAccount.UserName;
            var data = ServiceContent<MK_Info_ApprovedTask>.Query(model, "MK_Info_Approve", "GetQueryMyInitiate",true);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: /Approvals/GetQueryWaitingMyApprovals
        public JsonResult GetQueryWaitingMyApprovals(MK_Info_ApprovedTask model)
        {
            model.ApproveorID = CurrAccount.ID;
            var data = ServiceContent<MK_Info_ApprovedTask>.Query(model, "MK_Info_Approve", "GetQueryWaitingMyApprovals", true);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: /Approvals/GetQueryMyApprovals
        public JsonResult GetQueryMyApprovals(MK_Info_ApprovedTask model)
        {
            model.ApproveorID = CurrAccount.ID;
            var data = ServiceContent<MK_Info_ApprovedTask>.Query(model, "MK_Info_Approve", "GetQueryMyApprovals", true);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: /Approvals/GetQueryCCMyApprovals
        public JsonResult GetQueryCCMyApprovals(MK_Info_ApprovedTask model)
        {
            model.ID = CurrAccount.ID;
            var data = ServiceContent<MK_Info_ApprovedTask>.Query(model, "MK_Info_Approve", "GetQueryCCMyApprovals", true);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: /Approvals/GetQueryTaskDetail
        public JsonResult GetQueryTaskDetail(MK_Info_ApprovedTaskDetail model)
        {
            model.CreateUser = CurrAccount.UserName;
            var data = ServiceContent<MK_Info_ApprovedTaskDetail>.Select(model, "MK_Info_Approve", "GetQueryTaskDetail", true);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetApprovedImages(string taskId) 
        {
            var pathList = ConvertHelper.TableToList<MK_Info_ApprovedTaskImages>(
                ServiceContent<dynamic>.SelectData(new { ApprovedTaskID = taskId }, "MK_Info_Approve", "GetApprovedImages"));
            List<data> data = new List<data>();
            foreach (MK_Info_ApprovedTaskImages imgObj in pathList)
            {
                string src = ConfigHelper.AppSetting("WebSitePath") + imgObj.ImagesPath.Replace("~", "").Replace(@"\", "/");
                string imgName = src.Substring(src.LastIndexOf('/') + 1, src.Length - src.LastIndexOf('/') - 1);
                data.Add(new data { alt = imgObj.ID, pid = 0, src = src, thumb = "" });
            }
            return Json(LayuiPhotosResultModel.CreateResult("审批附件上传图", 0, 0, data), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SendApprove(ApprovalsSerializableModel formObject)
        {
            IApprovalsSerializableModelResult service = new ServiceApprovals("MK_Info_Approve", "SendApprove");
            var result = service.ExecuteResult(formObject, CurrAccount);
            return Json(result);
        }

        [HttpPost]
        public ActionResult UpdateApproveStatus(string id)
        {
            var data = ServiceContent<dynamic>.AjaxSIDU(new { ID = id }, "MK_Info_Approve", "UpdateApproveStatus");
            return Json(data);
        }

        [HttpPost]
        public ActionResult UpdateApprovalsResult(MK_Info_ApprovedTask model)
        {
            var data = ServiceContent<MK_Info_ApprovedTask>.AjaxSIDU(model, "MK_Info_Approve", "UpdateApprovalsResult",true);
            return Json(data);
        }
        
        [HttpPost]
        public ActionResult CancelApprovalsResult(string id)
        {
            var data = ServiceContent<dynamic>.AjaxSIDU(new { ID = id }, "MK_Info_Approve", "CancelApprovalsResult");
            return Json(data);
        }
        #endregion

        public class ApprovalsorInfo
        {
            public string Approve_ChangeMark { get; set; }
            public string CC_ChangeMark { get; set; }
            public string ApproveInfo { get; set; }
            public string CCInfo { get; set; }
            public string UserName { get; set; }
        }
    }
}