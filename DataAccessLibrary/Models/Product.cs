using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{

    public class Product
    {

        [Key]
        public int product_id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

    }

}