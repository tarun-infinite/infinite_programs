using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assessment_1.Models;


namespace Assessment_1.Controllers
{
    public class CodeController : Controller
    {
        //private Model1Entities _context = new Model1Entities();
        public northwindEntities2 _context = new northwindEntities2();

        // Action 1: Customers residing in Germany
        public ActionResult CustomersInGermany()
        {
            var customers = _context.Customers
                .Where(c => c.Country == "Germany")
                .ToList();

            return View(customers);
        }

        // Action 2: Customer details for OrderID == 10248
        public ActionResult CustomerWithOrderId()
        {
            var order = _context.Orders
                .Where(o => o.OrderID == 10248)
                .Select(o => o.Customer)
                .FirstOrDefault();

            return View(order);
        }
    }
}