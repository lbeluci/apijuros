using ApiJuros.Calculos.Dominio.Interfaces;
using System;

namespace ApiJuros.Calculos.Dominio.Servicos
{
    public class CalcularJurosCompostosServico : ICalcularJurosCompostosServico
    {
        private readonly ITruncarValoresServico _truncarValoresServico;

        public CalcularJurosCompostosServico(ITruncarValoresServico truncarValoresServico)
        {
            _truncarValoresServico = truncarValoresServico;
        }

        public decimal CalcularTruncandoEmDuasCasasDecimais(decimal valorInicial, decimal taxaJuros, int meses)
        {
            decimal valorComJuros = valorInicial * (decimal)Math.Pow(1 + (double)taxaJuros, meses);

            return _truncarValoresServico.TruncarValor(valorComJuros, 2);
        }
    }
}