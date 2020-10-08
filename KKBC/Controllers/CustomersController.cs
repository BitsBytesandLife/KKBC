using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKBC.Models;
using Microsoft.AspNetCore.Mvc;

namespace KKBC.Controllers
{
    public class CustomersController : Controller
    {
    
        private readonly ICustomersRepository repo;

        public CustomersController(ICustomersRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var customers = repo.GetAllCustomers();
            return View(customers);
        }

        public IActionResult ViewCustomer(int id)
        {
            var cust = repo.GetCustomer(id);

            return View(cust);
        }

        public IActionResult ViewCustomerByCustomer(Customers customer)
        {
            var cust = repo.GetCustomer(customer.CustID);

            return View(cust);
        }


        public IActionResult UpdateCustomer(int id)
        {
            var cust = repo.GetCustomer(id);

            if (cust == null)
            {
                return View("CustomerNotFound");
            }

            return View(cust);
        }

        public IActionResult UpdateCustomerToDatabase(Customers cust)
        {
            repo.UpdateCustomer(cust);

            return RedirectToAction("ViewCustomer", new { id = cust.CustID });
        }


        public IActionResult InsertCustomer()
        {
            var cust = new Customers();
            
            return View(cust);
        }

        public IActionResult CustomerToDatabase(Customers cust)
        {
            repo.InsertCustomer(cust);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCustomer(Customers cust)
        {
            repo.DeleteCustomer(cust);

            return RedirectToAction("Index");
        }

    }
}
