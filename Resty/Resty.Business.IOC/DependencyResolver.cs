using Microsoft.Extensions.DependencyInjection;
using Resty.Business.Functionality;

namespace Resty.Business.IOC
{
    public static class DependencyResolver
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.Scan(scan =>
            {
                scan.FromAssemblies(typeof(BaseQueries).Assembly)
                    .AddClasses(c => c.AssignableTo<BaseQueries>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

            services.Scan(scan =>
            {
                scan.FromAssemblies(typeof(BaseCommands).Assembly)
                    .AddClasses(c => c.AssignableTo<BaseCommands>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });
        }
    }
}