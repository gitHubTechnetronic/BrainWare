using System.Collections.Generic;
using DisplayModels;

namespace Web.DisplayModels
{
    public interface ICompanyOrdersRepository
    {
        CompanyOrders GetCompany(int CompanyId);
        List<Order> GetCompanyOrders(int CompanyId);
        List<OrderProduct> GetOrderProducts(int CompanyId);
    }
}