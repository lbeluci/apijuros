using ApiJuros.Calculos.Dominio.Interfaces;
using ApiJuros.Calculos.Dominio.Notificacoes;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace ApiJuros.Calculos.Dominio.Servicos
{
    public abstract class ServicoBase
    {
        private readonly INotificador _notificador;

        protected ServicoBase(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult resultadoValidacao)
        {
            resultadoValidacao.Errors.ToList().ForEach((e) => { Notificar(e.ErrorMessage); });
        }

        protected void Notificar(string mensagem)
        {
            _notificador.AdicionarNotificacao(new Notificacao(mensagem));
        }

        protected bool Validar<V, T>(V validacao, T entidade) where V : AbstractValidator<T>
        {
            var resultadoValidacao = validacao.Validate(entidade);

            Notificar(resultadoValidacao);

            return resultadoValidacao.IsValid;
        }
    }
}