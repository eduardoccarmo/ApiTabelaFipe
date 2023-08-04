using Microsoft.Extensions.DependencyInjection;

namespace ApiTabelaFipe.IoC
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ApplicationServiceRepository(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection ApplicationService(this IServiceCollection services)
        {
            return services;
        }
    }
}
