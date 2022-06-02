using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interface;

namespace OrderManagement.Domain.Services
{
    public class VendorsService : IVendorsService
    {
        private readonly IVendorsRepository _vendorRepository;


        public VendorsService(IVendorsRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public async Task<IEnumerable<Vendor>> GetVendorsList()
        {
            return await _vendorRepository.GetVendorsList();
        }
    }
}
