using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Interface
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> GetOrdersList();
        Task<Order> GetOrderById(int id);
        Task<Order> CreateOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(Order order);
        Task DeleteAllOrder(List<int> ids);
    }
}
