using MK.MoonlightGoddess.Web.Attribute;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute(),1);
            filters.Add(new MKExceptionFilterAttribute(),2);
        }
    }
}
