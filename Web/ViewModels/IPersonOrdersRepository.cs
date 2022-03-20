using System;
using System.Collections.Generic;

namespace Web.ViewModels
{
    public interface IPersonOrdersRepository
    {
        List<Person> GetPersonOrdersByDate(DateTime orderDate);
    }
}