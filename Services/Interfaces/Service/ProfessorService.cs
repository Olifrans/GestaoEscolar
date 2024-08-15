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
    public class ProfessorService : Service<Professor, ProfessorDto>, IProfessorService
    {
        public ProfessorService(IProfessorRepository repository, IMapper mapper, IValidator<ProfessorDto> validator)
            : base(repository, mapper, validator) { }
    }

}
