using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Project1.Domain;
using Project1.WebApp.Models;
using Project1.WebApp.ViewModels;

namespace Project1.WebApp.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerRepository _customerRepo;
   
        public HomeController(ILogger<HomeController> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepo = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public IActionResult Index()
        {
            return View();
        }

        
        // attempting login page
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind("FirstName, LastName")] CustomerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                {
                    var customer = _customerRepo.GetCustomerByFullName(viewModel.FirstName, viewModel.LastName);
                    if (customer != null)
                    {
                        HttpContext.Response.Cookies.Append("CustomerID", $"{customer.CustomerId}");
                        HttpContext.Response.Cookies.Append("FirstName", $"{customer.FirstName}");
                        HttpContext.Response.Cookies.Append("LastName", $"{customer.LastName}");
    
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(viewModel);
        }

        public ActionResult UserDashBoard()
        {
            if (HttpContext.Request.Cookies["CustomerID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    
    }
}
