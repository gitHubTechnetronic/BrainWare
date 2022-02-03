﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public class Order
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }

        //public string CompanyName { get; set; }

        public string Description { get; set; }

        [ForeignKey("Company")]
        [Column("company_id")]
        public int CompanyId { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }

        public virtual Company Company { get; set; }
        
    }

}