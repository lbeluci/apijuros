using System;

namespace ApiJuros.Calculos.Dominio.Entidades
{
    public class JurosCompostos
    {
        public decimal ValorInicial { get; set; }

        public decimal TaxaJuros { get; set; }

        public int Meses { get; set; }

        public decimal Calcular()
        {
            return ValorInicial * (decimal)Math.Pow(1 + (double)TaxaJuros, Meses);
        }
    }
}