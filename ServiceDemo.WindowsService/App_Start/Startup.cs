using Owin; 
using System.Web.Http;
using Microsoft.Practices.Unity.WebApi;

namespace ServiceDemo.WindowsService
{
    public class Startup 
    { 
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder) 
        { 
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
         
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ); 

            var resolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());

            config.DependencyResolver = resolver;
    
            appBuilder.UseWebApi(config);
            appBuilder.MapSignalR();


        
        } 
    } 
} 
