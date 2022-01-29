using System.Collections.Generic;

namespace Web.ViewModels
{
    using DataAccessLibrary;

    public class CompanyOrdersRepository : BaseRepository, ICompanyOrdersRepository
    {

        public CompanyOrders GetCompany(int CompanyId)
        {
            
            DataAccessLibrary.Models.Company convertCompany;

            CompanyOrders _companyOrders = new CompanyOrders();
            _companyOrders.Company = new Company();
            
            try
            {
                convertCompany = Infrastructure.Factory.CreateSQLDataAccess().GetCompany(_connectionstring, CompanyId);
            }
            catch (ExNoCompany)
            {
                convertCompany = new DataAccessLibrary.Models.Company();
                _companyOrders.Company.isinDatabase = false;
                _companyOrders.Company.ErrorMessage = "Company is not found in DataBase";

                return _companyOrders;
            }

            _companyOrders.Company.isinDatabase = true;
            _companyOrders.Company.CompanyId = convertCompany.CompanyId;
            _companyOrders.Company.CompanyName = convertCompany.CompanyName.Trim();

            return _companyOrders;
        }

        
        public List<Order> GetCompanyOrders(int CompanyId)
        {
            var orderValues = new List<Order>();

            var convertOrders = Infrastructure.Factory.CreateSQLDataAccess().GetCompanyOrders(_connectionstring, CompanyId);

            foreach (var order in convertOrders)
            {
                orderValues.Add(new Order()
                {
                    Description = order.Description,
                    OrderId = order.OrderId,
                    OrderProducts = new List<OrderProduct>()
                });
            }

            return orderValues;

        }

        
        public List<OrderProduct> GetOrderProducts(int CompanyId)
        {
            var orderProductValues = new List<OrderProduct>();

            var convertOrderProducts = Infrastructure.Factory.CreateSQLDataAccess().GetOrderProducts(_connectionstring, CompanyId);

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
                        Name = orderProduct.Product.Name,
                        Price = orderProduct.Product.Price
                    }
                });

            }

            return orderProductValues;
        }

    }
}