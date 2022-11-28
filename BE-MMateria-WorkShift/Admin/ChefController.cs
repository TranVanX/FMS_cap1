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
    public class ChefController : Controller
    {
        // GET: Admin/Chef
        db_FMSEntities db = new db_FMSEntities();
        //Manage menu
        public ActionResult ManageMenu()
        {
            return View(db.MENU.ToList());
        }
        public ActionResult Addfood()
        {
            return View();
        }
        //Manage supplier
        public ActionResult ManageSupp()
        {
            return View(db.SUPPLIER.ToList());
        }
        public ActionResult Addsupplier()
        {
            return View();
        }
        public ActionResult Updatesupplier()
        {
            return View();
        }
        //Manage Material
        public ActionResult ManageMaterial()
        {
            return View(db.INGREDIENT.ToList());
        }
        //Add Material
        public ActionResult Addmaterial()
        {
            return View(new MaterialValidate());
        }
        [HttpPost]
        public ActionResult Addmaterial(MaterialValidate mr)
        {
            var checkma = db.INGREDIENT.Any(x => x.C_Material_id == mr.MaterialID);
            if (checkma == false)
            {
                INGREDIENT mrAdd = new INGREDIENT();
                mrAdd.C_Material_id = mr.MaterialID;
                mrAdd.C_Material_name = mr.MaterialtName;
                mrAdd.C_Quantity_I = mr.MaterialQuantity;
                mrAdd.C_Unit = mr.MaterialUnit;
                db.INGREDIENT.Add(mrAdd);
                db.SaveChanges();
                return Redirect("~/Admin/Chef/ManageMaterial");
            }
            else
            {
                ViewBag.err = "Material already exist";
                return View(mr);
            }
        }
        //Update Material
        public ActionResult Updatematerial()
        {
            return View(new MaterialValidate());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Updatematerial(MaterialValidate mr)
        {
            var checkmr = db.INGREDIENT.Where(n => n.C_Material_id == mr.MaterialID).FirstOrDefault();
            if (checkmr != null)
            {
                checkmr.C_Material_id = mr.MaterialID;
                checkmr.C_Material_name = mr.MaterialtName;
                checkmr.C_Quantity_I = mr.MaterialQuantity;
                checkmr.C_Unit = mr.MaterialUnit;
                db.SaveChanges();
                return Redirect("~/Admin/Chef/ManageMaterial");
            }
            else
            {
                ViewBag.err = "Material ID does not exist";
                return View(mr);
            }
        }
        //Delete Material
        public ActionResult Deletematerial(String id)
        {
            var mr = db.INGREDIENT.Where(n => n.C_Material_id == id).FirstOrDefault();
            if (mr != null)
            {
                db.INGREDIENT.Remove(mr);
                db.SaveChanges();
                return Redirect("~/Admin/Chef/ManageMaterial");
            }
            return Redirect("~/Admin/Chef/ManageMaterial");
        }
        //View Registration
        public ActionResult ViewRegis()
        {
            return View();
        }
    }
}