using Microsoft.AspNetCore.Mvc;
using Moq;
using Project1.Data.Model;
using Project1.Domain;
using Project1.WebApp.Controllers;
using Project1.WebApp.ViewModels;
using System.Collections.Generic;
using Xunit;


namespace Project1.Test
{

    public class CustomerControllerTests
    {
        private readonly Mock<ICustomerRepository> _mockRepo;
        private readonly Mock<IOrderHistoryRepository> _mockRepo2;
        private readonly CustomerController _controller;
        public CustomerControllerTests()
        {
            _mockRepo2 = new Mock<IOrderHistoryRepository>();
            _mockRepo = new Mock<ICustomerRepository>();
            _controller = new CustomerController(_mockRepo.Object, _mockRepo2.Object);

        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
        }
    

        [Fact]
        public void Create_ActionExecutes_ReturnsViewForCreate()
        {
            var result = _controller.Create();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_InvalidModelState_ReturnsView()
        {
            _controller.ModelState.AddModelError("CustomerID", "ID is required");

            var customer = new CustomerViewModel { FirstName = "Sam", LastName = "Mason" };

            var result = _controller.Create(customer);

            var viewResult = Assert.IsType<ViewResult>(result);
            var testEmployee = Assert.IsType<CustomerViewModel>(viewResult.Model);
            Assert.Equal(customer.LastName, testEmployee.LastName);
            Assert.Equal(customer.FirstName, testEmployee.FirstName);
        }

        [Fact]
        public void Create_InvalidModelState_CreateEmployeeNeverExecutes()
        {
            _controller.ModelState.AddModelError("CustomerID", "ID is required");

            var customer = new CustomerViewModel { FirstName = "Kay" };

            _controller.Create(customer);

            _mockRepo.Verify(x => x.Create(It.IsAny<Customer>()), Times.Never);
        }

        [Fact]
        public void Create_ModelStateValid_CreateEmployeeCalledOnce()
        {
            Customer emp = null;
            _mockRepo.Setup(r => r.Create(It.IsAny<Customer>()))
                .Callback<Customer>(x => emp = x);

            var customer = new CustomerViewModel
            {
                FirstName = "Tester",
                LastName = "Jack"
            };

            _controller.Create(customer);

            _mockRepo.Verify(x => x.Create(It.IsAny<Customer>()), Times.Once);

            
            Assert.Equal(emp.FirstName, customer.FirstName);
            Assert.Equal(emp.LastName, customer.LastName);
        }


        [Fact]
        public void Create_ActionExecuted_RedirectsToIndexAction()
        {
            var customer = new CustomerViewModel
            {
                FirstName = "John",
                LastName = "Doe"
            };

            var result = _controller.Create(customer);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }


    }
}
