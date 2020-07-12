using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Domain;
using Project1.WebApp.ViewModels;

namespace Project1.WebApp.Controllers
{
    public class OrderHistoryController : Controller
    {
        private readonly IOrderHistoryRepository _orderhistoryRepo;

        public OrderHistoryController(IOrderHistoryRepository orderhistoryRepository)
        {
            _orderhistoryRepo = orderhistoryRepository ?? throw new ArgumentNullException(nameof(orderhistoryRepository));
        }



        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderHistoryViewModel viewModel)
        {



            return View(viewModel);
        }

    }
}
