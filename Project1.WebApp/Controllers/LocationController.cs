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
        private readonly IOrdersRepository _ordersRepo;

        public LocationController(ILocationRepository locationRepo, IOrderHistoryRepository orderHistoryRepo, IInventoryRepository inventoryRepo, IOrdersRepository ordersRepo)
        {
            _locationRepo = locationRepo ?? throw new ArgumentNullException(nameof(locationRepo));
            _orderhistoryRepo = orderHistoryRepo ?? throw new ArgumentNullException(nameof(orderHistoryRepo));
            _inventoryRepo = inventoryRepo ?? throw new ArgumentNullException(nameof(inventoryRepo));
            _ordersRepo = ordersRepo ?? throw new ArgumentNullException(nameof(ordersRepo));
        }

        public IActionResult Index()
        {

            var viewModel = _locationRepo.GetAll().Select(a => new LocationViewModel
            {
                LocationID = a.LocationID,
                Name = a.Name,
                Address = a.Address
            });

            //setting up shopping cart
            HttpContext.Response.Cookies.Append("ProID1", "0");
            HttpContext.Response.Cookies.Append("ProID2", "0");
            HttpContext.Response.Cookies.Append("ProID3", "0");
            HttpContext.Response.Cookies.Append("ProID4", "0");
            HttpContext.Response.Cookies.Append("ProID5", "0");
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

      
        public ActionResult Shop(int id)
        {
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
                })
            };
            //display shopping cart
            

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Shop(int ProductID, int PurchaseAmount)
        {
            //must place order validation here, such that one cannot over order an item



            int Locationid = int.Parse(HttpContext.Request.Cookies["LocationID"]);
            int customerid = int.Parse(HttpContext.Request.Cookies["CustomerID"]);


            if (ProductID != 0 && PurchaseAmount != 0)
            {
                
                HttpContext.Response.Cookies.Append("ProID"+$"{ProductID}", $"{ProductID}");
                HttpContext.Response.Cookies.Append("PA"+$"{ProductID}", $"{PurchaseAmount}");
            }



            Location location = _locationRepo.GetLocationByID(Locationid);
            var viewModel = new LocationViewModel
            {
                LocationID = location.LocationID,
                Name = location.Name,
                Address = location.Address,
                InventoryViewModels = _inventoryRepo.GetInventoryById(Locationid).Select(m => new InventoryViewModel
                {
                    LocationId = m.LocationId,
                    ProductId = m.ProductId,
                    Name = m.Name,
                    Price = m.Price,
                    Amount = m.Amount
                })
            };

            


            return View(viewModel);

        }


        public ActionResult CompleteOrder()
        {
            //finalize the order from cart

            //shopping cart data
            int Locationid = int.Parse(HttpContext.Request.Cookies["LocationID"]);
            int customerid = int.Parse(HttpContext.Request.Cookies["CustomerID"]);
            int ProductID1 = int.Parse(HttpContext.Request.Cookies["ProID1"]);
            int ProductID2 = int.Parse(HttpContext.Request.Cookies["ProID2"]);
            int ProductID3 = int.Parse(HttpContext.Request.Cookies["ProID3"]);
            int ProductID4 = int.Parse(HttpContext.Request.Cookies["ProID4"]);
            int ProductID5 = int.Parse(HttpContext.Request.Cookies["ProID5"]);
            int Amount1 = int.Parse(HttpContext.Request.Cookies["PA1"]);
            int Amount2 = int.Parse(HttpContext.Request.Cookies["PA2"]);
            int Amount3 = int.Parse(HttpContext.Request.Cookies["PA3"]);
            int Amount4 = int.Parse(HttpContext.Request.Cookies["PA4"]);
            int Amount5 = int.Parse(HttpContext.Request.Cookies["PA5"]);

            //New Order History
            OrderHistory orderHistory = new OrderHistory
            {
                LocationId = Locationid,
                CustomerId = customerid
            };
            _orderhistoryRepo.Create(orderHistory);


            //The new Order ID
            int orderid = _orderhistoryRepo.GetAll().Count();

            //note to self, compress next step into dynamic
            //new orders
            if (ProductID1 == 1)
            {
                Inventory inventory1 = new Inventory
                {
                    LocationId = Locationid,
                    ProductId = ProductID1,
                    Amount = Amount1
                };
                
                Orders orders1 = new Orders
                {
                    OrderID = orderid,
                    ProductID = ProductID1,
                    Amount = Amount1
                };
                //finalize
                _inventoryRepo.Update(inventory1);
                _ordersRepo.Create(orders1);
            }
            if (ProductID2 == 2)
            {
                Inventory inventory2 = new Inventory
                {
                    LocationId = Locationid,
                    ProductId = ProductID2,
                    Amount = Amount2
                };

                Orders orders2 = new Orders
                {
                    OrderID = orderid,
                    ProductID = ProductID2,
                    Amount = Amount2
                };
                //finalize
                _inventoryRepo.Update(inventory2);
                _ordersRepo.Create(orders2);
            }
            if (ProductID3 == 3)
            {
                Inventory inventory3 = new Inventory
                {
                    LocationId = Locationid,
                    ProductId = ProductID3,
                    Amount = Amount3
                };

                Orders orders3 = new Orders
                {
                    OrderID = orderid,
                    ProductID = ProductID3,
                    Amount = Amount3
                };
                //finalize
                _inventoryRepo.Update(inventory3);
                _ordersRepo.Create(orders3);
            }
            if (ProductID4 == 4)
            {
                Inventory inventory4 = new Inventory
                {
                    LocationId = Locationid,
                    ProductId = ProductID4,
                    Amount = Amount4
                };

                Orders orders4 = new Orders
                {
                    OrderID = orderid,
                    ProductID = ProductID4,
                    Amount = Amount4
                };
                //finalize
                _inventoryRepo.Update(inventory4);
                _ordersRepo.Create(orders4);
            }
            if (ProductID5 == 5)
            {
                Inventory inventory5 = new Inventory
                {
                    LocationId = Locationid,
                    ProductId = ProductID5,
                    Amount = Amount5
                };

                Orders orders5 = new Orders
                {
                    OrderID = orderid,
                    ProductID = ProductID5,
                    Amount = Amount5
                };
                //finalize
                _inventoryRepo.Update(inventory5);
                _ordersRepo.Create(orders5);
            }




            return RedirectToAction(nameof(Index));
        }





    }
}
