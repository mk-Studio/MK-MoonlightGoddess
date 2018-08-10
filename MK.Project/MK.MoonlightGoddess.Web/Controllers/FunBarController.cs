using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers
{
    public class FunBarController : VerifyLoginController
    {
        public class FunsBar
        {
            public string FeaturesName { get; set; }
            public string DataType { get; set; }
        }
        // GET api/<controller>
        public JsonResult GetFuns(string powerID)
        {
            var jsonResult = ServiceContent<dynamic>.SelectData(new { PowerID = powerID,CurrAccount.UserName }, "VerifyFunsBar", "VerifyFunsBar");
            return Json(ConvertHelper.TableToList<FunsBar>(jsonResult),JsonRequestBehavior.AllowGet);
        }
    }
}