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
    public class VerifyDbDataController : ApiController
    {
        public class VerifyRequestParams
        {
            /// <summary>
            /// 校准ID
            /// </summary>
            public string ID { get; set; }

            /// <summary>
            /// find sqlcmd by sql name 
            /// </summary>
            public string SqlName { get; set; }

            /// <summary>
            /// 物料类型名称
            /// </summary>
            public string WuLiaoTypeName { get; set; }

            /// <summary>
            /// 物料商品名称
            /// </summary>
            public string ShangPinName { get; set; }

            /// <summary>
            /// 物料商品规格
            /// </summary>
            public string GuiGe { get; set; }

            /// <summary>
            /// 业务类型名称
            /// </summary>
            public string YeWuType { get; set; }

            /// <summary>
            /// 物料公司名称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 用户名称
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// 供应商名称
            /// </summary>
            public string SupplierName { get; set; }

            /// <summary>
            /// 币别名称
            /// </summary>
            public string CurrencyName { get; set; }

            /// <summary>
            /// 币别代码
            /// </summary>
            public string CurrencyCode { get; set; }

            
        }
        //Verify
        [HttpPost]
        public IHttpActionResult VerifyExists(VerifyRequestParams model)
        {
            HttpContext context = HttpContext.Current;
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            var _data = ServiceContent<dynamic>.SelectSingle(model, "VerifyDbData", model.SqlName);
            var jsonResult = _data == "OK"
                ? AjaxResultModel.CreateMessage(false, "NOT EXISTS", 0, _data)
                : AjaxResultModel.CreateMessage(false, "EXISTS", 1, _data);
            return Json(jsonResult);
        }
    }
}
