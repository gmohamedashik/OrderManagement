using System;
using System.Collections.Generic;

#nullable disable

namespace OrderManagement.Domain.Entities
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public decimal OrderAmount { get; set; }
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
        public int ShopNumber { get; set; }

    }
}
