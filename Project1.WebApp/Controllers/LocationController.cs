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

        public LocationController(ILocationRepository locationRepo, IOrderHistoryRepository orderHistoryRepo)
        {
            _locationRepo = locationRepo ?? throw new ArgumentNullException(nameof(locationRepo));
            _orderhistoryRepo = orderHistoryRepo ?? throw new ArgumentNullException(nameof(orderHistoryRepo));
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

        public ActionResult Details(int id)
        {
            Location location = _locationRepo.GetLocationByID(id);
            var viewModel = new LocationViewModel
            {
                LocationID = location.LocationID,
                Name = location.Name,
                Address = location.Address,
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
