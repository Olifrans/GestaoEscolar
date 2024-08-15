using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
