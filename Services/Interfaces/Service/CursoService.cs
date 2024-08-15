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
    public class CursoService : Service<Curso, CursoDto>, ICursoService
    {
        public CursoService(ICursoRepository repository, IMapper mapper, IValidator<CursoDto> validator)
            : base(repository, mapper, validator) { }
    }
}
