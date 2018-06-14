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
        public string Password { get; set; }

        /// <summary>
        /// 物流公司业务维护ID
        /// </summary>
        public string WuLiuYeWuID { get; set; }

        /// <summary>
        /// 权限组ID
        /// </summary>
        public string PowerGroupID { get; set; }

        /// <summary>
        /// 权限组名称
        /// </summary>
        public string PowerGroupName { get; set; }

        /// <summary>
        /// 业务类型名称
        /// </summary>
        public string YeWuType { get; set; }

        /// <summary>
        /// 默认语言
        /// </summary>
        public string DefaultLanguage { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 性别 [0 => 男；1 => 女]
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 审批人可更改标识，Y=可更改，N=不可更改
        /// </summary>
        public string Approve_ChangeMark { get; set; }

        /// <summary>
        /// 抄送人可更改标识，Y=可更改，N=不可更改
        /// </summary>
        public string CC_ChangeMark { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        public string ApproveName { get; set; }

        /// <summary>
        /// 抄送人
        /// </summary>
        public string CCName { get; set; }
        
    }

    /// <summary>
    /// 与用户绑定的审批人信息
    /// </summary>
    public class MK_Info_Approve : BaseModel
    {
        public string UserID { get; set; }
        public string ApproveID { get; set; }
        public string ApproveName { get; set; }
    }

    /// <summary>
    /// 与用户绑定的抄送人信息
    /// </summary>
    public class MK_Info_CC : BaseModel
    {
        public string UserID { get; set; }
        public string CCID { get; set; }
        public string CCName { get; set; }
    }
}
