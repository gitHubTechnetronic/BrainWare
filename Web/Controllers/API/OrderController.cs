using System.Web.Http;

namespace Web.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;
    using Newtonsoft.Json;

    [DemoAuthorize]
    public class OrderController : ApiController
    {               
        
        [HttpGet]
        public string GetCompanyOrders(int id)
        {           
            IOrderService data = Factory.CreateOrderService();

            //Consider upgrading to System.Text.Json when upgrading .net framework            
            return JsonConvert.SerializeObject(data.GetCompanyOrders(Factory.CreateCompanyOrdersRepository(), id));
        }

    }
}
