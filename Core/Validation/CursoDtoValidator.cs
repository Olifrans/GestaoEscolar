using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
