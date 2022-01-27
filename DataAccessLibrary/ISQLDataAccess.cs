using System.Collections.Generic;
using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface ISQLDataAccess
    {
        Company GetCompany(string connectionString, int CompanyId);
        List<Order> GetCompanyOrders(string connectionString, int CompanyId);
        List<OrderProduct> GetOrderProducts(string connectionString, int CompanyId);
    }
}