using Autofac;
using SalesManager.Common.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManager.DIModulesConfig.Modules
{
    public class FileReadersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
        }

        public static void RegisterFilesReader(ContainerBuilder builder)
        {
            builder.RegisterType<CsvReader>()
                .As<ICsvReader>()
                .InstancePerLifetimeScope();    
        }
    }
}
