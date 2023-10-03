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
                    await _categoriaRepository.Add(categoria);

                    return true;
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
                    if (await _categoriaRepository.Delete(id))
                    {
                        return true;
                    }
                    else
                    {
                        //Registro no Log
                        return false;
                    }
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

                var categorias = await _categoriaRepository.GetAll();
                if (categorias != null)
                {
                    return categorias;
                }
                else
                {
                    //Registro no Log
                    return null;
                }
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
                var categoria = await _categoriaRepository.GetById(id);
                if (categoria != null)
                {
                    return categoria;
                }
                else
                {
                    //Registro no Log
                    return null;
                }

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
                    if (await _categoriaRepository.Update(categoria))
                    {
                        return true;
                    }
                    else
                    {
                        //Registro no Log
                        return false;
                    }
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
    }
}
