using ApiJuros.Calculos.Controllers;
using NUnit.Framework;

namespace ApiJuros.Calculos.Testes
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

            string valorAtual = _codigoFonteController.ShowMeTheCode();

            Assert.AreEqual(valorEsperado, valorAtual);
        }
    }
}
