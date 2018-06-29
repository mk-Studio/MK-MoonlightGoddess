using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.EntityModels
{
    public class MK_Info_Features : BaseModel
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public string PowerID { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        public string FeaturesName { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }
    }
}
