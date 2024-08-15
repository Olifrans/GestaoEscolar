using AutoMapper;
using Core.DTOs;
using Core;
using FluentValidation;
using Services.Interfaces.InterfacesServices;
using Services.Repositorios.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.Service
{
    public class AlunoService : Service<Aluno, AlunoDto>, IAlunoService
    {
        public AlunoService(IAlunoRepository repository, IMapper mapper, IValidator<AlunoDto> validator)
            : base(repository, mapper, validator) { }
    }
}
