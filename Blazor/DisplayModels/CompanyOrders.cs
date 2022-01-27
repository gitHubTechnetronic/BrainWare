using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisplayModels
{
    public class CompanyOrders
    {
                 
        public DisplayCompany? Company { get; set; }

        public List<Order>? Orders { get; set; }

    }
}