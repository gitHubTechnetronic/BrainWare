using System.Collections.Generic;

namespace Web.ViewModels
{
    public interface ICompanyOrdersRepository
    {
        CompanyOrders GetCompany(int CompanyId);
        List<Order> GetCompanyOrders(int CompanyId);
        List<OrderProduct> GetOrderProducts(int CompanyId);
    }
}