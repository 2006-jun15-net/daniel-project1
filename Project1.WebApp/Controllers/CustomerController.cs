using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Domain;
using Project1.WebApp.ViewModels;

namespace Project1.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepo = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }
        public IActionResult Index()
        {

            var viewModel = _customerRepo.GetAll().Select(a => new CustomerViewModel
            {
                CustomerID = a.CustomerId,
                FirstName = a.FirstName,
                LastName = a.LastName
            });



            return View(viewModel);
        }
    }
}
