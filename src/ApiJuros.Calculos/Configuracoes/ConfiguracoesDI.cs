using ApiJuros.Calculos.Dominio.Interfaces;
using ApiJuros.Calculos.Dominio.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace ApiJuros.Calculos.Configuracoes
{
    public static class ConfiguracoesDI
    {
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<ICalcularJurosCompostosServico, CalcularJurosCompostosServico>();
            services.AddScoped<ITruncarValoresServico, TruncarValoresServico>();

            return services;
        }
    }
}
