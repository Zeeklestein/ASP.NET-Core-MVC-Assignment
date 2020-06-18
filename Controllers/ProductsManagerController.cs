using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EmployeeManager.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.Mvc.Controllers
{
        [Authorize(Roles = "Manager")]
    public class ProductsManagerController : Controller
    {
        private AppDbContext db = null;

        public ProductsManagerController(AppDbContext db)
        {
            this.db = db;
        }

        //View when the products page loads.
        public IActionResult List()
        {
            List<Products> model = (from products in db.Products
                                orderby products.ProductID
                                select products).ToList();
            return View(model);
        }

        //Used for filling drop down boxs with supplier IDs.
        private void FillSupplierID()
        {
            List<SelectListItem> supplierID = (from suppliers in db.Suppliers
                                                orderby suppliers.SupplierID
                                                ascending 
                                                select new SelectListItem(){Text = suppliers.SupplierID.ToString(), Value=suppliers.SupplierID.ToString()}).ToList();
            ViewBag.SupplierID = supplierID;
        }
    
        public IActionResult Insert()
        {
            FillSupplierID();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Products model)
        {
            FillSupplierID();
            if(ModelState.IsValid)
            {
                db.Products.Add(model);
                db.SaveChanges();
                ViewBag.Message = "Product inserted successfully";
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            Products model = db.Products.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Products model)
        {
            if(ModelState.IsValid)
            {
                db.Products.Update(model);
                db.SaveChanges();
                ViewBag.Message = "Product updated successfully";
            }
            return View(model);
        }

        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            Products model = db.Products.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int productID)
        {
            Products model = db.Products.Find(productID);
            db.Products.Remove(model);
            db.SaveChanges();
            TempData["Message"] = "Product deleted successfully";
            return RedirectToAction("List");
        }
    }
    
}