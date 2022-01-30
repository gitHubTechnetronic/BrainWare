using Microsoft.Extensions.DependencyInjection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Web.Controllers;
using Web.Infrastructure;

namespace Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services                                                
            var services = new ServiceCollection();
            
            services.AddScoped<OrderController>();
            services.AddSingleton<IOrderService, OrderService>();
                        
            var resolver = new Factory(services.BuildServiceProvider());
            // Set MVC Resolver
            DependencyResolver.SetResolver(resolver);
            
            // Set WebAPI Resolver and register            
            config.DependencyResolver = resolver;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
