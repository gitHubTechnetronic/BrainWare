using System.Collections.Generic;
using System.Linq;

namespace Web.Infrastructure
{
    using System;
    using System.Data;
    using System.Threading.Tasks;
    using ViewModels;
    using ReportsOrder;
    using System.Web;

    public class OrderService : IOrderService
    {        
        private readonly IReports _reports;

        public OrderService(IReports reports)
        {
            if (reports == null)
            {
                throw new ArgumentNullException(nameof(reports));
            }
            else
            {
                _reports = reports;

            }
        }
        
        public CompanyOrders GetCompanyOrders(ICompanyOrdersRepository CompanyOrders, int CompanyId)
        {
            
            CompanyOrders _companyOrders = CompanyOrders.GetCompany(CompanyId);
            
            // Get the orders                        
            var orderValues = CompanyOrders.GetCompanyOrders(CompanyId);

            //Get the order products      
            var orderProductValues = CompanyOrders.GetOrderProducts(CompanyId);

            PopulateProducts(orderValues, orderProductValues);

            TotalOrders(orderValues);
                        
            _companyOrders.Orders = orderValues;

            List<string> ReportStrings = new List<string>();

            ReportStrings.Add("Company ID: " + _companyOrders.Company.CompanyId);

            ReportStrings.Add("Company Name: " + _companyOrders.Company.CompanyName);

            ReportStrings.Add("");

            foreach (Order_Company oc in _companyOrders.Orders)
            {
                ReportStrings.Add("     " + oc.Description + " (Total: " + oc.OrderTotal.ToString() + ")");
                foreach (OrderProduct op in oc.OrderProducts)
                {
                    ReportStrings.Add("          " + op.Product.Name + " (" + op.Quantity + " @ " + op.Price + "/ea)");
                }
                ReportStrings.Add("");
            }

            _companyOrders.ReportFile = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "//" + _reports.CreateDoc(ReportStrings);

            return _companyOrders;
            
        }

        public void PopulateProducts(List<Order_Company> orderValues, List<OrderProduct> orderProductValues)
        {
            Parallel.ForEach(orderValues, order =>
            {
                orderProductValues.Where(w => w.OrderId == order.OrderId).ToList().ForEach(f => order.OrderProducts.Add(f));
            });
        }
        
        public void TotalOrders(List<Order_Company> orderValues)
        {
            orderValues.ForEach(x => x.OrderTotal = (x.OrderProducts.Aggregate(0m, (c, d) => c += d.Price * d.Quantity)));
        }
        
        public List<Person> GetPersonOrdersByDate(IPersonOrdersRepository personOrders, DateTime orderDate)
        {
            List<Person> _personOrders = personOrders.GetPersonOrdersByDate(orderDate);
            
            return _personOrders;
        }        

    }
}