using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

using BrainWare.Data;
using DataAccessLibrary;

namespace Web.Infrastructure
{
    using System.Data;
    using DisplayModels;
    
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    

    public class OrderService
    {
        private readonly IConfiguration? _config; 

        //public string ConnectionStringName {get; set;} = "";
        private string? _connectionstring;


        public OrderService()
        {
            /*
            IConfiguration configuration = ServiceProvider.GetRequiredService<IConfiguration>();
if(configuration.GetConnectionString("ConnectionString") != null) {
    ConnectionString = configuration.GetConnectionString("ConnectionString");
}
*/
            _connectionstring = "";
        }

        public OrderService(IConfiguration config)
        {
            _config = config;
            //_config.GetConnectionString("default");
        }

        public List<Order> GetOrdersForCompany(int CompanyId)
        {

            var database = new Database();

            // Get the orders
            var sql1 =
                "SELECT c.name, o.description, o.order_id FROM company c INNER JOIN [order] o on c.company_id=o.company_id";

            var reader1 = database.ExecuteReader(sql1);

            var values = new List<Order>();
            
            while (reader1.Read())
            {
                var record1 = (IDataRecord) reader1;

                values.Add(new Order()
                {
                    CompanyName = record1.GetString(0),
                    Description = record1.GetString(1),
                    OrderId = record1.GetInt32(2),
                    OrderProducts = new List<OrderProduct>()
                });

            }

            reader1.Close();

            //Get the order products
            var sql2 =
                "SELECT op.price, op.order_id, op.product_id, op.quantity, p.name, p.price FROM orderproduct op INNER JOIN product p on op.product_id=p.product_id";

            var reader2 = database.ExecuteReader(sql2);

            var values2 = new List<OrderProduct>();

            while (reader2.Read())
            {
                var record2 = (IDataRecord)reader2;

                values2.Add(new OrderProduct()
                {
                    OrderId = record2.GetInt32(1),
                    ProductId = record2.GetInt32(2),
                    Price = record2.GetDecimal(0),
                    Quantity = record2.GetInt32(3),
                    Product = new Product()
                    {
                        Name = record2.GetString(4),
                        Price = record2.GetDecimal(5)
                    }
                });
             }

            reader2.Close();

            foreach (var order in values)
            {

                foreach (var orderproduct in values2)
                {
                    if (orderproduct.OrderId != order.OrderId)
                        continue;

                    order.OrderProducts?.Add(orderproduct);
                    order.OrderTotal = order.OrderTotal + (orderproduct.Price * orderproduct.Quantity);
                }
            
            }

            return values; // Task.FromResult(values).Result;  // Task.FromResult<List<Order>?>(
        }

        
        public CompanyOrders GetCompanyOrders(int CompanyId)
        {
                      
            _connectionstring = _config.GetConnectionString("Default");

            DisplayCompany _company = new DisplayCompany();

            _company.CompanyName = new DataAccessLibrary.SQLDataAccess().GetCompany(_connectionstring, CompanyId).CompanyName?.Trim();

            CompanyOrders _companyOrders = new CompanyOrders();
            _companyOrders.Company = _company;

            // Get the orders
                        
            var convertOrders = new DataAccessLibrary.SQLDataAccess().GetCompanyOrders(_connectionstring, CompanyId);
            
            var orderValues = new List<Order>();
            
            //convertOrderforDisplay
            foreach (var order in convertOrders)
            {
                orderValues.Add(new Order()
                {
                    
                    //CompanyName = record1.GetString(0),
                    Description = order.Description,
                    OrderId = order.OrderId,
                    OrderProducts = new List<OrderProduct>()
                });
            }
            

            //Get the order products
            
            var convertOrderProducts = new DataAccessLibrary.SQLDataAccess().GetOrderProducts(_connectionstring, CompanyId);
            
            var orderProductValues = new List<OrderProduct>();
            
            foreach (var orderProduct in convertOrderProducts)
            {
                orderProductValues.Add(new OrderProduct()
                {
                    OrderId = orderProduct.OrderId,
                    ProductId = orderProduct.ProductId,
                    Price = orderProduct.Price,
                    Quantity = orderProduct.Quantity,
                    Product = new Product()
                    {
                        Name = orderProduct.Product?.Name,
                        Price = orderProduct.Product.Price
                    }
                });

            }
            
            Parallel.ForEach(orderValues, order =>
            {
                orderProductValues.Where(w => w.OrderId == order.OrderId).ToList().ForEach(f => order.OrderProducts?.Add(f));
            });
                        
            orderValues.ForEach(x => x.OrderTotal = (x.OrderProducts.Aggregate(0m, (c, d) => c += d.Price * d.Quantity)));
            
            _companyOrders.Orders = orderValues;

            return _companyOrders;
            
        }

    }
}