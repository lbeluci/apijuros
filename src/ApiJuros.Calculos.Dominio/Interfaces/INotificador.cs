using ApiJuros.Calculos.Dominio.Notificacoes;
using System.Collections.Generic;

namespace ApiJuros.Calculos.Dominio.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacoes();

        IList<Notificacao> ObterNotificacoes();

        void AdicionarNotificacao(Notificacao notificacao);
    }
}