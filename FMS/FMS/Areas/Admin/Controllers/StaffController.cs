using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMS.Models;
using System.Web.Security;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FMS.Areas.Admin.Controllers
{
    public class StaffController : Controller
    {
        // GET: Admin/Staff
        db_FMSEntities db = new db_FMSEntities();
        public ActionResult Order()
        {
            return View(db.MENU.ToList());
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