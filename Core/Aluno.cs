namespace Core
{
    public class Aluno
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaId { get; set; }
        public Escola? Escola { get; set; }
        public List<Curso>? Cursos { get; set; }
    }
}
