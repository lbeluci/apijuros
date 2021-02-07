using ApiJuros.Calculos.Dominio.Interfaces;
using System;

namespace ApiJuros.Calculos.Dominio.Servicos
{
    public class ServicoTruncarValores : IServicoTruncarValores
    {
        public decimal TruncarValor(decimal valor, byte decimais)
        {
            decimal valorArredondado = Math.Round(valor, decimais);

            if (valor > 0 && valorArredondado > valor)
            {
                return valorArredondado - new decimal(1, 0, 0, false, decimais);
            }
            
            if (valor < 0 && valorArredondado < valor)
            {
                return valorArredondado + new decimal(1, 0, 0, false, decimais);
            }

            return valorArredondado;
        }
    }
}