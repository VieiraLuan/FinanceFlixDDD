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

        public bool Add(Categoria categoria)
        {
            if (categoria == null)
            {
                return false;
            }
            _categoriaRepository.Add(categoria);

            return true;
        }

        public bool Delete(Categoria categoria)
        {
            if (categoria.Id == Guid.Empty)
            {
                return false;

            }
            else
            {
                if (_categoriaRepository.GetById(categoria.Id) != null)
                {
                    _categoriaRepository.Delete(categoria);
                    return true;

                }
                else
                {
                    return false;
                }

            }


        }

        public IEnumerable<Categoria> GetAll()
        {
            return _categoriaRepository.GetAll();
        }

        public Categoria GetById(Guid id)
        {
            return _categoriaRepository.GetById(id);

        }

        public bool Update(Categoria categoria)
        {
            if (_categoriaRepository.GetById(categoria.Id) != null)
            {
                _categoriaRepository.Update(categoria);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
