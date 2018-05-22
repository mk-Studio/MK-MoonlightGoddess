using MK.MoonlightGoddess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Service
{
    public class ServiceMKTypeWuLiao : ServiceAbstract
    {
        public static string SelectWuLiaoType()
        {
            Content = new DBContent();
            return Content.GetSql();
        }

        public static string SelectWuLiaoType(string xmlName, string sqlName)
        {
            Content = new DBContent();
            return Content.GetSql(xmlName,sqlName);
        }
    }
}
