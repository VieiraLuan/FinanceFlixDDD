using FinanceFlix.API.Entities;


namespace FinanceFlix.Domain.Interfaces.IRepositories
{
    public interface ICursoRepository
    {

        Task<bool> Add(Curso categoria);

        Task<bool> Update(Curso categoria);

        Task<bool> Delete(Guid id);

        Task<Curso> GetById(Guid id);

        Task<IList<Curso>> GetAll();

        Task<IList<Curso>> GetByCategoria(Guid id);

    }
}
