using System.Collections.Generic;

namespace Web.ViewModels
{
    using DataAccessLibrary;
    using Infrastructure;
    using System;

    public class PersonOrdersRepository : BaseRepository, IPersonOrdersRepository
    {

        private Factory.DBAccessType _useThisDB = Factory.DBAccessType.EF;

        public PersonOrdersRepository(Factory.DBAccessType useThisDB)
        {
            _useThisDB = useThisDB;
        }
                     
        public List<Person> GetPersonOrdersByDate(DateTime orderDate)
        {
            var orderValues = new List<Person>();

            var convertOrders = Infrastructure.Factory.CreateSQLDataAccess(_useThisDB).GetPersonOrdersByDate(_connectionstring, orderDate);

            foreach (var order in convertOrders)
            {
                orderValues.Add(new Person()
                {
                    PersonId = order.PersonId,
                    NameFirst = order.NameFirst,
                    NameLast = order.NameLast                    
                });
            }

            return orderValues;

        }       

    }
}