using FinanceFlix.API.Entities;


namespace FinanceFlix.Domain.Interfaces.IRepositories
{
    public interface ICategoriaRepository
    {

        Task<bool> Add(Categoria categoria);

        Task<bool> Update(Categoria categoria);

        Task<bool> Delete(Guid id);

        Task<Categoria> GetById(Guid id);

        Task<ICollection<Categoria>> GetAll();

       

    }
}
