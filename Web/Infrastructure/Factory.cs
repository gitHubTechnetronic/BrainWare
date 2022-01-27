using DataAccessLibrary;
using Web.DisplayModels;

namespace Web.Infrastructure
{
    public static class Factory
    {

        public static IOrderService CreateOrderService()
        {
            return new OrderService();
        }
                
        public static ISQLDataAccess CreateSQLDataAccess()
        {
            return new SQLDataAccess();
        }
        
        public static ICompanyOrdersRepository CreateCompanyOrdersRepository()
        {
            return new CompanyOrdersRepository();
        }
        
    }
}