using ApiJuros.Calculos.Dominio.Interfaces;
using ApiJuros.Calculos.Dominio.Servicos;
using NUnit.Framework;

namespace ApiJuros.Calculos.Dominio.Testes.Servicos
{
    public class ServicoTruncarValoresTestes
    {
        IServicoTruncarValores _servicoTruncarValores;

        [SetUp]
        public void Setup()
        {
            _servicoTruncarValores = new ServicoTruncarValores();
        }

        [Test]
        public void DeveTruncarUmValorDecimalEmDuasCasas()
        {
            decimal valorEsperado = 105.10M;

            decimal valorAtual = _servicoTruncarValores.TruncarValor(105.10M, 2);

            Assert.AreEqual(valorEsperado, valorAtual);
        }

        [Test]
        public void DeveTruncarUmValorDecimalPositivoEmDuasCasas()
        {
            decimal valorEsperado = 105.10M;

            decimal valorAtual = _servicoTruncarValores.TruncarValor(105.10987654321M, 2);

            Assert.AreEqual(valorEsperado, valorAtual);
        }

        [Test]
        public void DeveTruncarUmDecimalNegativoEmDuasCasas()
        {
            decimal valorEsperado = -105.10M;

            decimal valorAtual = _servicoTruncarValores.TruncarValor(-105.10987654321M, 2);

            Assert.AreEqual(valorEsperado, valorAtual);
        }
    }
}
