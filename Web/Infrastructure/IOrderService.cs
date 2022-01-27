using DisplayModels;
using Web.DisplayModels;

namespace Web.Infrastructure
{
    public interface IOrderService
    {
        CompanyOrders GetCompanyOrders(ICompanyOrdersRepository CompanyOrders, int CompanyId);        
    }
}