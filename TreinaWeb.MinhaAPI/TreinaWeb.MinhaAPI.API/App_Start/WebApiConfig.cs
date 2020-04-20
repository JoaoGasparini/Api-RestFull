using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TreinaWeb.MinhaAPI.API.Filters;
using TreinaWeb.MinhaAPI.API.Formatters;

namespace TreinaWeb.MinhaAPI.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
            };

            config.Formatters.Add(new CsvMediaTyperFormatter());
            config.Filters.Add(new FillResponseWithHATEOASAttribute());

            //var xmlFormatter = config.Formatters.XmlFormatter;
            //config.Formatters.Remove(xmlFormatter);
    
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
