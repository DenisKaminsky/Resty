using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Resty.Data.IOC
{
    public static class DependencyResolver
    {
        public static void AddDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RestyDbContext>(options => options.UseNpgsql(connectionString));
        }
    }
}