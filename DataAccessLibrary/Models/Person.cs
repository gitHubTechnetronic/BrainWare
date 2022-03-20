
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public class Person
    {

        [Key]
        public int PersonId { get; set; }
       
        [MaxLength(128)]
        public string NameFirst { get; set; }

        [MaxLength(128)]
        public string NameLast { get; set; }
        
        public List<Order_Person> Orders { get; set; }

    }
}
