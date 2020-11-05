using Autofac;
using SalesManager.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.DIModulesConfig.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
        }

        public static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<DocumentService>()
                .As<IDocumentService>()             
                .InstancePerLifetimeScope();

            builder.RegisterType<SaleService>()
                .As<ISaleService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DataTableService>()
                .As<IDataTableService>()
                .InstancePerLifetimeScope();
        }
    }
}
