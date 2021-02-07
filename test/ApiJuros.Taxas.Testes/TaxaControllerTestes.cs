using ApiJuros.Taxas.Controllers;
using NUnit.Framework;

namespace ApiJuros.Taxas.Testes
{
    public class TaxaControllerTestes
    {
        TaxaController _taxaController;

        [SetUp]
        public void Setup()
        {
            _taxaController = new TaxaController();
        }

        [Test]
        public void ATaxaDeJurosRetornadaDeveSerDe001()
        {
            string valorEsperado = "0,01";

            string valorAtual = _taxaController.ObterTaxaJuros();

            Assert.AreEqual(valorEsperado, valorAtual);
        }
    }
}