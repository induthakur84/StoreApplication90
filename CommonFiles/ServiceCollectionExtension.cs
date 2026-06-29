using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CommonFiles
{
    public  static class ServiceCollectionExtension
    {
        public static void RegisterServices( this  IServiceCollection services, string assemblyName)
        {
            var types = Assembly.Load(assemblyName)
                .GetTypes();

            // get interfaces from the assembly
            var interfaces = types.Where(t => t.GetCustomAttribute<RegisterDependency>() != null && t.IsInterface);
            foreach (var @interface in interfaces)
            {
                var @class= GetImplementationClass(types, @interface);
                AddServicesdescriptor(services, @interface, @class);

            }
        }


        public static void AddServicesdescriptor(IServiceCollection services, Type @interface, Type @class)
        {
            var scope = @interface.GetCustomAttribute<RegisterDependency>().Scope;
            services.Add(new ServiceDescriptor( @interface, @class, scope));
        }


        public static Type GetImplementationClass(Type[] types, Type @interface)
        {
            var @class = types.FirstOrDefault(t => t.GetTypeInfo().ImplementedInterfaces
            .Any(i => i == @interface));

            return @class ?? throw new NotImplementedException($"no class implementation interface : {@interface.Name}");
        }
    }
}
