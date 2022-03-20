using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        
        // [ForeignKey("Person")]
        public int PersonId { get; set; }
        
        public DateTime OrderDateTime { get; set; }
        
    }

}