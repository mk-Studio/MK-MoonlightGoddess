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
        #endregion

        #region Action

        

        #endregion
    }
}