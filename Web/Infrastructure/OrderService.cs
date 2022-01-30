using System.Collections.Generic;
using System.Linq;

namespace Web.Infrastructure
{
    using System;
    using System.Data;
    using System.Threading.Tasks;
    using ViewModels;

    public class OrderService : IOrderService
    {
        
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

            return _companyOrders;
            
        }

        public void PopulateProducts(List<Order> orderValues, List<OrderProduct> orderProductValues)
        {
            Parallel.ForEach(orderValues, order =>
            {
                orderProductValues.Where(w => w.OrderId == order.OrderId).ToList().ForEach(f => order.OrderProducts.Add(f));
            });
        }
        
        public void TotalOrders(List<Order> orderValues)
        {
            orderValues.ForEach(x => x.OrderTotal = (x.OrderProducts.Aggregate(0m, (c, d) => c += d.Price * d.Quantity)));
        }

    }
}