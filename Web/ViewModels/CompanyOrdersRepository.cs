﻿using System.Collections.Generic;

namespace Web.ViewModels
{
    using DataAccessLibrary;
    using Infrastructure;

    public class CompanyOrdersRepository : BaseRepository, ICompanyOrdersRepository
    {

        private Factory.DBAccessType _useThisDB = Factory.DBAccessType.EF;

        public CompanyOrdersRepository(Factory.DBAccessType useThisDB)
        {
            _useThisDB = useThisDB;
        }

        public CompanyOrders GetCompany(int CompanyId)
        {
            
            DataAccessLibrary.Models.Company convertCompany;

            CompanyOrders _companyOrders = new CompanyOrders();
            _companyOrders.Company = new Company();
            
            try
            {
                convertCompany = Infrastructure.Factory.CreateSQLDataAccess(_useThisDB).GetCompany(_connectionstring, CompanyId);
            }
            catch (ExNoCompany)
            {
                convertCompany = new DataAccessLibrary.Models.Company();
                _companyOrders.Company.isinDatabase = false;
                _companyOrders.Company.ErrorMessage = "Company is not found in DataBase";

                return _companyOrders;
            }

            _companyOrders.Company.isinDatabase = true;
            _companyOrders.Company.CompanyId = convertCompany.company_id;
            _companyOrders.Company.CompanyName = convertCompany.name.Trim();

            return _companyOrders;
        }
                
        public List<Order_Company> GetCompanyOrders(int CompanyId)
        {
            var orderValues = new List<Order_Company>();

            var convertOrders = Infrastructure.Factory.CreateSQLDataAccess(_useThisDB).GetCompanyOrders(_connectionstring, CompanyId);

            foreach (var order in convertOrders)
            {
                orderValues.Add(new Order_Company()
                {
                    Description = order.Description,
                    OrderId = order.order_id,
                    OrderProducts = new List<OrderProduct>()
                });
            }

            return orderValues;

        }
                
        public List<OrderProduct> GetOrderProducts(int CompanyId)
        {
            var orderProductValues = new List<OrderProduct>();

            var convertOrderProducts = Infrastructure.Factory.CreateSQLDataAccess(_useThisDB).GetOrderProducts(_connectionstring, CompanyId);

            foreach (var orderProduct in convertOrderProducts)
            {
                orderProductValues.Add(new OrderProduct()
                {
                    OrderId = orderProduct.order_id,
                    ProductId = orderProduct.product_id,
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