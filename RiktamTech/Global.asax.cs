using RiktamTech.IServices;
using RiktamTech.Services;
using System.Web.Http;
using Unity;

namespace RiktamTech
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyInjection.Unity.init();
            GlobalConfiguration.Configure(WebApiConfig.Register);            
        }
    }
}
