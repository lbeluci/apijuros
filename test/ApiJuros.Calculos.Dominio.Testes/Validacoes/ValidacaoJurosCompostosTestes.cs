using ApiJuros.Calculos.Dominio.Entidades;
using ApiJuros.Calculos.Dominio.Validacoes;
using FluentValidation.Results;
using NUnit.Framework;

namespace ApiJuros.Calculos.Dominio.Testes.Validacoes
{
    public class ValidacaoJurosCompostosTestes
    {
        private ValidacaoJurosCompostos _validacaoJurosCompostos;
        private JurosCompostos _jurosCompostos;

        [SetUp]
        public void Setup()
        {
            _validacaoJurosCompostos = new ValidacaoJurosCompostos();

            _jurosCompostos = new JurosCompostos { ValorInicial = 100, TaxaJuros = 0.01M, Meses = 5 };
        }

        [Test]
        public void DeveValidarValorInicialMaiorDoQueZero()
        {
            _jurosCompostos.ValorInicial = 0;

            ValidationResult resultado = _validacaoJurosCompostos.Validate(_jurosCompostos);

            Assert.IsFalse(resultado.IsValid);
        }

        [Test]
        public void DeveValidarTaxaJurosMaiorOuIgualZero()
        {
            _jurosCompostos.TaxaJuros = -0.01M;

            ValidationResult resultado = _validacaoJurosCompostos.Validate(_jurosCompostos);

            Assert.IsFalse(resultado.IsValid);
        }

        [Test]
        public void DeveValidarMesesMaiorDoQueZero()
        {
            _jurosCompostos.Meses = 0;

            ValidationResult resultado = _validacaoJurosCompostos.Validate(_jurosCompostos);

            Assert.IsFalse(resultado.IsValid);
        }
    }
}