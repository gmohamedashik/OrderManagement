using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Web.Models
{
    public class VendorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<OrderDto> Orders { get; set; }
    }
}
