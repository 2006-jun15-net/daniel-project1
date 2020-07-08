using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Data;
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
        public IActionResult Index([FromQuery] string search = "")
        {

            var customers = _customerRepo.GetCustomers(search);
            var viewModel = customers.Select(a => new CustomerViewModel
            {
                CustomerID = a.CustomerId,
                FirstName = a.FirstName,
                LastName = a.LastName
            });



            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("FirstName, LastName")] CustomerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer customer = new Customer
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName
                    };
                    _customerRepo.Create(customer);
                 

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            Customer customer = _customerRepo.GetCustomerById(id);
            var viewModel = new CustomerViewModel
            {
                CustomerID = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromRoute]int id, [Bind("FirstName, LastName")]CustomerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer customer = _customerRepo.GetCustomerById(id);
                    customer.FirstName = viewModel.FirstName;
                    customer.LastName = viewModel.LastName;
                    _customerRepo.Update(customer);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch (Exception)
            {
                return View(viewModel);
            }
        }

        public ActionResult Details(int id)
        {
            Customer customer = _customerRepo.GetCustomerById(id);
            var viewModel = new CustomerViewModel
            {
                CustomerID = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
            return View(viewModel);
        }
        



    }
}
