using ApiJuros.Calculos.Dominio.Entidades;
using ApiJuros.Calculos.Dominio.Interfaces;
using ApiJuros.Calculos.Dominio.Validacoes;
using System;

namespace ApiJuros.Calculos.Dominio.Servicos
{
    public class ServicoCalcularJurosCompostos : ServicoBase, IServicoCalcularJurosCompostos
    {
        private readonly IServicoTaxaJuros _taxaJurosServico;
        private readonly IServicoTruncarValores _truncarValoresServico;

        public ServicoCalcularJurosCompostos(IServicoTaxaJuros taxaJurosServico, IServicoTruncarValores truncarValoresServico, INotificador notificador) : base(notificador)
        {
            _taxaJurosServico = taxaJurosServico;
            _truncarValoresServico = truncarValoresServico;
        }

        public decimal CalcularTruncandoEmDuasCasasDecimais(decimal valorInicial, int meses)
        {
            decimal taxaJuros;

            try
            {
                taxaJuros = _taxaJurosServico.ObterTaxaJuros();
            }
            catch (Exception exception)
            {
                Notificar(string.Format("Não foi possível obter uma taxa de juros: {0}", exception.Message));

                return 0;
            }

            JurosCompostos jurosCompostos = new JurosCompostos { ValorInicial = valorInicial, TaxaJuros = taxaJuros, Meses = meses };

            if (!Validar(new ValidacaoJurosCompostos(), jurosCompostos))
            {
                return 0;
            }

            decimal valorCalculado = jurosCompostos.Calcular();

            decimal valorTruncado = _truncarValoresServico.TruncarValor(valorCalculado, 2);

            return valorTruncado;
        }
    }
}