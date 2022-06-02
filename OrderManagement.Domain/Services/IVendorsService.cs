using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Services
{
    public interface IVendorsService
    {
        Task<IEnumerable<Vendor>> GetVendorsList();
    }
}
