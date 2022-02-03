using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    class CompanyOrderContext : DbContext
    {
        
        public CompanyOrderContext() : base(ConfigurationManager.ConnectionStrings["BrainWareConnectionString"].ConnectionString) { }

        public CompanyOrderContext(String dbconfig) : base(dbconfig) { }
        
        public DbSet<Company> Company { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}
