using ApiJuros.Calculos.Dominio.Entidades;
using NUnit.Framework;

namespace ApiJuros.Calculos.Dominio.Testes.Entidades
{
    public class JurosCompostosTestes
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeveCalcularJurosCompostos()
        {
            JurosCompostos jurosCompostos = new JurosCompostos();

            jurosCompostos.ValorInicial = 100;
            jurosCompostos.TaxaJuros = 0.01M;
            jurosCompostos.Meses = 5;

            decimal valorEsperado = 105.10100501m;

            decimal valorAtual = jurosCompostos.Calcular();

            Assert.AreEqual(valorEsperado, valorAtual);
        }
    }
}
