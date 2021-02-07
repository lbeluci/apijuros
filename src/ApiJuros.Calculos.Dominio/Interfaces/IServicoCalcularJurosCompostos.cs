namespace ApiJuros.Calculos.Dominio.Interfaces
{
    public interface IServicoCalcularJurosCompostos
    {
        public decimal CalcularTruncandoEmDuasCasasDecimais(decimal valorInicial, int meses);
    }
}