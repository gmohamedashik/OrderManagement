using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Interface
{
    public interface IVendorsRepository
    {
        Task<IEnumerable<Vendor>> GetVendorsList();
    }
}
