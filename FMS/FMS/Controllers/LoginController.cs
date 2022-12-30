using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMS.Models;
using System.Text;
using System.Security.Cryptography;


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
                var password = GetMD5(login.C_Password);
                var staffid = objModel.LOGIN.Where(s => s.C_Username == login.C_Username && s.C_Password == password).FirstOrDefault();
                var checkadmin = objModel.LOGIN.Any(s => s.C_Username == login.C_Username && s.C_Password == password && s.C_Role == 1);
                var checkmanage = objModel.LOGIN.Any(s => s.C_Username == login.C_Username && s.C_Password == password && s.C_Role == 2);
                var checkchef = objModel.LOGIN.Any(s => s.C_Username == login.C_Username && s.C_Password == password && s.C_Role == 3);
                var checkstaff = objModel.LOGIN.Any(s => s.C_Username == login.C_Username && s.C_Password == password && s.C_Role == 4);
                Session["C_Staff_id"] = staffid.C_Staff_id;
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
            else
            {
                ViewBag.error = "Login failed";
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}