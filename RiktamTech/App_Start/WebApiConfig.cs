﻿using RiktamTech.Filters;
using RiktamTech.IServices;
using RiktamTech.Services;
using System.Web.Http;
using Unity;

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
