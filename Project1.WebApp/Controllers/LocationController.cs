using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project1.Domain;
using Project1.WebApp.ViewModels;

namespace Project1.WebApp.Controllers
{
    public class LocationController : Controller
    {

        private readonly ILocationRepository _locationRepo;
        private readonly IOrderHistoryRepository _orderhistoryRepo;
        private readonly IInventoryRepository _inventoryRepo;

        public LocationController(ILocationRepository locationRepo, IOrderHistoryRepository orderHistoryRepo, IInventoryRepository inventoryRepo)
        {
            _locationRepo = locationRepo ?? throw new ArgumentNullException(nameof(locationRepo));
            _orderhistoryRepo = orderHistoryRepo ?? throw new ArgumentNullException(nameof(orderHistoryRepo));
            _inventoryRepo = inventoryRepo ?? throw new ArgumentNullException(nameof(inventoryRepo));
        }

        public IActionResult Index()
        {

            var viewModel = _locationRepo.GetAll().Select(a => new LocationViewModel
            {
                LocationID = a.LocationID,
                Name = a.Name,
                Address = a.Address
            });

            return View(viewModel);
        }

        public ActionResult Details(int id, bool c)
        {
            if (c == false)
            {
                HttpContext.Response.Cookies.Append("Customer", "false");
            };

            if (id != 0)
            {
                HttpContext.Response.Cookies.Append("LocationID", $"{id}");
            }
            else
            {
                id = int.Parse(HttpContext.Request.Cookies["LocationID"]);
            }
            
            Location location = _locationRepo.GetLocationByID(id);
            var viewModel = new LocationViewModel
            {
                LocationID = location.LocationID,
                Name = location.Name,
                Address = location.Address,
                InventoryViewModels = _inventoryRepo.GetInventoryById(id).Select(m => new InventoryViewModel
                {
                    LocationId = m.LocationId,
                    ProductId = m.ProductId,
                    Name = m.Name,
                    Price = m.Price,
                    Amount = m.Amount
                }),
                OrderHistoryViewModels = _orderhistoryRepo.GetOrderHistoryByLocationId(id).Select(y => new OrderHistoryViewModel
                {
                    LocationId = y.LocationId,
                    OrderId = y.OrderId,
                    CustomerId = y.CustomerId,
                    Date = y.Date,
                    Time = y.Time
                })
            };


            return View(viewModel);
        }


      







    }
}
