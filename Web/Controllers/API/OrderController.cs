using System.Web.Http;

namespace Web.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;
    using Newtonsoft.Json;
    using System;

    [DemoAuthorize]
    public class OrderController : ApiController
    {
                
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            if (orderService == null)
            {
                throw new ArgumentNullException(nameof(orderService));
            }
            else
            {
                _orderService = orderService;

            }
        }
        

        [HttpGet]
        public string GetCompanyOrders(int id)
        {
            /*
            System.Web.Http.Controllers.HttpActionContext actionContext
            try
            {
                var someCode = (from h in actionContext.Request.Headers where h.Key == "Authorization" select h.Value.First()).FirstOrDefault();
                return someCode == "demo Token";
            }
            catch (Exception)
            {
                return false;
            }
            */
            
            //Consider upgrading to System.Text.Json when upgrading .net framework            
            return JsonConvert.SerializeObject(_orderService.GetCompanyOrders(Factory.CreateCompanyOrdersRepository(Factory.DBAccessType.EF), id));
        }

    }
}
