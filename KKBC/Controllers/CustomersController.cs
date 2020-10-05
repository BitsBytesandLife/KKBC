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
    }
}
