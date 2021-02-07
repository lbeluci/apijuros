namespace ApiJuros.Calculos.Dominio.Interfaces
{
    public interface ITruncarValoresServico
    {
        public decimal TruncarValor(decimal valor, byte decimais);
    }
}