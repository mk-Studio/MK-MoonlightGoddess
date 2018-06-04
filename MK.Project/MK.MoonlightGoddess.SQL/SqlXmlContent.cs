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
        private readonly string SQL_XML_PATH = ConfigHelper.AppSetting("SQL_XML_PATH");

        private string commandText;
        /// <summary>
        /// 命令语句
        /// </summary>
        public string CommandText
        {
            get { return commandText; }
            set { commandText = value; }
        }
        
        public SqlXmlContent(string xmlName, string sqlName)
        {
            CommandText = GetSqlByXML(xmlName, sqlName);
        }

        private string GetSqlByXML(string xmlName,string sqlName)
        {
            string xmlPath = SQL_XML_PATH + xmlName + ".xml";
            CommandText = ConfigHelper.GetXmlText(xmlPath, sqlName);
            return CommandText;
        }
    }
}
