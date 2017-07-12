using CCTService;
using Microsoft.Practices.Unity;
using SportRating.Resolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace SportRating
{
    public static class WebApiConfig
    {
        public static IDependencyResolver DependencyResolver;
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<ICCTService, CCTService.CCTService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            DependencyResolver = config.DependencyResolver;
            // Web API configuration and services

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
