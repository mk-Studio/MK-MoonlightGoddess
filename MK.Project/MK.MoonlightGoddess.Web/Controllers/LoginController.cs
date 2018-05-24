using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Models.EntityModels;
using MK.MoonlightGoddess.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult OnLogin(MK_Info_User model)
        {
            var jsonResult = ServiceContent<MK_Info_User>.SelectSingle(model, "MK_Info_User", "ValidateLogon");
            if (!string.IsNullOrEmpty(jsonResult))
            {
                DataTable Userdt = new DataTable();
                Userdt = (DataTable)ServiceContent<MK_Info_User>.SelectSIDU(model, "MK_Info_User", "ValidateLogon");
                foreach (DataColumn dr in Userdt.Columns)
                {
                    string ColumnsTitle = dr.ToString();
                    string strValue = EncryptHelper.GetMD5_32(Userdt.Rows[0][ColumnsTitle].ToString());
                    SessionHelper.SetSession(ColumnsTitle, strValue);
                }
                return Json(new { result = "Y" });
            }
            else
            {
                return Json(new { result = "N" });
            }
        }
    }
}