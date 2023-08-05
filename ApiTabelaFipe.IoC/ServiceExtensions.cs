using ApiTabelaFipe.Domain.IRepository;
using ApiTabelaFipe.Infra.Context;
using ApiTabelaFipe.Infra.Network;
using ApiTabelaFipe.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTabelaFipe.IoC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ApplicationServiceRepository(this IServiceCollection services)
        {
            services.AddDbContext<ApiContext>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            return services;
        }

        public static IServiceCollection ApplicationService(this IServiceCollection services)
        { 
            services.AddHttpClient<IHttpServiceFipe, HttpServiceFipe>();
            return services;
        }
    }
}
