using FinanceFlix.API.Entities;


namespace FinanceFlix.Domain.Interfaces.IRepositories
{
    public interface ICategoriaRepository
    {

        Task<bool> Add(Video categoria);

        Task<bool> Update(Video categoria);

        Task<bool> Delete(Video categoria);

        Task<Video> GetById(Guid id);

        Task<IList<Video>> GetAll();

    }
}
