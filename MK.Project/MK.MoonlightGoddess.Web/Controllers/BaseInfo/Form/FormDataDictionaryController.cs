using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers.BaseInfo.Form
{
    public class FormDataDictionaryController : VerifyLoginController
    {
        // GET: FormDataDictionary
        public ActionResult FormInfoWuLiao()
        {
            return View("../BaseInfoViews/Form/FormInfoWuLiao");
        }

        public ActionResult FormTypeWuLiao()
        {
            return View("../BaseInfoViews/Form/FormTypeWuLiao");
        }

        public ActionResult FormInfoSupplier()
        {
            return View("../BaseInfoViews/Form/FormInfoSupplier");
        }
    }
}