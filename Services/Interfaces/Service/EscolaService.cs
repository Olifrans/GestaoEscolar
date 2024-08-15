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
    public class EscolaService : Service<Escola, EscolaDto>, IEscolaService
    {
        public EscolaService(IEscolaRepository repository, IMapper mapper, IValidator<EscolaDto> validator)
            : base(repository, mapper, validator) { }
    }
}
