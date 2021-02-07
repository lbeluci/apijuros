using ApiJuros.Taxas.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ApiJuros.Taxas.Testes.Controllers
{
    public class TaxaControllerTestes
    {
        private TaxaController _taxaController;

        [SetUp]
        public void Setup()
        {
            _taxaController = new TaxaController();
        }

        [Test]
        public void DeveRetornarOValor001()
        {
            string valorEsperado = "0,01";

            OkObjectResult resultado = _taxaController.ObterTaxaJuros() as OkObjectResult;

            Assert.IsNotNull(resultado);

            Assert.AreEqual(valorEsperado, resultado.Value);
        }
    }
}
