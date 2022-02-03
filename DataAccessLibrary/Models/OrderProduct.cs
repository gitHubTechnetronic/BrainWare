
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{

    public class OrderProduct
    {

        [Key]
        public int OrderProductId { get; set; }

        [ForeignKey("Order")]
        [Column("order_id")]
        public int OrderId { get; set; }
        
        [ForeignKey("Product")]
        [Column("product_id")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public virtual Order Order { get; set; }

        
    }

}
