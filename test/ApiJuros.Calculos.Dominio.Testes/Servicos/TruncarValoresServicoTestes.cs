using ApiJuros.Calculos.Dominio.Interfaces;
using ApiJuros.Calculos.Dominio.Servicos;
using NUnit.Framework;

namespace ApiJuros.Calculos.Dominio.Testes.Servicos
{
    public class TruncarValoresServicoTestes
    {
        ITruncarValoresServico _truncarValoresServico;

        [SetUp]
        public void Setup()
        {
            _truncarValoresServico = new TruncarValoresServico();
        }

        [Test]
        public void DeveTruncarUmDecimalEmDuasCasas()
        {
            decimal valorEsperado = 105.10M;

            decimal valorAtual = _truncarValoresServico.TruncarValor(105.10M, 2);

            Assert.AreEqual(valorEsperado, valorAtual);
        }

        [Test]
        public void DeveTruncarUmDecimalEmDuasCasasPositivo()
        {
            decimal valorEsperado = 105.10M;

            decimal valorAtual = _truncarValoresServico.TruncarValor(105.10987654321M, 2);

            Assert.AreEqual(valorEsperado, valorAtual);
        }

        [Test]
        public void DeveTruncarUmDecimalEmDuasCasasNegativo()
        {
            decimal valorEsperado = -105.10M;

            decimal valorAtual = _truncarValoresServico.TruncarValor(-105.10987654321M, 2);

            Assert.AreEqual(valorEsperado, valorAtual);
        }
    }
}
