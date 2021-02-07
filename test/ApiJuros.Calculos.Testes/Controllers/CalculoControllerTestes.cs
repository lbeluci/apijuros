using ApiJuros.Calculos.Controllers;
using ApiJuros.Calculos.Dominio.Interfaces;
using Moq;
using NUnit.Framework;

namespace ApiJuros.Calculos.Testes.Controllers
{
    public class CalculoControllerTestes
    {
        private Mock<ICalcularJurosCompostosServico> _mockCalcularJurosCompostosServico;

        private CalculoController _calculoController;

        [SetUp]
        public void Setup()
        {
            _mockCalcularJurosCompostosServico = new Mock<ICalcularJurosCompostosServico>();
        }

        [Test]
        public void OValorCalculadoComJurosDeveSerDe10510()
        {
            decimal valorInicial = 100;
            decimal taxaJuros = 0.01M;
            int meses = 5;
            decimal valorCalculado = 105.10M;

            _mockCalcularJurosCompostosServico.Setup(x => x.CalcularTruncandoEmDuasCasasDecimais(valorInicial, taxaJuros, meses)).Returns(valorCalculado);

            _calculoController = new CalculoController(_mockCalcularJurosCompostosServico.Object);

            string valorAtual = _calculoController.CalcularJuros(valorInicial, meses);

            string valorEsperado = "105,10";

            Assert.AreEqual(valorEsperado, valorAtual);
        }
    }
}