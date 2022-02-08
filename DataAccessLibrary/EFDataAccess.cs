using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class EFDataAccess : ISQLDataAccess
    {

        private readonly string _dbconfig;

        private CompanyOrderContext _dbcontext;

        public EFDataAccess(string dbconfig)
        {
            _dbconfig = dbconfig;
            _dbcontext = new CompanyOrderContext(_dbconfig);
        }
        

        public Company GetCompany(String connectionString, int CompanyId)
        {

            Company values = new Company();

            
            //values = _dbcontext.Company.Where(x => x.CompanyId == CompanyId).ToList().FirstOrDefault();

            /*
            var returnCode = new SqlParameter();
            returnCode.ParameterName = "@ReturnCode";
            returnCode.SqlDbType = SqlDbType.Int;
            returnCode.Direction = ParameterDirection.Output;
                       
            var outParam = new SqlParameter("@StatusLog", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;

            //values = _dbcontext.Company.Where(x => x.CompanyId == CompanyId).ToList().FirstOrDefault();
            //, @StatusLog  outParam
            var data = _dbcontext.Database.SqlQuery<Company>("exec @ReturnCode = proc_CompanyFetch @Id", returnCode, code);

            var item = data.FirstOrDefault();

            values = _dbcontext.Database.SqlQuery<Company>("exec @ReturnCode = proc_CompanyFetch @Id", returnCode, code).FirstOrDefault();
            */

            var code = new SqlParameter("@Id", CompanyId);

            values = _dbcontext.Database.SqlQuery<Company>("exec proc_CompanyFetch @Id", code).FirstOrDefault();


            if (values == null)
            {
                throw new ExNoCompany();
            }
            
            return values;

        }
        
        public List<Order> GetCompanyOrders(String connectionString, int CompanyId)
        {

            List<Order> values = new List<Order>();
            
            values = _dbcontext.Order.Where(x => x.CompanyId == CompanyId).ToList();
            
            /*
            var code = new SqlParameter("@Id", CompanyId);
            values = _dbcontext.Database.SqlQuery<Order>("exec proc_CompanyOrders @Id", code).ToList();

            Parallel.ForEach(values, val =>
            {
                val.OrderId = val.order_id;
            });
            */

            return values;
        }
        
        public List<OrderProduct> GetOrderProducts(String connectionString, int CompanyId)
        {

            List<OrderProduct> values = new List<OrderProduct>();

            values = _dbcontext.OrderProduct.Where(x => x.Order.CompanyId == CompanyId).Include(x => x.Product).ToArray().ToList();
            
            /*
            var code = new SqlParameter("@Id", CompanyId);
            values = _dbcontext.Database.SqlQuery<OrderProduct>("exec proc_OrderProducts @Id", code).ToList();

            Parallel.ForEach(values, val =>
            {

                val.OrderId = val.order_id;

                val.Product = new Product()
                {
                    Name = val.Name,
                    Price = val.ProductPrice
                };
                
            });
            */

            return values;
        }

    }
}
