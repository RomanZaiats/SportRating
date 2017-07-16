using AutoMapper;
using CCTService;
using Microsoft.Practices.Unity;
using ServicesHelper;
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

            MapperConfig.RegisterMapping();
            container.RegisterInstance<IMapper>(Mapper.Instance);

            container.RegisterType<ICCTService, CCTService.CCTService>(new HierarchicalLifetimeManager());    
            CCTService.CCTService.RegisterDependencies(container);

            config.DependencyResolver = new UnityResolver(container);
            DependencyResolver = config.DependencyResolver;

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
