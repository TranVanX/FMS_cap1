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
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        db_FMSEntities db = new db_FMSEntities();
        public ActionResult Index()
        {
            return View();
        }
        //Manage Account
        public ActionResult ManageAcc()
        {
            return View(db.LOGIN.ToList());
        }
        public ActionResult AddAcc()
        {
            return View(new AccountValidate());
        }
        [HttpPost]
        public ActionResult AddAcc(AccountValidate ac)
        {
            ViewBag.err = String.Empty;
            var checknv = db.LOGIN.Any(x => x.C_Staff_id == ac.StaffId);
            if (checknv)
            {
                ViewBag.err = "Account already exist";
                return View(ac);
            }
            else
            {
                LOGIN lnAdd = new LOGIN();              
                lnAdd.C_Username = ac.UserName;
                lnAdd.C_Password = ac.Password;
                lnAdd.C_Staff_id = ac.StaffId;
                lnAdd.C_Role = ac.Role;
                //them moi
                db.LOGIN.Add(lnAdd);
                db.SaveChanges();

                return Redirect("~/Admin/Admin/ManageAcc");
            }
        }


        public ActionResult UpdateAcc()
        {
            return View();
        }
        //Manage Employee
        public ActionResult ManageEmploy()
        {
            return View(db.STAFF.ToList());
        }

        public ActionResult AddEmpl()
        {
            return View(new UserValidate());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmpl(UserValidate nv)
        {
            var checkstaff = db.STAFF.Any(x => x.C_Staff_id == nv.StaffID);
            if (checkstaff)
            {
                ViewBag.err = "Staff ID already exist";
                //ModelState.AddModelError("MaNhanVien", "Mã tài khoản đã tồn tại");
                return View(nv);
            }
            else
            {
                STAFF Addst = new STAFF();
                Addst.C_Staff_id = nv.StaffID;
                Addst.C_Staff_name = nv.StaffName;
                Addst.C_Birthday = nv.Birthday;
                Addst.C_Gender = nv.Gender;
                Addst.C_Identity_card = nv.IdentityCard;
                Addst.C_Position = nv.Position;
                Addst.C_Ward = nv.Ward;
                Addst.C_District = nv.District;
                Addst.C_City = nv.City;
                Addst.C_Department_id = nv.DepartmentID;

                db.STAFF.Add(Addst);
                db.SaveChanges();
                return Redirect("/Admin/Admin/ManageEmploy");
            }
        }

        public ActionResult UpdateEmpl()
        {
            return View(new UserValidate());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateEmpl(UserValidate us)
        {
            var checkst = db.STAFF.Where(n => n.C_Staff_id == us.StaffID).FirstOrDefault();
            if (checkst != null)
            {
                checkst.C_Staff_id = us.StaffID;
                checkst.C_Staff_name = us.StaffName;
                checkst.C_Birthday = us.Birthday;
                checkst.C_Gender = us.Gender;
                checkst.C_Identity_card = us.IdentityCard;
                checkst.C_Position = us.Position;
                checkst.C_Ward = us.Ward;
                checkst.C_District = us.District;
                checkst.C_City = us.City;
                checkst.C_Department_id = us.DepartmentID;
                db.SaveChanges();
                return Redirect("/Admin/Admin/ManageEmploy");
            }
            else
            {
                ViewBag.err = "Staff ID does not exist";
                return View(us);
            }
        }

        public ActionResult DeleteEmploy(String id)
        {
            var st = db.STAFF.Where(n => n.C_Staff_id == id).FirstOrDefault();
            if (st != null)
            {
                db.STAFF.Remove(st);
                db.SaveChanges();
                return Redirect("~/Admin/Admin/ManageEmploy");
            }
            return Redirect("~/Admin/Admin/ManageEmploy");
        }



        // Manage Depart
        public ActionResult ManageDepart()
        {
            return View(db.DEPARTMENT.ToList());
        }
        public ActionResult AddDepart()
        {
            return View(new DepartmentValidate());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDepart(DepartmentValidate dp)
        {
            var checkde = db.DEPARTMENT.Any(x => x.C_Department_id == dp.DepartmentID);
            if (checkde == false)
            {
                DEPARTMENT dpAdd = new DEPARTMENT();
                dpAdd.C_Department_id = dp.DepartmentID;
                dpAdd.C_Department_Name = dp.DepartmentName;
                dpAdd.C_Department_Phone = dp.DepartmentPhone;
                dpAdd.C_Department_Address = dp.DepartmentAddress;
                db.DEPARTMENT.Add(dpAdd);
                db.SaveChanges();
                return Redirect("~/Admin/Admin/ManageDepart");
            }
            else
            {
                ViewBag.err = "Department already exist";
                return View(dp);
            }
        }

        public ActionResult UpdateDepart()
        {
            return View(new DepartmentValidate());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDepart(DepartmentValidate dp)
        {
            var checkdp = db.DEPARTMENT.Where(n => n.C_Department_id == dp.DepartmentID).FirstOrDefault();
            if (checkdp!=null)
            {
                checkdp.C_Department_id = dp.DepartmentID;
                checkdp.C_Department_Name = dp.DepartmentName;
                checkdp.C_Department_Phone = dp.DepartmentPhone;
                checkdp.C_Department_Address = dp.DepartmentAddress;
                db.SaveChanges();
                return Redirect("~/Admin/Admin/ManageDepart");
            }
            else
            {
                ViewBag.err = "Department ID does not exist";
                return View(dp);
            }
        }

        public ActionResult DeleteDepart(String id)
        {
            var dp = db.DEPARTMENT.Where(n => n.C_Department_id == id).FirstOrDefault();
            if(dp != null)
            {
                db.DEPARTMENT.Remove(dp);
                db.SaveChanges();
                return Redirect("~/Admin/Admin/ManageDepart");
            }
            return Redirect("~/Admin/Admin/ManageDepart");
        }

        public ActionResult ListEmploy()
        {
            return View();
        }

        //Manage FaceID
        public ActionResult FaceID()
        {
            return View();
        }
    }
}