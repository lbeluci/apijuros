using ApiJuros.Calculos.Dominio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ApiJuros.Calculos.Dominio.Notificacoes
{
    public class Notificador : INotificador
    {
        private readonly IList<Notificacao> _notificoes;

        public Notificador()
        {
            _notificoes = new List<Notificacao>();
        }

        public bool TemNotificacoes()
        {
            return _notificoes.Any();
        }

        public IList<Notificacao> ObterNotificacoes()
        {
            return _notificoes;
        }

        public void AdicionarNotificacao(Notificacao notificacao)
        {
            _notificoes.Add(notificacao);
        }
    }
}