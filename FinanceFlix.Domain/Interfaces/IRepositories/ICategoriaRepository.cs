using FinanceFlix.API.Entities;


namespace FinanceFlix.Domain.Interfaces.IRepositories
{
    public interface ICategoriaRepository
    {
        void Add(Categoria categoria);

        void Update(Categoria categoria);

        void Delete(Categoria categoria);

        Categoria GetById(Guid id);

        IEnumerable<Categoria> GetAll();




    }
}
