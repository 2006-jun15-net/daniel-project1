using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Project1.Domain;
using Project1.WebApp.Models;
using Project1.WebApp.ViewModels;
using SolrNet.Utils;
using Project1.Data;
using Project1.Data.Model;

namespace Project1.WebApp.Controllers
{
    public class HomeController : Controller
    {
        //add for location
        private readonly ILocationRepository _locationRepo;
        //
        private readonly ILogger<HomeController> _logger;

        //add for location "(ILocationRepository locationRepo, "
        public HomeController(ILocationRepository locationRepo, ILogger<HomeController> logger)
        {
            //add for location
            _locationRepo = locationRepo;
            //

            _logger = logger;
        }

        public IActionResult Index()
        {
            //add for location
            //var viewModel = _locationRepo.GetAll().Select(a => new LocationViewModel
           // {
           //     Name = a.Name,
           //     Adress = a.Address
           // });

            //return View(viewModel);
            return View();
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
