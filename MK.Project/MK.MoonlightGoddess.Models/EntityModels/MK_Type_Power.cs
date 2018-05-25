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
        /// 菜单名称
        /// </summary>
        public string PowerName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; }
    }
}
