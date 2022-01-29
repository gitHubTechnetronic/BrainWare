using System.Collections.Generic;

namespace Web.ViewModels
{
    public class CompanyOrders
    {
                 
        public Company Company { get; set; }

        public List<Order> Orders { get; set; }
           
    }
}