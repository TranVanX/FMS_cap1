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
            return View(new FoodValidate());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addfood(FoodValidate fv)
        {
            var checkfd = db.MENU.Any(x => x.C_Food_id == fv.FoodID);
            if (checkfd == false)
            {
                MENU adfd = new MENU();
                adfd.C_Food_id = fv.FoodID;
                adfd.C_Food_name = fv.FoodName;
                adfd.C_Description = fv.FoodDescrip;

                db.MENU.Add(adfd);
                db.SaveChanges();
                return Redirect("~/admin/Chef/ManageMenu");
                
            }
            else
            {
                ViewBag.err = "Food already exist";
                return View(fv);
            }
        }

        public ActionResult Deletefood(String id)
        {
            var fd = db.MENU.Where(n => n.C_Food_id == id).FirstOrDefault();
            if (fd != null)
            {
                db.MENU.Remove(fd);
                db.SaveChanges();
                return Redirect("~/admin/Chef/ManageMenu");
            }
            return Redirect("~/admin/Chef/ManageMenu");
        }

        //Manage supplier
        public ActionResult ManageSupp()
        {
            return View(db.SUPPLIER.ToList());
        }
        public ActionResult Addsupplier()
        {
            return View(new SupplierValidate());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addsupplier(SupplierValidate sp)
        {
            var checksp = db.SUPPLIER.Any(x => x.C_Supplier_id == sp.SupplierID);
            if (checksp == false)
            {
                SUPPLIER spadd = new SUPPLIER();
                spadd.C_Supplier_id = sp.SupplierID;
                spadd.C_Supplier_name = sp.SupplierName;
                spadd.C_Supplier_phone = sp.SupplierPhone;
                spadd.C_Supplier_address = sp.SupplierAddress;
                db.SUPPLIER.Add(spadd);
                db.SaveChanges();
                return Redirect("~/admin/Chef/ManageSupp");
            }
            else
            {
                ViewBag.err = "Supplier already exist";
                return View(sp);
            }
        }

        public ActionResult Updatesupplier()
        {
            return View(new SupplierValidate());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Updatesupplier(SupplierValidate sp)
        {
            var checksp = db.SUPPLIER.Where(x => x.C_Supplier_id == sp.SupplierID).FirstOrDefault();
            if(checksp != null)
            {
                checksp.C_Supplier_id = sp.SupplierID;
                checksp.C_Supplier_name = sp.SupplierName;
                checksp.C_Supplier_phone = sp.SupplierPhone;
                checksp.C_Supplier_address = sp.SupplierAddress;
                db.SaveChanges();
                return Redirect("~/admin/Chef/ManageSupp");
            }
            else
            {
                ViewBag.err = "Supplier do not exist";
                return View(sp);
            }
        }
        
        public ActionResult DeleteSupp(String id)
        {
            var fd = db.SUPPLIER.Where(n => n.C_Supplier_id == id).FirstOrDefault();
            if (fd != null)
            {
                db.SUPPLIER.Remove(fd);
                db.SaveChanges();
                return Redirect("~/admin/Chef/ManageSupp");
            }
            return Redirect("~/admin/Chef/ManageSupp");
        }

        //Manage Material
        public ActionResult ManageMaterial()
        {
            return View(db.INGREDIENT.ToList());
        }

        public ActionResult Addmaterial()
        {
            return View(new MaterialValidate());
        }

        //View Registration
        public ActionResult ViewRegis()
        {
            return View();
        }
    }
}