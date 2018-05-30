using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.ResultModels
{
    public class LayuiUploadResultModel
    {
        public int code { get; set; }
        public string msg { get; set; }
        public object data { get; set; }

        private LayuiUploadResultModel(int code,string msg,object data)
        {
            this.code = code;
            this.msg = msg;
            this.data = data;
        }

        public static Object CreateResult(int code, string msg, object data)
        {
            return new LayuiUploadResultModel(code, msg, data);
        }
    }
}
