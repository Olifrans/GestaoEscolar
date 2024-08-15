using Core.DTOs;
using FluentValidation;

namespace Core.Validation
{
    public class EscolaDtoValidator : AbstractValidator<EscolaDto>
    {
        public EscolaDtoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Endereco).NotEmpty().MaximumLength(200);
        }
    }
}
