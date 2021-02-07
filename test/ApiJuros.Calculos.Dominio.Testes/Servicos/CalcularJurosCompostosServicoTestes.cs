using ApiJuros.Calculos.Dominio.Interfaces;
using ApiJuros.Calculos.Dominio.Servicos;
using Moq;
using NUnit.Framework;

namespace ApiJuros.Calculos.Dominio.Testes.Servicos
{
    public class CalcularJurosCompostosServicoTestes
    {
        private Mock<ITruncarValoresServico> _mockTruncarValoresServico;

        ICalcularJurosCompostosServico _calcularJurosCompostosServico;

        [SetUp]
        public void Setup()
        {
            _mockTruncarValoresServico = new Mock<ITruncarValoresServico>();
        }

        [Test]
        public void DeveTruncarUmDecimalEmDuasCasas()
        {
            decimal valorCalculado = 105.1010050100M;
            byte decimais = 2;
            decimal valorTruncado = 105.10M;

            _mockTruncarValoresServico.Setup(x => x.TruncarValor(valorCalculado, decimais)).Returns(valorTruncado);

            _calcularJurosCompostosServico = new CalcularJurosCompostosServico(_mockTruncarValoresServico.Object);

            decimal valorInicial = 100;
            decimal taxaJuros = 0.01M;
            int meses = 5;

            decimal valorAtual = _calcularJurosCompostosServico.CalcularTruncandoEmDuasCasasDecimais(valorInicial, taxaJuros, meses);

            decimal valorEsperado = 105.10M;

            Assert.AreEqual(valorEsperado, valorAtual);
        }
    }
}
