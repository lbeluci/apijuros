namespace ApiJuros.Calculos.Dominio.Interfaces
{
    public interface ICalcularJurosCompostosServico
    {
        public decimal CalcularTruncandoEmDuasCasasDecimais(decimal valorInicial, decimal taxaJuros, int meses);
    }
}