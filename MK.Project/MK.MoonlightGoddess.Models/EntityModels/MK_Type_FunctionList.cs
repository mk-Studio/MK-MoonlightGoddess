using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.EntityModels
{
    public class MK_Type_FunctionList : BaseModel
    {
        /// <summary>
        /// 菜单功能ID 
        /// </summary>
        public string FeaturesID { get; set; }

        /// <summary>
        /// 权限分配ID
        /// </summary>
        public string PowerAllotID { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        public string FeaturesName { get; set; }

        /// <summary>
        /// 权限标识:0-无权限，1-有权限
        /// </summary>
        public string Status { get; set; }
    }
}
