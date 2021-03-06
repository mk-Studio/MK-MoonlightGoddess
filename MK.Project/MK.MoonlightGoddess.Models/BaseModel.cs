﻿using MK.MoonlightGoddess.Core;
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
        /// 唯一ID(GUID)
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 显示标识
        /// </summary>
        public string ShowMark { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateDate
        {
            get { return FormatDate.ToString("yyyy-MM-dd HH:mm:ss"); }
            set { FormatDate = Convert.ToDateTime(value); }
        }

        private DateTime FormatDate { get; set; }

        /// <summary>
        /// layui 分页数
        /// </summary>
        [DataTableToDBColumns]
        public int page { get; set; } = 1;
        
        /// <summary>
        /// layui 显示行数
        /// </summary>
        [DataTableToDBColumns]
        public int limit { get; set; } = 10;

        /// <summary>
        /// 查询起始时间
        /// </summary>
        [DataTableToDBColumns]
        public string StartDate { get; set; } = null;

        /// <summary>
        /// 查询结束时间
        /// </summary>
        [DataTableToDBColumns]
        public string EndDate { get; set; } = null;
    }
}
