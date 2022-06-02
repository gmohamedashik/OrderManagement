using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interface;
using OrderManagement.Infrastructure.Data;

namespace OrderManagement.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrderDbContext _context;

        public OrdersRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersList()
        {
            return await _context.Orders
                .Include(x => x.Vendor)
                .ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders
                .Include(x => x.Vendor)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Order> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllOrder(List<int> ids)
        {
            _context.Orders.RemoveRange(_context.Orders.Where(x => ids.Contains(x.Id)));
            await _context.SaveChangesAsync();
        }
    }
}
