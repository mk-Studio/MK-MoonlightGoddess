using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers.Approved
{
    public class ApprovalsController : Controller
    {
        // GET: Approvals
        
        // 发起审批
        public ActionResult InitiateApprovals()
        {
            return View("../Approvals/InitiateApprovals");
        }

        // 待我审批的
        public ActionResult WaitingMyApprovals()
        {
            return View("../Approvals/WaitingMyApprovals");
        }

        // 我已审批的
        public ActionResult IHaveApprovals()
        {
            return View("../Approvals/IHaveApprovals");
        }

        // 我发起的
        public ActionResult MyInitiateApprovals()
        {
            return View("../Approvals/MyInitiateApprovals");
        }

        // 抄送我的
        public ActionResult CCMyApprovals()
        {
            return View("../Approvals/CCMyApprovals");
        }
    }
}