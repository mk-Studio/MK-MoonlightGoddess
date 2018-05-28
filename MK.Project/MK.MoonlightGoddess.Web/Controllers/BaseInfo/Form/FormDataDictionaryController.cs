using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers.BaseInfo.Form
{
    public class FormDataDictionaryController : Controller
    {
        // GET: FormDataDictionary
        public ActionResult FormInfoWuLiao()
        {
            return View("../BaseInfoViews/Form/FormInfoWuLiao");
        }
    }
}