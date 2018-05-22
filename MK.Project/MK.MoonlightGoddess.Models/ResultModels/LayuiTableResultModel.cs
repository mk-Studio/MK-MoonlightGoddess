using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models
{
    /// <summary>
    /// layui table 填充数据格式（默认带分页）
    /// </summary>
    public class LayuiTableResultModel
    {
        /// <summary>
        /// 状态码 
        /// 0：成功，否则请求失败
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 附加消息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 数据总行数
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 填充的数据
        /// </summary>
        public object data { get; set; }
    }
}
