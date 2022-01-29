using System.Collections.Generic;

namespace Web.ViewModels
{
    public class Order
    {
        public int OrderId { get; set; }

        //CompanyName not needed for display at Order level
        //public string CompanyName { get; set; }

        public string Description { get; set; }

        public decimal OrderTotal { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
                
    }
    
}