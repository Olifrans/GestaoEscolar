using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validation
{
    public class AlunoDtoValidator : AbstractValidator<AlunoDto>
    {
        public AlunoDtoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
            RuleFor(x => x.DataNascimento).NotEmpty().LessThan(DateTime.Now);
            RuleFor(x => x.EscolaId).GreaterThan(0);
        }
    }
}
