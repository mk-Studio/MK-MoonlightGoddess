using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK.MoonlightGoddess.Web.Controllers.AuthorityInfo.PowerForm
{
    public class PowerInfoManageController : Controller
    {
        // GET: PowerInfoManage
        public ActionResult AddPower()
        {
            return View("../Authority/PowerForm/FormAddPower");
        }

        public ActionResult EditPower()
        {
            return View("../Authority/PowerForm/FormEditPower");
        }

        public ActionResult FunctionOperation()
        {
            return View("../Authority/PowerForm/FormFunctionalOperation");
        }

        public ActionResult AddFunction()
        {
            return View("../Authority/PowerForm/FormAddFunction");
        }

        public ActionResult EditFunction()
        {
            return View("../Authority/PowerForm/FormEditFunction");
        }

        public ActionResult EditNavigation()
        {
            return View("../Authority/PowerForm/FormEditNavigation");
        }
    }
}