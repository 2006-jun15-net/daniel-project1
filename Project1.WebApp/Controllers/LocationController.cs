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

        public LocationController(ILocationRepository locationRepo)
        {
            _locationRepo = locationRepo ?? throw new ArgumentNullException(nameof(locationRepo));
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

    }
}
