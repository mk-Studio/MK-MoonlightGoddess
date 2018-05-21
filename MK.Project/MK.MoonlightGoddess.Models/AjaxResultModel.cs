using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models
{
    /// <summary>
    /// 返回结果
    /// </summary>
    public class AjaxResultModel
    {
        public bool IsError { get; set; }
        public string Msg { get; set; }
        public string Code { get; set; }
        public object Data { get; set; }
    }
}
