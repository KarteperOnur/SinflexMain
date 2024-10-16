using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sinflex.DAL.Context;

namespace Sinflex.IOC.DependencyResolvers
{
    public static class ContextService
    {
        public static IServiceCollection AddSinflexContext(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetService<IConfiguration>();

            services.AddDbContext<SinflexContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Sinflex.DAL")));

            return services;
        }
    }
}
