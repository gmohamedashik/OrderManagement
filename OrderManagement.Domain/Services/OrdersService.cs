using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interface;

namespace OrderManagement.Domain.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _orderRepository;

        public OrdersService(IOrdersRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetOrdersList()
        {
            return await _orderRepository.GetOrdersList();

        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _orderRepository.GetOrderById(id);
        }

        public async Task<Order> CreateOrder(Order order)
        {
            return await _orderRepository.CreateOrder(order);
        }
        public async Task UpdateOrder(Order order)
        {
             await _orderRepository.UpdateOrder(order);
        }

        public async Task DeleteOrder(Order order)
        {
             await _orderRepository.DeleteOrder(order);
        }

        public async Task DeleteAllOrder(List<int> ids)
        {
             await _orderRepository.DeleteAllOrder(ids);
        }
    }
}
