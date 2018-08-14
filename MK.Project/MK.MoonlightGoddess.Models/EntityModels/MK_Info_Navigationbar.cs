using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.EntityModels
{
    public class MK_Info_Navigationbar:BaseModel
    {
        /// <summary>
        /// 导航名称
        /// </summary>
        public string NavigationName { get; set; }

        /// <summary>
        /// 提示
        /// </summary>
        public string Tips { get; set; }
        
        /// <summary>
        /// 排序字段
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 导航级
        /// </summary>
        public string Directio { get; set; }
    }
}
