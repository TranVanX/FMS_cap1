using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMS.Models;
using System.Text;

namespace FMS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        db_FMSEntities objModel = new db_FMSEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LOGIN login)
        {
            if (ModelState.IsValid)
            {
                var data = objModel.LOGIN.Any(s => s.C_Username == login.C_Username && s.C_Password == login.C_Password);
                var checkadmin = objModel.LOGIN.Any(s => s.C_Username == login.C_Username && s.C_Password == login.C_Password && s.C_Role == 1);
                var checkmanage = objModel.LOGIN.Any(s => s.C_Username == login.C_Username && s.C_Password == login.C_Password && s.C_Role == 2);
                var checkchef = objModel.LOGIN.Any(s => s.C_Username == login.C_Username && s.C_Password == login.C_Password && s.C_Role == 3);
                var checkstaff = objModel.LOGIN.Any(s => s.C_Username == login.C_Username && s.C_Password == login.C_Password && s.C_Role == 4);
                if (data)
                {
                    Session["C_Role"] = login.C_Role;
                    Session["C_Staff_id"] = login.C_Staff_id;
                    if (checkadmin)
                    {
                        return Redirect("~/admin/Admin/Index");
                    }
                    if (checkmanage)
                    {
                        return Redirect("~/Manage/ManagerS/ManagePro");
                    }
                    if (checkchef)
                    {
                        return Redirect("~/Chef/ChefS/ManageMenu");
                    }
                    if (checkstaff)
                    {
                        return Redirect("~/StaffS/StaffS/Order");
                    }
                }

            }
            else
            {
                ViewBag.error = "Login failed";
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}