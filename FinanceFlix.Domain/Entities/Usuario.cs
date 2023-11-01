
using FinanceFlix.Domain.Entities;

namespace FinanceFlix.API.Entities
{
    public class Usuario : Entity
    {

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public string Tipo { get; private set; }

        public string FotoUrl { get; private set; }


        public Usuario()
        {

        }

        //Add
        public Usuario(string nome, string email, string senha, string tipo, string foto)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Tipo = tipo;
            FotoUrl = foto;
        }

        //Edit
        public Usuario(Guid id,DateTime lastModifiedDate, string nome, string email, string senha, string tipo, string foto)
        {
            Id = id;
            LastModifiedDate = lastModifiedDate;
            Nome = nome;
            Email = email;
            Senha = senha;
            Tipo = tipo;
            FotoUrl = foto;
        }

        //Login
        public Usuario(String email, string senha)
        {
            Email = email;
            Senha = senha;
        }


    }
}
