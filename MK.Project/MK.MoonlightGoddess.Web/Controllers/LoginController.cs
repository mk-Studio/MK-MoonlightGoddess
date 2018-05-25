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
            DataTable Userdt = new DataTable();
            Userdt = (DataTable)ServiceContent<MK_Info_User>.SelectSIDU(model, "MK_Info_User", "ValidateLogon");
            if (Userdt.Rows.Count==1)
            {
                foreach (DataColumn dc in Userdt.Columns)
                {
                    var cookiename = dc.ColumnName.ToString();
                    var cookivalue = Userdt.Rows[0][cookiename].ToString();
                    CookieHelper.SetCookie(cookiename,cookivalue);
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