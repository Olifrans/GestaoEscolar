using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Professor
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Especialidade { get; set; }
        public int EscolaId { get; set; }
        public Escola? Escola { get; set; }
        public List<Curso>? Cursos { get; set; }
    }
}
