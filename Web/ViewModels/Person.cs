
using System.Collections.Generic;

namespace Web.ViewModels
{
    public class Person
    {
        
        public int PersonId { get; set; }
        
        public string NameFirst { get; set; }
        
        public string NameLast { get; set; }

        public List<Order_Person> Orders { get; set; }

    }
}
