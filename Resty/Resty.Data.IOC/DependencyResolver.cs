using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Resty.Data.Interfaces;
using Resty.Data.Repositories;

namespace Resty.Data.IOC
{
    public static class DependencyResolver
    {
        public static void AddDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RestyDbContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Scan(scan =>
            {
                scan.FromAssemblies(typeof(RestyDbContext).Assembly)
                    .AddClasses(c => c.AssignableTo<BaseRepository>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });
        }
    }
}