using Autofac;
using SalesManager.Common.DataTableHelpers;
using SalesManager.Data.BulkOperations;
using SalesManager.Data.Context;
using SalesManager.Data.Entities;
using SalesManager.Data.Repositories;

namespace SalesManager.DIModulesConfig.Modules
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        { 
        }         

        public static void RegisterRepositories(ContainerBuilder builder)
        {
            var context = new SalesManagerContext();

            builder.RegisterType<DocumentRepository>()
                .As<IRepository<Document>>()
                .WithParameter("context", context)
                .InstancePerDependency();

            builder.RegisterType<SaleRepository>()
                .As<IRepository<Sale>>()
                .WithParameter("context", context)
                 .InstancePerDependency();

            builder.RegisterType<DocumentBulkOperator>()
                .As<IBulkOperator>()
                .InstancePerDependency();

            builder.RegisterType<DataTableBuilder>()
                .As<IDataTableBuilder>()
                .InstancePerDependency();
        }
    }
}
