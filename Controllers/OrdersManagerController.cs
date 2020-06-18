using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EmployeeManager.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.Mvc.Controllers
{
    [Authorize(Roles = "Manager")]
    public class OrdersManagerController : Controller
    {
        private AppDbContext db = null;

        public OrdersManagerController(AppDbContext db)
        {
            this.db = db;
        }

        private void FillCustomerId()
        {
            List<SelectListItem> customerId = (from c in db.Customers 
                                            orderby c.CustomerID
                                            ascending select new SelectListItem() { Text = c.CustomerID, Value = c.CustomerID}).ToList();
            ViewBag.Customers = customerId;
        }

        private void FillEmployeeID()
        {
            List<SelectListItem> employeeId = (from e in db.Employees
                                            select new SelectListItem() {Text = e.EmployeeID.ToString(), Value = e.EmployeeID.ToString()}).ToList();
            ViewBag.Employees = employeeId;
        }

        private void FillShippers()
        {
            List<SelectListItem> shipperId = (from s in db.Shippers
                                            orderby s.ShipperID
                                            select new SelectListItem() {Text = s.ShipperID.ToString(), Value = s.ShipperID.ToString()}).ToList();
            ViewBag.Shippers = shipperId;
        }

        public IActionResult List()
        {
            List<Orders> model = (from o in db.Orders
                                orderby o.CustomerID
                                select o).ToList();
            return View(model);
        }

        public IActionResult Insert()
        {
            FillCustomerId();
            FillEmployeeID();
            FillShippers();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Orders model)
        {
            FillCustomerId();
            FillEmployeeID();
            FillShippers();
            if(ModelState.IsValid)
            {
                db.Orders.Add(model);
                db.SaveChanges();
                ViewBag.Message = "Order inserted successfully";
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            FillCustomerId();
            FillEmployeeID();
            FillShippers();
            Orders model = db.Orders.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Orders model)
        {
            FillCustomerId();
            FillEmployeeID();
            FillShippers();
            if(ModelState.IsValid)
            {
                db.Orders.Update(model);
                db.SaveChanges();
                ViewBag.Message = "Order updated successfully";
            }
            return View(model);
        }

        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            Orders model = db.Orders.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int orderID)
        {
            Orders model = db.Orders.Find(orderID);
            db.Orders.Remove(model);
            db.SaveChanges();
            TempData["Message"] = "Order deleted successfully";
            return RedirectToAction("List");
        }

    }
}