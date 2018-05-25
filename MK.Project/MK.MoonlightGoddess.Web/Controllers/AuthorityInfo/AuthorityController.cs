﻿using MK.MoonlightGoddess.Core;
using MK.MoonlightGoddess.Models.EntityModels;
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
    }
}