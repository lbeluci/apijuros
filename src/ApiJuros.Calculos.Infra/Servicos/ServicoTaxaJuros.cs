using ApiJuros.Calculos.Dominio.Interfaces;
using ApiJuros.Calculos.Dominio.Opcoes;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace ApiJuros.Calculos.Infra.Servicos
{
    public class ServicoTaxaJuros : IServicoTaxaJuros
    {
        private readonly OpcoesTaxaJuros _taxaJurosOpcoes;

        public ServicoTaxaJuros(IOptions<OpcoesTaxaJuros> taxaJurosOpcoes)
        {
            _taxaJurosOpcoes = taxaJurosOpcoes.Value;
        }

        public decimal ObterTaxaJuros()
        {
            using HttpClient client = new HttpClient();

            using HttpResponseMessage responseMessage = client.GetAsync(_taxaJurosOpcoes.UrlServicoTaxaJuros).Result;

            string content = responseMessage.Content.ReadAsStringAsync().Result;

            decimal.TryParse(content, out decimal taxaJuros);

            return taxaJuros;
        }
    }
}