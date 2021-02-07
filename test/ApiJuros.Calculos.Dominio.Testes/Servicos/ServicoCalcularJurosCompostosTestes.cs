using ApiJuros.Calculos.Dominio.Interfaces;
using ApiJuros.Calculos.Dominio.Servicos;
using Moq;
using NUnit.Framework;
using System;

namespace ApiJuros.Calculos.Dominio.Testes.Servicos
{
    public class ServicoCalcularJurosCompostosTestes
    {
        private Mock<IServicoTaxaJuros> _mockServicoTaxaJuros;
        private Mock<IServicoTruncarValores> _mockServicoTruncarValores;
        private Mock<INotificador> _mockNotificador;

        private IServicoCalcularJurosCompostos _servicoCalcularJurosCompostos;

        [SetUp]
        public void Setup()
        {
            _mockServicoTaxaJuros = new Mock<IServicoTaxaJuros>();
            _mockServicoTruncarValores = new Mock<IServicoTruncarValores>();
            _mockNotificador = new Mock<INotificador>();
        }

        [Test]
        public void DeveTruncarUmDecimalEmDuasCasas()
        {
            decimal taxaJuros = 0.01M;

            _mockServicoTaxaJuros.Setup(x => x.ObterTaxaJuros()).Returns(taxaJuros);

            decimal valorCalculado = 105.1010050100M;
            byte decimais = 2;
            decimal valorTruncado = 105.10M;

            _mockServicoTruncarValores.Setup(x => x.TruncarValor(valorCalculado, decimais)).Returns(valorTruncado);

            _servicoCalcularJurosCompostos = new ServicoCalcularJurosCompostos(_mockServicoTaxaJuros.Object, _mockServicoTruncarValores.Object, _mockNotificador.Object);

            decimal valorInicial = 100;
            int meses = 5;

            decimal valorAtual = _servicoCalcularJurosCompostos.CalcularTruncandoEmDuasCasasDecimais(valorInicial, meses);

            decimal valorEsperado = 105.10M;

            Assert.AreEqual(valorEsperado, valorAtual);
        }

        [Test]
        public void DeveRetornarZeroQuandoNaoForPossivelRecuperarTaxaJuros()
        {
            _mockServicoTaxaJuros.Setup(x => x.ObterTaxaJuros()).Throws(new Exception());

            _servicoCalcularJurosCompostos = new ServicoCalcularJurosCompostos(_mockServicoTaxaJuros.Object, _mockServicoTruncarValores.Object, _mockNotificador.Object);

            decimal valorAtual = _servicoCalcularJurosCompostos.CalcularTruncandoEmDuasCasasDecimais(0, 0);

            decimal valorEsperado = 0;

            Assert.AreEqual(valorEsperado, valorAtual);
        }

        [Test]
        public void DeveRetornarZeroQuandoJurosCompostosForInvalido()
        {
            decimal taxaJuros = 0.01M;

            _mockServicoTaxaJuros.Setup(x => x.ObterTaxaJuros()).Returns(taxaJuros);

            _servicoCalcularJurosCompostos = new ServicoCalcularJurosCompostos(_mockServicoTaxaJuros.Object, _mockServicoTruncarValores.Object, _mockNotificador.Object);

            decimal valorAtual = _servicoCalcularJurosCompostos.CalcularTruncandoEmDuasCasasDecimais(0, 0);

            decimal valorEsperado = 0;

            Assert.AreEqual(valorEsperado, valorAtual);
        }
    }
}