using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EmployeeManager.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.Mvc.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ReportsController : Controller
    {
        private AppDbContext db = null;

        public ReportsController(AppDbContext db)
        {
            this.db = db;
        }

         //View when the products page loads. Also fills the drop down lists.
        public IActionResult ReportList()
        {
            FillTrueFalse();
            FillSupplierID();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Create a form to report on continued and discontinued products
        public IActionResult DiscontinuedTrueOrFalse(string discontinued)
        {  

            List<Products> model;

            if (discontinued == "true")
            {
                //List all products that are discontinued
                model = (from products in db.Products
                        orderby products.ProductName
                        where products.Discontinued == true
                        select products).ToList();  
            }
            else
            {
                //List all products that are NOT discontined
                model = (from products in db.Products
                        orderby products.ProductName
                        where products.Discontinued == false
                        select products).ToList();
            }
            return View(model);
        }

        //Used to fill a drop down box with true and false.
        private void FillTrueFalse()
        {
            List<SelectListItem> FillTrueFalse;

            FillTrueFalse = new List<SelectListItem>
            {
                new SelectListItem {Text="true", Value="true"},
                new SelectListItem {Text="false", Value="false"},
            };

            ViewBag.ProductsBool = FillTrueFalse;
        }

        //Used to fill a drop down box with supplier name (Company Name) from the PRODUCTS table.
        private void FillSupplierID()
        {
            //Uses a join to get company name from the supplier table
            List<SelectListItem> supplierId = (from products in db.Products
                                                join suppliers in db.Suppliers on products.SupplierID equals suppliers.SupplierID
                                                orderby suppliers.CompanyName
                                                select new SelectListItem(){Text = suppliers.CompanyName, Value=products.SupplierID.ToString()}).Distinct().ToList();

            ViewBag.ProductsSupplier = supplierId;
        }

        //Create a form to report/display which Products are offered by Suppliers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SupplierProducts(int supplierID)
        {
            
            List<Products> model = (from products in db.Products
                                    orderby products.SupplierID
                                    where products.SupplierID == supplierID
                                    select products).ToList();
            return View(model);
        }
    }
}