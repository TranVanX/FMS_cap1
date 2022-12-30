using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMS.Areas.StaffS.Controllers
{
    public class StaffSController : Controller
    {
        // GET: StaffS/StaffS
        public ActionResult Order()
        {
            return View();
        }
        public ActionResult Orderfood()
        {
            return View();
        }
        public ActionResult PersonalPro()
        {
            return View();
        }
    }
}