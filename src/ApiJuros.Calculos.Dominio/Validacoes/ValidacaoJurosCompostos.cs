using ApiJuros.Calculos.Dominio.Entidades;
using FluentValidation;

namespace ApiJuros.Calculos.Dominio.Validacoes
{
    public class ValidacaoJurosCompostos : AbstractValidator<JurosCompostos>
    {
        public ValidacaoJurosCompostos()
        {
            RuleFor(j => j.ValorInicial).GreaterThan(0).WithMessage("O valor inicial deve ser maior do que zero.");
            RuleFor(j => j.TaxaJuros).GreaterThanOrEqualTo(0).WithMessage("A taxa de juros não pode ser menor do que zero.");
            RuleFor(j => j.Meses).GreaterThan(0).WithMessage("O número de meses deve ser maior do que zero.");
        }
    }
}