using Core.DTOs;
using FluentValidation;

namespace Core.Validation
{
    public class ProfessorDtoValidator : AbstractValidator<ProfessorDto>
    {
        public ProfessorDtoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Especialidade).NotEmpty().MaximumLength(100);
            RuleFor(x => x.EscolaId).GreaterThan(0);
        }
    }
}
