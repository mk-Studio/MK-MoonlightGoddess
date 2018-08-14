using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.EntityModels
{
    public class MK_Type_Power:BaseModel
    {
        /// <summary>
        /// 导航ID
        /// </summary>
        public string NavigationID { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string PowerName { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public string MenuAddress { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; }
    }
}
