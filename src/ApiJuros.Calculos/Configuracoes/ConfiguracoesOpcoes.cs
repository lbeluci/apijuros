using ApiJuros.Calculos.Dominio.Opcoes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiJuros.Calculos.Configuracoes
{
    public static class ConfiguracoesOpcoes
    {
        public static IServiceCollection ConfigurarOpcoes(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OpcoesTaxaJuros>(configuration.GetSection("TaxaJurosOpcoes"));

            return services;
        }
    }
}