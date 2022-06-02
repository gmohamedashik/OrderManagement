using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interface;
using OrderManagement.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Domain.UnitTests.Services
{
    [TestClass]
    public class OrderServiceTest
    {
        private readonly Mock<IOrdersRepository> _mockOrdersRepository;
        private readonly IOrdersService _orderService;

        public OrderServiceTest()
        {
            _mockOrdersRepository = new Mock<IOrdersRepository>();
            _orderService = new OrdersService(_mockOrdersRepository.Object);
        }

        [TestMethod]
        public void Test_GetOrdersList_Thats_Returns_AllOrders()
        {
            //Arrange
            var orders = new List<Order>();
            orders.Add(new Order()
            {
                Id = 1,
                OrderAmount = 1000,
                OrderDate = System.DateTime.Now,
                OrderNumber = 5,
                VendorId = 1,
                ShopNumber = 45
            });
           _mockOrdersRepository.Setup(x => x.GetOrdersList()).Returns(Task.FromResult(orders.AsEnumerable()));
           
            //Act
            var orderList = _orderService.GetOrdersList();

            //Assert
            Assert.IsTrue(orderList.Result.ToList().Any());

        }

        [TestMethod]
        public void Test_GetOrdersList_Thats_Returns_NoOrders()
        {
            //Arrange
            var orders = new List<Order>();        
            _mockOrdersRepository.Setup(x => x.GetOrdersList()).Returns(Task.FromResult(orders.AsEnumerable()));

            //Act
            var orderList = _orderService.GetOrdersList();

            //Assert
            Assert.IsTrue(!orderList.Result.ToList().Any());
        }

        [TestMethod]
        public void Test_GetOrderById_Thats_Returns_An_Order()
        {
            //Arrange
            var order = new Order()
            {
                Id = 1,
                OrderAmount = 1000,
                OrderDate = System.DateTime.Now,
                OrderNumber = 5,
                VendorId = 1,
                ShopNumber = 45
            };
            _mockOrdersRepository.Setup(x => x.GetOrderById(1)).Returns(Task.FromResult(order));

            //Act
            var orderResponse = _orderService.GetOrderById(1);

            //Assert
            Assert.IsTrue(order.Id == orderResponse.Result.Id);


        }
  
        [TestMethod]
        public void Test_CreateOrder_Thats_Creates_New_Order()
        {
            //Arrange
            var order = new Order()
            {
                Id = 1,
                OrderAmount = 1000,
                OrderDate = System.DateTime.Now,
                OrderNumber = 5,
                VendorId = 1,
                ShopNumber = 45
            };
            _mockOrdersRepository.Setup(x => x.CreateOrder(order)).Returns(Task.FromResult(order));

            //Act
            var orderResponse = _orderService.CreateOrder(order);

            //Assert
            Assert.IsTrue(order.Id == orderResponse.Result.Id);
        }


        [TestMethod]
        public void Test_UpdateOrder_Thats_Updates_Exis_Order()
        {
            //Arrange
            var order = new Order()
            {
                Id = 1,
                OrderAmount = 1040,
                OrderDate = System.DateTime.Now,
                OrderNumber = 5,
                VendorId = 1,
                ShopNumber = 45
            };
            _mockOrdersRepository.Setup(x => x.UpdateOrder(order)).Returns(Task.CompletedTask);

            //Act
            var orderResponse = _orderService.UpdateOrder(order);

            //Assert
            Assert.IsTrue(orderResponse.IsCompleted);

        }



        [TestMethod]
        public void Test_DeleteOrder_Thats_Deletes_Exis_Order()
        {
            //Arrange
            var order = new Order()
            {
                Id = 1,
                OrderAmount = 1040,
                OrderDate = System.DateTime.Now,
                OrderNumber = 5,
                VendorId = 1,
                ShopNumber = 45
            };
            _mockOrdersRepository.Setup(x => x.DeleteOrder(order)).Returns(Task.CompletedTask);

            //Act
            var orderResponse = _orderService.DeleteOrder(order);

            //Assert
            Assert.IsTrue(orderResponse.IsCompleted);

        }


    }
}
