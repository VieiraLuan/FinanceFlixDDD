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
            if (curso == null)
            {
                return false;
            }
            try
            {
                await _cursoRepository.Add(curso);
                return true;
            }
            catch (Exception)
            {
                //TODO: Implementar log
                return false;
            }


        }

        public async Task<bool> Delete(Curso curso)
        {
            if (curso == null)
            {
                return false;
            }
            try
            {
                await _cursoRepository.Delete(curso);
                return true;
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

        public async Task<Curso> GetById(int id)
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
            if (curso == null)
            {
                return false;
            }
            try
            {
                await _cursoRepository.Update(curso);
                return true;
            }
            catch (Exception)
            {
                //TODO: Implementar log
                return false;
            }
        }

        public async Task<IList<Curso>> GetByCategoriaCurso(int id)
        {
            try
            {
                if (id != null)
                {
                    var cursos = await _cursoRepository.GetByCategoria(id);

                    if (cursos == null)
                    {
                        return null;
                    }
                    else
                    {
                        return cursos;
                    }

                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                //todo: implementar log
                return null;
            }
        }

 
    }
}

