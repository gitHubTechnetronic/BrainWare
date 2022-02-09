using DataAccessLibrary;
using Web.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Http.Dependencies;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Web.Infrastructure
{

    public class Factory : System.Web.Mvc.IDependencyResolver, System.Web.Http.Dependencies.IDependencyResolver 
    {

        public enum DBAccessType
        {
            SQL,
            EF,
            Dapper
        }

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

        public static ISQLDataAccess CreateSQLDataAccess(DBAccessType useThisDB)
        {

            switch (useThisDB)
            {
                case DBAccessType.SQL:
                    return new SQLDataAccess();                    
                case DBAccessType.EF:
                    return new EFDataAccess(ConfigurationManager.ConnectionStrings["BrainWareConnectionString"].ConnectionString);                    
                case DBAccessType.Dapper:
                    return new DapperDataAccess();
                default:
                    return new SQLDataAccess();                    
            }
                      
        }

        public static ICompanyOrdersRepository CreateCompanyOrdersRepository(DBAccessType useThisDB)
        {
            return new CompanyOrdersRepository(useThisDB);
        }
    }
}