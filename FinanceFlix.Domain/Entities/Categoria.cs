using FinanceFlix.Domain.Entities;


namespace FinanceFlix.API.Entities
{
    public class Categoria : Entity
    {

        public Categoria(Guid id, string nome, string descricao, ICollection<Curso>? cursos)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Cursos = cursos;
        }

        public Categoria(string nome, string descricao, ICollection<Curso>? cursos)
        {

            Nome = nome;
            Descricao = descricao;
            Cursos = cursos;
        }

        Categoria()
        {
        }


        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public ICollection<Curso>? Cursos { get; private set; }


    }
}