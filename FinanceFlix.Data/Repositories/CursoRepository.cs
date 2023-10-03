using FinanceFlix.API.Entities;
using FinanceFlix.Data.Context;
using FinanceFlix.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace FinanceFlix.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {

        private readonly DataContext _context;

        public CursoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Curso curso)
        {
            if (curso != null)
            {
                try
                {
                    _context.Cursos.Add(curso);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    //TODO: Implementar log

                    return false;
                }
            }
            else
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
                    var curso = await _context.Cursos.FindAsync(id);
                    _context.Cursos.Remove(curso);
                    await _context.SaveChangesAsync();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //TODO: Implementar log
                return false;
            }


        }

        public async Task<IList<Curso>> GetAll()
        {
            try
            {
                var cursos = await _context.Cursos.Include(c => c.Categoria).ToListAsync();

                if (cursos != null)
                {
                    return cursos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //TODO: Implementar log
                return null;
            }
        }

        public async Task<IList<Curso>> GetByCategoria(Guid id)
        {
            try
            {

                //Listar cursos por categoria 
                var cursos = await _context.Cursos.Where(x => x.Categoria.Id == id).ToListAsync();



                return (IList<Curso>)cursos;


            }
            catch (Exception ex)
            {
                //TODO: Implementar log
                return null;
            }
        }

        public async Task<Curso> GetById(Guid id)
        {
            if (id != null)
            {
                try
                {
                    var curso = await _context.Cursos.Include(c => c.Categoria).Where(x => x.Id == id).FirstOrDefaultAsync();

                    if (curso != null)
                    {
                        return curso;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    //TODO: Implementar log
                    return null;
                }
            }
            else
            {
                //TODO: Implementar log
                return null;
            }

        }


        public async Task<bool> Update(Curso curso)
        {
            if (curso != null)
            {
                try
                {
                    _context.Cursos.Update(curso);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }
}
