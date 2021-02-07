namespace ApiJuros.Calculos.Dominio.Interfaces
{
    public interface IServicoTruncarValores
    {
        public decimal TruncarValor(decimal valor, byte decimais);
    }
}