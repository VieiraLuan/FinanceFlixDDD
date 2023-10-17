using FinanceFlix.API.Entities;
using FinanceFlix.Domain.Interfaces.IRepositories;
using FinanceFlix.Domain.Interfaces.IServices;

namespace FinanceFlix.Domain.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<bool> Add(Categoria categoria)
        {
            try
            {
                if (categoria != null)
                {
                    return await _categoriaRepository.Add(categoria);

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                //Registro no Log
                return false;

            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                if (!id.Equals(Guid.Empty))
                {
                    return await _categoriaRepository.Delete(id);

                }
                else
                {
                    //Registro no Log
                    return false;
                }

            }
            catch (Exception)
            {
                //Registro no Log
                return false;
            }
        }

        public async Task<ICollection<Categoria>> GetAll()
        {
            try
            {

                return await _categoriaRepository.GetAll();

            }
            catch (Exception)
            {
                //Registro no Log
                return null;
            }
        }

        public async Task<Categoria> GetById(Guid id)
        {
            try
            {
                return await _categoriaRepository.GetById(id);


            }
            catch (Exception)
            {
                //Registro no Log
                return null;
            }
        }

        public async Task<bool> Update(Categoria categoria)
        {
            try
            {
                if (categoria != null)
                {
                    return await _categoriaRepository.Update(categoria);

                }
                else
                {

                    return false;
                }

            }
            catch (Exception)
            {
                //Registro no Log
                return false;
            }
        }
    }
}
