using AutoMapper;
using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Aluno, AlunoDto>().ReverseMap();
            CreateMap<Escola, EscolaDto>().ReverseMap();
            CreateMap<Professor, ProfessorDto>().ReverseMap();
            CreateMap<Curso, CursoDto>().ReverseMap();
        }
    }
}
    