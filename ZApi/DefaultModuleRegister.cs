using Autofac;
using EntityFramework.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;
using ZDomain.IRepository;

namespace ZApi
{
    public class DefaultModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //注册所有程序集中的类
            builder.RegisterAssemblyTypes(GetAssembly("Application")).Where(t => t.Name.EndsWith("Server")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(GetAssembly("ZDomain")).Where(t => t.Name.EndsWith("Server")).AsImplementedInterfaces().InstancePerLifetimeScope();
           
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>)).AsImplementedInterfaces().InstancePerLifetimeScope();
        }

        public static Assembly GetAssembly(string assemblyName)
        {
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + $"{assemblyName}.dll");
            return assembly;
        }
    }
}
