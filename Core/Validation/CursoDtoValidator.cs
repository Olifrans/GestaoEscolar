using Core.DTOs;
using FluentValidation;

namespace Core.Validation
{
    public class CursoDtoValidator : AbstractValidator<CursoDto>
    {
        public CursoDtoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Descricao).NotEmpty().MaximumLength(500);
            RuleFor(x => x.ProfessorId).GreaterThan(0);
        }
    }
}
