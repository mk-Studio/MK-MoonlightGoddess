using MK.MoonlightGoddess.Core;
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
    public class AuthorityController : Controller
    {
        // GET: Authority
        public ActionResult Index()
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
        public JsonResult UpdateStatus(MK_Info_PowerAllot model)
        {
            var BoolResult = ServiceContent<MK_Info_PowerAllot>.SelectSIDU(model, "MK_Info_PowerAllot", "UpdateStatus");
            if (BoolResult == true)
            {
                return Json(new { result = "Y" });
            }
            else
            {
                return Json(new { result = "N" });
            }

        }
    }
}