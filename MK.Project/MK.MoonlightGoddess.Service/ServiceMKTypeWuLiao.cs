using MK.MoonlightGoddess.Data;
using MK.MoonlightGoddess.Models;
using MK.MoonlightGoddess.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Service
{
    public static class ServiceMKTypeWuLiao
    {
        public static LayuiTableResultModel SelectWuLiaoType(string xmlName, string sqlName)
        {
            using (ServiceContent<MK_Type_WuLiao> sc = new ServiceContent<MK_Type_WuLiao>())
            {
                return sc.Select(new MK_Type_WuLiao(), xmlName, sqlName);
            }
        }
    }
}
