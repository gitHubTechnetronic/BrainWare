﻿using System;
using System.Collections.Generic;
using DataAccessLibrary.Models;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLibrary
{

    public class SQLDataAccess : ISQLDataAccess
    {

        public Company GetCompany(String connectionString, int CompanyId)
        {

            Company values = new Company();
                        
            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("proc_CompanyFetch", _con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Id", SqlDbType.Int).Value = CompanyId;

                    _con.Open();

                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        if (!oReader.HasRows)
                        {                            
                            throw new ExNoCompany();
                        }

                        while (oReader.Read())
                        {
                            var record1 = (IDataRecord)oReader;
                            
                            values.CompanyId = record1.GetInt32(0);
                            values.CompanyName = record1.GetString(1);

                        }
                    }
                    
                }
            }
              
            return values;

        }
        

        public List<Order> GetCompanyOrders(String connectionString, int CompanyId)
        {

            List<Order> values = new List<Order>();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("proc_CompanyOrders", _con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Id", SqlDbType.Int).Value = CompanyId;

                    _con.Open();

                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            var record1 = (IDataRecord)oReader;

                            values.Add(new Order()
                            {
                                Description = record1.GetString(0),
                                OrderId = record1.GetInt32(1),
                                OrderProducts = new List<OrderProduct>()
                            });
                        }
                    }
                    
                }
            }
            
            return values;
        }

                
        public List<OrderProduct> GetOrderProducts(String connectionString, int CompanyId)
        {

            List<OrderProduct> values = new List<OrderProduct>();

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("proc_OrderProducts", _con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Id", SqlDbType.Int).Value = CompanyId;

                    _con.Open();

                    using (SqlDataReader oReader = command.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            var record1 = (IDataRecord)oReader;

                            values.Add(new OrderProduct()
                            {
                                OrderId = record1.GetInt32(1),
                                ProductId = record1.GetInt32(2),
                                Price = record1.GetDecimal(0),
                                Quantity = record1.GetInt32(3),
                                Product = new Product()
                                {
                                    Name = record1.GetString(4),
                                    Price = record1.GetDecimal(5)
                                }

                            });
                        }
                    }
                    
                }
            }
            
            return values;
        }

    }
}
