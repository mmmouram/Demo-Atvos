using Microsoft.Extensions.DependencyInjection;
using MyApp.Repositories;
using MyApp.Services;

namespace MyApp.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            return services;
        }
    }
}
