using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public class Order
    {
        [Key]
        //[Column("order_id")]
        public int order_id { get; set; }
        //public int OrderId { get; set; }

        //[NotMapped]
        //public int order_id { get; set; }

        //public string CompanyName { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [ForeignKey("Company")]
        //[Column("company_id")]
        public int company_id { get; set; }
        //public int CompanyId { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }

        public virtual Company Company { get; set; }
        
    }

}