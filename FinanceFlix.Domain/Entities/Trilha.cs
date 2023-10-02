

namespace FinanceFlix.Domain.Entities
{
    
    public class Trilha
    {
        public Trilha(int id, string nome, string descricao /*ICollection<CursoTrilha>?cursosTrilhas*/)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            //CursosTrilhas = cursosTrilhas;
        }

        public Trilha()
        {
        }

   

        public int Id { get; private set; }

  
        public string Nome { get; private  set; }

      

        public string Descricao { get; private set; }

       // public ICollection<CursoTrilha>? CursosTrilhas { get; private set; }
    }
}
