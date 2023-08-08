using ApiTabelaFipe.Aplication.Interfaces;
using ApiTabelaFipe.Domain.IRepository;
using ApiTabelaFipe.Infra.Context;
using ApiTabelaFipe.Infra.Network;
using ApiTabelaFipe.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using ApiTabelaFipe.Aplication.Services;

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
            services.AddScoped<IMarcaService, MarcaService>();
            return services;
        }
    }
}
