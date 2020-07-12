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
        private readonly IOrdersRepository _ordersRepo;

        public OrderHistoryController(IOrderHistoryRepository orderhistoryRepo, IOrdersRepository ordersRepo)
        {
            _orderhistoryRepo = orderhistoryRepo ?? throw new ArgumentNullException(nameof(orderhistoryRepo));
            _ordersRepo = ordersRepo ?? throw new ArgumentNullException(nameof(ordersRepo));
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


        public ActionResult Details(int id)
        {
            
            OrderHistory orderHistory = _orderhistoryRepo.GetOrderHistoryByOrderId(id);
            var viewModel = new OrderHistoryViewModel
            {
                OrderId = orderHistory.OrderId,
                LocationId = orderHistory.LocationId,
                CustomerId = orderHistory.CustomerId,
                Date = orderHistory.Date,
                Time = orderHistory.Time,
                Orders = _ordersRepo.GetOrdersByOrderId(id).Select(t => new OrdersViewModel
                {
                    OrderID = t.OrderID,
                    ProductID = t.ProductID,
                    Name = t.Name,
                    Amount = t.Amount
                })
            };

            return View(viewModel);
        }




    }
}
