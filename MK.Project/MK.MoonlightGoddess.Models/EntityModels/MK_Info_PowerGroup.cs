using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.EntityModels
{
    public class MK_Info_PowerGroup:BaseModel
    {
        /// <summary>
        /// 上级节点
        /// </summary>
        public string OnID { get; set; }

        /// <summary>
        /// 权限组名
        /// </summary>
        public string PowerGroupName { get; set; }
    }
}
