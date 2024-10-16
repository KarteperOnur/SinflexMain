using Microsoft.Extensions.DependencyInjection;
using Sinflex.BLL.Repositories.Abstracts;
using Sinflex.BLL.Repositories.Abstracts.BaseAbstract;
using Sinflex.BLL.Repositories.Concretes;
using Sinflex.BLL.Repositories.Concretes.BaseConcrete;

namespace Sinflex.IOC.DependencyResolvers
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ISaloonService, SaloonService>();
            services.AddScoped<ISeatService, SeatService>();
            services.AddScoped<ITicketService, TicketService>();
            return services;
        }
    }
}
