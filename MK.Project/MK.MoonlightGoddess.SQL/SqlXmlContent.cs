using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.SQL
{
    public class SqlXmlContent
    {
        //AppDomain.CurrentDomain.RelativeSearchPath = 
        //E:\GitHub\Project\BS\MK-MoonlightGoddess\MK-MoonlightGoddess\MK.Project\MK.MoonlightGoddess.Web\bin
        private readonly string SQL_XML_PATH = AppDomain.CurrentDomain.BaseDirectory.Replace("Web","SQL");

        public string GetSqlByXML()
        {
            return SQL_XML_PATH;
        }
    }
}
