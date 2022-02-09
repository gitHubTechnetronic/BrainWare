using DataAccessLibrary.Models;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection.Emit;

namespace DataAccessLibrary
{
    class CompanyOrderContext : DbContext
    {
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public CompanyOrderContext() : base(ConfigurationManager.ConnectionStrings["BrainWareConnectionString"].ConnectionString) { }

        public CompanyOrderContext(String dbconfig) : base(dbconfig) { }
        
        public DbSet<Company> Company { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}
