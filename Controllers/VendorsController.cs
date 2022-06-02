using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderManagement.Domain.Services;
using OrderManagement.Web.Models;

namespace OrderManagement.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorsService _vendorService;
        private readonly IMapper _mapper;

        public VendorsController(IVendorsService vendorService, IMapper mapper)
        {
            _vendorService = vendorService;
            _mapper = mapper;

        }

        // GET: api/Vendors
        [HttpGet]
        public async Task<IEnumerable<VendorDto>> Get()
        {
            return _mapper.Map<IEnumerable<VendorDto>>(await _vendorService.GetVendorsList());
        }
    }
}
