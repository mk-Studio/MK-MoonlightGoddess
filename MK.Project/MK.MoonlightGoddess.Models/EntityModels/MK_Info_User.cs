using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.EntityModels
{
    public class MK_Info_User:BaseModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Passwor { get; set; }

        /// <summary>
        /// 物流公司业务维护ID
        /// </summary>
        public string WuLiuYeWuID { get; set; }

        /// <summary>
        /// 权限组ID
        /// </summary>
        public string PowerGroupID { get; set; }
    }
}
