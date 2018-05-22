using MK.MoonlightGoddess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.SQL
{
    public class SqlXmlContent
    {
        /// <summary>
        /// xml文件根路径
        /// </summary>
        private readonly string SQL_XML_PATH = AppDomain.CurrentDomain.BaseDirectory.Replace("Web","SQL");

        public string GetSqlByXML()
        {
            return SQL_XML_PATH;
        }

        public string GetSqlByXML(string xmlName,string sqlName)
        {
            string xmlPath = SQL_XML_PATH + xmlName + ".xml";
            string sql = ConfigHelper.GetXmlText(xmlPath, sqlName);
            return sql;
        }
    }
}
