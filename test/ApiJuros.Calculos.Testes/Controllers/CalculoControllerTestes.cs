using ApiJuros.Calculos.Controllers;
using ApiJuros.Calculos.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ApiJuros.Calculos.Testes.Controllers
{
    public class CalculoControllerTestes
    {
        private Mock<IServicoCalcularJurosCompostos> _mockCalcularJurosCompostosServico;
        private Mock<INotificador> _mockNotificador;

        private CalculoController _calculoController;

        private string _valorEsperado;
        private decimal _valorInicial;
        private int _meses;
        private decimal _valorCalculado;

        [SetUp]
        public void Setup()
        {
            _mockCalcularJurosCompostosServico = new Mock<IServicoCalcularJurosCompostos>();
            _mockNotificador = new Mock<INotificador>();
            
            _valorEsperado = "105,10";
            _valorInicial = 100;
            _meses = 5;
            _valorCalculado = 105.10M;

            _mockCalcularJurosCompostosServico.Setup(x => x.CalcularTruncandoEmDuasCasasDecimais(_valorInicial, _meses)).Returns(_valorCalculado);
        }

        [Test]
        public void DeveRetornarOValor10510()
        {
            _calculoController = new CalculoController(_mockCalcularJurosCompostosServico.Object, _mockNotificador.Object);

            OkObjectResult resultado = _calculoController.CalcularJuros(_valorInicial, _meses) as OkObjectResult;

            Assert.IsNotNull(resultado);

            Assert.AreEqual(resultado.StatusCode, 200);

            Assert.AreEqual(_valorEsperado, resultado.Value);
        }

        [Test]
        public void DeveRetornarBadRequest()
        {
            _mockNotificador.Setup(n => n.TemNotificacoes()).Returns(true);

            _calculoController = new CalculoController(_mockCalcularJurosCompostosServico.Object, _mockNotificador.Object);

            BadRequestObjectResult resultado = _calculoController.CalcularJuros(_valorInicial, _meses) as BadRequestObjectResult;

            Assert.IsNotNull(resultado);

            Assert.AreEqual(resultado.StatusCode, 400);
        }
    }
}