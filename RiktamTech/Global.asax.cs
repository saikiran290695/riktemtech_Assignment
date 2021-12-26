using System.Web.Http;

namespace RiktamTech
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {                        
            GlobalConfiguration.Configure(WebApiConfig.Register);   
            
        }
    }
}
