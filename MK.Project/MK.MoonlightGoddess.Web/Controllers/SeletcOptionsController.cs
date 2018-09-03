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

        /// <summary>
        /// 根据名称获取下拉框数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IHttpActionResult GetSelectOptions(string name, string p1)
        {
            HttpContext context = HttpContext.Current;
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            var jsonResult = ServiceContent<dynamic>.GetSelectOptionsBySqlName(new { p1}, name);
            return Json(jsonResult);
        }

        /// <summary>
        /// 根据名称获取下拉框数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IHttpActionResult GetSelectOptions(string name, string p1, string p2)
        {
            HttpContext context = HttpContext.Current;
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            var jsonResult = ServiceContent<dynamic>.GetSelectOptionsBySqlName(new { p1, p2 }, name);
            return Json(jsonResult);
        }

        /// <summary>
        /// 根据名称获取下拉框数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IHttpActionResult GetSelectOptions(string name, string p1, string p2, string p3)
        {
            HttpContext context = HttpContext.Current;
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            var jsonResult = ServiceContent<dynamic>.GetSelectOptionsBySqlName(new { p1, p2, p3}, name);
            return Json(jsonResult);
        }

        /// <summary>
        /// 根据名称获取下拉框数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IHttpActionResult GetSelectOptions(string name, string p1, string p2, string p3, string p4)
        {
            HttpContext context = HttpContext.Current;
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            var jsonResult = ServiceContent<dynamic>.GetSelectOptionsBySqlName(new { p1, p2, p3, p4 }, name);
            return Json(jsonResult);
        }

        /// <summary>
        /// 根据名称获取下拉框数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IHttpActionResult GetSelectOptions(string name, string p1, string p2, string p3, string p4, string p5)
        {
            HttpContext context = HttpContext.Current;
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            var jsonResult = ServiceContent<dynamic>.GetSelectOptionsBySqlName(new { p1, p2, p3, p4, p5 }, name);
            return Json(jsonResult);
        }

        /// <summary>
        /// 根据名称获取下拉框数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IHttpActionResult GetSelectOptions(string name, string p1, string p2, string p3, string p4, string p5, string p6)
        {
            HttpContext context = HttpContext.Current;
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            var jsonResult = ServiceContent<dynamic>.GetSelectOptionsBySqlName(new { p1, p2, p3, p4, p5, p6}, name);
            return Json(jsonResult);
        }

        /// <summary>
        /// 根据名称获取下拉框数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IHttpActionResult GetSelectOptions(string name, string p1, string p2, string p3, string p4, string p5, string p6,string p7)
        {
            HttpContext context = HttpContext.Current;
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            var jsonResult = ServiceContent<dynamic>.GetSelectOptionsBySqlName(new { p1, p2, p3, p4, p5, p6, p7 }, name);
            return Json(jsonResult);
        }

        /// <summary>
        /// 根据名称获取下拉框数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IHttpActionResult GetSelectOptions(string name, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8)
        {
            HttpContext context = HttpContext.Current;
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            var jsonResult = ServiceContent<dynamic>.GetSelectOptionsBySqlName(new { p1,p2,p3,p4,p5,p6,p7,p8}, name);
            return Json(jsonResult);
        }

    }
}