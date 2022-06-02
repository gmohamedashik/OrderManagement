using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Web.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public decimal OrderAmount { get; set; }
        public int VendorId { get; set; }
        public VendorDto Vendor { get; set; }
        public int ShopNumber { get; set; }
    }
}
