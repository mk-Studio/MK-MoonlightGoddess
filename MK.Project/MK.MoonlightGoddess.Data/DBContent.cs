using MK.MoonlightGoddess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Data
{
    public class DBContent
    {
        public DBContent() { }

        public DBContent(string xmlName)
        {
            XmlName = xmlName;
        }

        public string XmlName { get; set; }

        public string GetSql()
        {
            SqlXmlContent sqlXmlContent = new SqlXmlContent();
            return sqlXmlContent.GetSqlByXML();
        }

        public string GetSql(string xmlName, string sqlName)
        {
            SqlXmlContent sqlXmlContent = new SqlXmlContent();
            return sqlXmlContent.GetSqlByXML(xmlName, sqlName);
        }
    }
}
