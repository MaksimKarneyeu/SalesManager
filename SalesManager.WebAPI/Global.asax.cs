using Autofac;
using Autofac.Integration.WebApi;
using SalesManager.Data.Context;
using SalesManager.WebAPI.App_Start;
using System.Data.Entity;
using System.Web.Http;

namespace SalesManager.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new ContextInitializer());
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AutofacConfig.Init();
        }   
    }
}
