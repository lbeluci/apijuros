using ApiJuros.Calculos.Dominio.Interfaces;
using ApiJuros.Calculos.Dominio.Notificacoes;
using ApiJuros.Calculos.Dominio.Servicos;
using ApiJuros.Calculos.Infra.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace ApiJuros.Calculos.Configuracoes
{
    public static class ConfiguracoesDI
    {
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<IServicoCalcularJurosCompostos, ServicoCalcularJurosCompostos>();
            services.AddScoped<IServicoTruncarValores, ServicoTruncarValores>();
            services.AddScoped<IServicoTaxaJuros, ServicoTaxaJuros>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
