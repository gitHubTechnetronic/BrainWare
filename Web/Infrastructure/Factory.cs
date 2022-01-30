using DataAccessLibrary;
using System.Threading.Tasks;
using Web.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Http.Dependencies;
using System;
using System.Collections.Generic;

namespace Web.Infrastructure
{
    
    public class Factory : System.Web.Mvc.IDependencyResolver, System.Web.Http.Dependencies.IDependencyResolver 
    {        

        private IServiceProvider _serviceProvider;
        
        public Factory()
        {
        }
        
        public Factory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _serviceProvider.GetServices(serviceType);
        }
                
        public IDependencyScope BeginScope()
        {
            return new Factory(_serviceProvider.CreateScope().ServiceProvider);            
        }
        
        public void Dispose()
        {            
        }


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