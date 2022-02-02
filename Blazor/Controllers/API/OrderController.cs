﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BrainWare.Data;
using DisplayModels;


namespace Web.Controllers
{
    //using System.Web.Mvc;
    using Infrastructure;
    //using Models;
    


    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase // ApiController
    {
        /*
        [HttpGet]
        public IEnumerable<Order> GetOrders(int id = 1)
        {
            var data = new OrderService();

            return data.GetOrdersForCompany(id);
        }
        */
      
        [HttpGet]
        public CompanyOrders GetCompanyOrders([FromServices] IConfiguration _config, int id = 1)
        {
            var data = new OrderService(_config);
            
            //return data.GetOrdersForCompany(id);

            return data.GetCompanyOrders(id);  // JsonConvert.SerializeObject(
        }

    }
}
