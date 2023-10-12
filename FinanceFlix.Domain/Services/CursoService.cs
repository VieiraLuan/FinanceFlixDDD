using FinanceFlix.API.Entities;
using FinanceFlix.Domain.Interfaces.IRepositories;
using FinanceFlix.Domain.Interfaces.IServices;


namespace FinanceFlix.Domain.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;


        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;

        }

        public async Task<bool> Add(Curso curso)
        {

            try
            {
                if (curso != null)
                {
                    return await _cursoRepository.Add(curso);


                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                //TODO: Implementar log
                return false;
            }


        }

        public async Task<bool> Delete(Guid id)
        {

            try
            {
                if (!id.Equals(Guid.Empty))
                {

                    return await _cursoRepository.Delete(id);

                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                //TODO: Implementar log
                return false;
            }
        }

        public async Task<IList<Curso>> GetAll()
        {
            try
            {
                return await _cursoRepository.GetAll();
            }
            catch (Exception)
            {
                //TODO: Implementar log
                return null;
            }
        }

        public async Task<Curso> GetById(Guid id)
        {
            try
            {
                return await _cursoRepository.GetById(id);
            }
            catch (Exception)
            {
                //TODO: Implementar log
                return null;

            }
        }

        public async Task<bool> Update(Curso curso)
        {
            try
            {

                if (curso == null)
                {
                    return false;
                }

                return await _cursoRepository.Update(curso);


            }
            catch (Exception)
            {
                //TODO: Implementar log
                return false;
            }
        }

        public async Task<IList<Curso>> GetByCategoriaCurso(Guid id)
        {
            try
            {
                return await _cursoRepository.GetByCategoria(id);

            }
            catch (Exception)
            {
                //todo: implementar log
                return null;
            }
        }


    }
}

