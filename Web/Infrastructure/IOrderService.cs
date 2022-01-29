using Web.ViewModels;

namespace Web.Infrastructure
{
    public interface IOrderService
    {
        CompanyOrders GetCompanyOrders(ICompanyOrdersRepository CompanyOrders, int CompanyId);        
    }
}