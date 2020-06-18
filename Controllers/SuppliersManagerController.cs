using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EmployeeManager.Mvc.Models;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManager.Mvc.Controllers
{
    [Authorize(Roles = "Manager")]
    public class SuppliersManagerController : Controller
    {
        private AppDbContext db = null;

        public SuppliersManagerController(AppDbContext db)
        {
            this.db = db;
        }

        //View when the products page loads.
        public IActionResult List()
        {
            List<Suppliers> model = (from suppliers in db.Suppliers
                                orderby suppliers.SupplierID
                                select suppliers).ToList();
            return View(model);
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Suppliers model)
        {
            if(ModelState.IsValid)
            {
                db.Suppliers.Add(model);
                db.SaveChanges();
                ViewBag.Message = "Supplier inserted successfully";
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            Suppliers model = db.Suppliers.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Suppliers model)
        {
            if(ModelState.IsValid)
            {
                db.Suppliers.Update(model);
                db.SaveChanges();
                ViewBag.Message = "Supplier updated successfully";
            }
            return View(model);
        }

        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            Suppliers model = db.Suppliers.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int supplierID)
        {
            Suppliers model = db.Suppliers.Find(supplierID);

            //Gets all the supplier ids from the PRODCUCTS table.
            List<int?> getSupplierId = (from suppliers in db.Products
                                            orderby suppliers.SupplierID
                                            select suppliers.SupplierID).ToList();

            //if supplier id exists in the products table, show can't delete message
            if(getSupplierId.Contains(supplierID))
            {
                ViewBag.Message = "Delete Unsuccessful. Delete conflicted with Reference Constraint";
                return View(model); 
            }
            //If passes the check, the supplier is deleted.
            else
            {
                db.Suppliers.Remove(model);
                db.SaveChanges();
                TempData["Message"] = "Supplier deleted successfully";
                return RedirectToAction("List");
            }
        }
    }
}