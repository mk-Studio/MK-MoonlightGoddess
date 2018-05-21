using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models
{
    public class BaseModel
    {
        /// <summary>
        /// layui 分页数
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// layui 显示行数
        /// </summary>
        public int limit { get; set; }
    }
}
