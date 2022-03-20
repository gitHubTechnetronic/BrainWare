using System.Collections.Generic;

namespace Web.ViewModels
{
    public interface ICompanyOrdersRepository
    {
        CompanyOrders GetCompany(int CompanyId);
        List<Order_Company> GetCompanyOrders(int CompanyId);
        List<OrderProduct> GetOrderProducts(int CompanyId);
    }
}