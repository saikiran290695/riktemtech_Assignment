using RiktamTech.IServices;
using RiktamTech.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace RiktamTech.DependencyInjection
{
    public static class Unity
    {
        public static IUnityContainer container = new UnityContainer();
        public static void init() {
            
            container.RegisterType<IAuthServices, AuthServices>();
            container.RegisterType<IGroupServices, GroupServices>();
            container.RegisterType<IMessageServices, MessageServices>();
            container.RegisterType<IUserServices, UserServices>();
        }
    }
}