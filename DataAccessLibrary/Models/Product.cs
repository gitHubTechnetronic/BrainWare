using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{

    public class Product
    {

        [Key]
        public int product_id { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }

        public decimal Price { get; set; }

    }

}