using System.Web.Http;
using Microsoft.Owin.Cors;
using Newtonsoft.Json.Serialization;
using Owin;

namespace Project.API
{
    public class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; private set; }

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration = new HttpConfiguration();
            HttpConfiguration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            HttpConfiguration.Formatters
                .JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            HttpConfiguration.Formatters
                .JsonFormatter.UseDataContractJsonSerializer = false;
            appBuilder.UseCors(CorsOptions.AllowAll);
            appBuilder.UseWebApi(HttpConfiguration);
        }
    }
}
