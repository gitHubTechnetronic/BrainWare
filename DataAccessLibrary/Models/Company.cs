
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public class Company
    {

        [Key]
        [Column("company_id")]
        public int CompanyId { get; set; }

        [MaxLength(128)]
        [Column("name")]
        public string CompanyName { get; set; }
        
    }
}
