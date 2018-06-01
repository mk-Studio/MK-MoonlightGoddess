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
    [Serializable]
    public class AjaxResultModel
    {
        public bool IsError { get; set; }
        public string Msg { get; set; }
        public int Code { get; set; }
        public object Data { get; set; }

        public AjaxResultModel() { }
        private AjaxResultModel(bool IsError, string Msg, int Code, object Data)
        {
            this.IsError = IsError;
            this.Msg = Msg;
            this.Code = Code;
            this.Data = Data;
        }

        public static Object CreateMessage(bool isError, string msg, int code, object data)
        {
            AjaxResultModel result = new AjaxResultModel(isError, msg, code, data);
            return result;
        }
    }
}
