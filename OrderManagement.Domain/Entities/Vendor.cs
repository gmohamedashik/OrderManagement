using System;
using System.Collections.Generic;

#nullable disable

namespace OrderManagement.Domain.Entities
{
    public partial class Vendor
    {
 
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
