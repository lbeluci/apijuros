using ApiJuros.Calculos.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace ApiJuros.Calculos.Testes.Controllers
{
    public class CodigoFonteControllerTestes
    {
        private CodigoFonteController _codigoFonteController;

        [SetUp]
        public void Setup()
        {
            _codigoFonteController = new CodigoFonteController();
        }

        [Test]
        public void DeveRetornarAURLOndeSeEncontraOCodigoFonteDasApisNoGit()
        {
            string valorEsperado = "https://github.com/lbeluci/apijuros";

            OkObjectResult resultado = _codigoFonteController.ShowMeTheCode() as OkObjectResult;

            Assert.IsNotNull(resultado);

            Assert.AreEqual(valorEsperado, resultado.Value);
        }
    }
}