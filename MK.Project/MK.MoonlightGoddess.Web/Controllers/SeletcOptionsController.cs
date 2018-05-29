using MK.MoonlightGoddess.Models;
using MK.MoonlightGoddess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MK.MoonlightGoddess.Web.Controllers
{
    public class SeletcOptionsController : ApiController
    {
        // GET api/<controller>
        
        /// <summary>
        /// 根据名称获取下拉框数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IHttpActionResult GetSelectOptions(string name)
        {
            HttpContext context = HttpContext.Current;
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            var jsonResult = ServiceContent<dynamic>.GetSelectOptionsBySqlName(new { }, name);
            return Json(jsonResult);
        }

    }
}