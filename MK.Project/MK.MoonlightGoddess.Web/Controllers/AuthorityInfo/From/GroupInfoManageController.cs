using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers.AuthorityInfo.From
{
    public class GroupInfoManageController : Controller
    {
        // GET: GroupInfoManage
        public ActionResult AddGroupInfo()
        {
            return View("../Authority/Form/FromAddGroupInfo");
        }
        public ActionResult EditGroupInfo()
        {
            return View("../Authority/Form/FormEditGroupInfo");
        }
    }
}