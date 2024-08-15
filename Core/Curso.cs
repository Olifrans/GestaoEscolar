using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Curso
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }
        public List<Aluno>? Alunos { get; set; }
    }
}
