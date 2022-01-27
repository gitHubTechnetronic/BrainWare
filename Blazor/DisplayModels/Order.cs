using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisplayModels
{
    using System.Security.AccessControl;

    public class Order
    {
        public int OrderId { get; set; }

        public string? CompanyName { get; set; }

        public string? Description { get; set; }

        public decimal OrderTotal { get; set; }

        public List<OrderProduct>? OrderProducts { get; set; }

    }



}