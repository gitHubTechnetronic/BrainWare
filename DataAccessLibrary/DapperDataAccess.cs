using System;
using System.Collections.Generic;
using DataAccessLibrary.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace DataAccessLibrary
{

    public class DapperDataAccess : ISQLDataAccess
    {

        public Company GetCompany(String connectionString, int CompanyId)
        {

            Company values = new Company();
                        
            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                values = _con.QueryFirst<Company>($"proc_CompanyFetch { CompanyId }");
                
            }
              
            return values;

        }
        

        public List<Order> GetCompanyOrders(String connectionString, int CompanyId)
        {

            List<Order> values = new List<Order>();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                values = _con.Query<Order>($"proc_CompanyOrders { CompanyId }").ToList(); 

            }
            
            return values;
        }

                
        public List<OrderProduct> GetOrderProducts(String connectionString, int CompanyId)
        {

            List<OrderProduct> values = new List<OrderProduct>();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                
                values = _con.Query<OrderProduct>($"proc_OrderProducts { CompanyId }").ToList(); 

                Parallel.ForEach(values, val =>
                {                    
                    val.Product = new Product()
                    {
                        Name = val.Name,
                        Price = val.ProductPrice
                    };
                    
                });
                
            }

            return values;
        }

    }
}
