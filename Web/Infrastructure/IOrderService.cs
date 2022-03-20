using System;
using System.Collections.Generic;
using Web.ViewModels;

namespace Web.Infrastructure
{
    public interface IOrderService
    {
        CompanyOrders GetCompanyOrders(ICompanyOrdersRepository CompanyOrders, int CompanyId);
        List<Person> GetPersonOrdersByDate(IPersonOrdersRepository CompanyOrders, DateTime orderDate);
    }
}