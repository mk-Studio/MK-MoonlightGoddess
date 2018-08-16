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

        public ActionResult FormTypeWuLiuYeWu()
        {
            return View("../BaseInfoViews/Form/FormTypeWuLiuYeWu");
        }

        public ActionResult FormInfoWuLiuCompany()
        {
            return View("../BaseInfoViews/Form/FormInfoWuLiuCompany");
        }

        public ActionResult FormInfoCurrency()
        {
            return View("../BaseInfoViews/Form/FormInfoCurrency");
        }

        //...
        public ActionResult FormTypeDictionaryLabel()
        {
            return View("../BaseInfoViews/Form/FormTypeDictionaryLabel");
        }

        public ActionResult FormTypeDataDictionary()
        {
            return View("../BaseInfoViews/Form/FormTypeDataDictionary");
        }


        //查询区域

        public ActionResult QueryFormInfoWuLiao()
        {
            return View("../BaseInfoViews/QueryForm/QueryFormInfoWuLiao");
        }

        public ActionResult QueryFormTypeWuLiao()
        {
            return View("../BaseInfoViews/QueryForm/QueryFormTypeWuLiao");
        }

        public ActionResult QueryFormInfoSupplier()
        {
            return View("../BaseInfoViews/QueryForm/QueryFormInfoSupplier");
        }

        public ActionResult QueryFormTypeWuLiuYeWu()
        {
            return View("../BaseInfoViews/QueryForm/QueryFormTypeWuLiuYeWu");
        }

        public ActionResult QueryFormInfoWuLiuCompany()
        {
            return View("../BaseInfoViews/QueryForm/QueryFormInfoWuLiuCompany");
        }

        public ActionResult QueryFormInfoCurrency()
        {
            return View("../BaseInfoViews/QueryForm/QueryFormInfoCurrency");
        }
    }
}