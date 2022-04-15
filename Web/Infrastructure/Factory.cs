using DataAccessLibrary;
using Web.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Http.Dependencies;
using System;
using System.Collections.Generic;
using System.Configuration;
using ReportsOrder;

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
        
        public enum ReportType
        {
            PDF,
            TXT,
            Word       
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

        public static IReports CreateReportsService(ReportType rt)
        {
            switch (rt)
            {
                case ReportType.PDF:
                    return new R_iTextSharp();

                case ReportType.TXT:
                    return new R_Text();
                    
                case ReportType.Word:
                    return new R_Text();

                default:
                    return new R_iTextSharp();
            }
        }
        
        public static IOrderService CreateOrderService(ReportType rt = ReportType.PDF)
        {
            return new OrderService(CreateReportsService(rt));
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


        public static IPersonOrdersRepository CreatePersonOrdersRepository(DBAccessType useThisDB)
        {
            return new PersonOrdersRepository(useThisDB);
        }
    }
}