using AutoMapper;
using OrderManagement.Domain.Entities;
using OrderManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Web.Mappings
{
    public class VendorMapping : Profile
    {
        public VendorMapping()
        {
            CreateMap<VendorDto, Vendor>();
            CreateMap<Vendor, VendorDto>();

        }
    }
}
