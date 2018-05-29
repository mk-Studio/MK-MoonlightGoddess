using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.EntityModels
{
    public class MK_Info_PowerAllot:BaseModel
    {
        /// <summary>
        /// 权限组ID
        /// </summary>
        public string PowerGroupID { get; set; }

        /// <summary>
        /// 权限ID（菜单ID）
        /// </summary>
        public string PowerID { get; set; }

        /// <summary>
        /// 权限标识
        /// </summary>
        public string Status_xx { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string PowerName { get; set; }

        /// <summary>
        /// 菜单备注
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public string MenuAddress { get; set; }
    }
}
