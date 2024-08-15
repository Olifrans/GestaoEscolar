using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validation
{
    internal class ProfessorDtoValidator : AbstractValidator<ProfessorDto>
    {
        public ProfessorDtoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Especialidade).NotEmpty().MaximumLength(100);
            RuleFor(x => x.EscolaId).GreaterThan(0);
        }
    }
}
