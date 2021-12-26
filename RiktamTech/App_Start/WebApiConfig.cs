﻿using RiktamTech.Filters;
using System.Web.Http;

namespace RiktamTech
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{actionName}/{id}",
                defaults: new { id = RouteParameter.Optional }                
            );

            config.Filters.Add(new JWTAuthenticationFilter());
        }
    }
}
