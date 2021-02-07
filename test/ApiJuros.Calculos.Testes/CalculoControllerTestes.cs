using ApiJuros.Calculos.Controllers;
using NUnit.Framework;

namespace ApiJuros.Calculos.Testes
{
    public class CalculoControllerTestes
    {
        private CalculoController _calculoController;

        [SetUp]
        public void Setup()
        {
            _calculoController = new CalculoController();
        }

        [Test]
        public void OValorCalculadoComJurosDeveSerDe10510()
        {
            string valorEsperado = "105,10";

            decimal valorInicial = 100;

            int meses = 5;

            string valorAtual = _calculoController.CalcularJuros(valorInicial, meses);

            Assert.AreEqual(valorEsperado, valorAtual);
        }
    }
}