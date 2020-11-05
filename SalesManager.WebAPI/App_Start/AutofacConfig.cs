using Autofac;
using Autofac.Integration.WebApi;
using SalesManager.DIModulesConfig.Modules;
using System.Reflection;
using System.Web.Http;

namespace SalesManager.WebAPI.App_Start
{
    public class AutofacConfig
    {
        public static void Init()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
           
            DataModule.RegisterRepositories(builder);
            FileReadersModule.RegisterFilesReader(builder);
            ServiceModule.RegisterServices(builder);
            

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}