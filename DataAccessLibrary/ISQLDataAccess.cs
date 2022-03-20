using System.Collections.Generic;
using DataAccessLibrary.Models;
using System;

namespace DataAccessLibrary
{
    public interface ISQLDataAccess
    {
        Company GetCompany(string connectionString, int CompanyId);
        List<Order_Company> GetCompanyOrders(string connectionString, int CompanyId);
        List<OrderProduct> GetOrderProducts(string connectionString, int CompanyId);
        List<Person> GetPersonOrdersByDate(string connectionString, DateTime orderDate);
    }
}