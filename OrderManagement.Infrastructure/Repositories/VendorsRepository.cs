using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Data;
using OrderManagement.Domain.Interface;

namespace OrderManagement.Infrastructure.Repositories
{
    public class VendorsRepository : IVendorsRepository
    {
        private readonly OrderDbContext _context;

        public VendorsRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vendor>> GetVendorsList()
        {
            return await _context.Vendors
                .ToListAsync();
        }
    }
}
