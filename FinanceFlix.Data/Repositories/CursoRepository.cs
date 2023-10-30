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
                    await _context.Cursos.AddAsync(curso);

                    if (await _context.SaveChangesAsync() > 0)
                    {
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
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

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
                return await _context.Cursos.AsNoTracking().Include(c => c.Categoria).ToListAsync();


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
                if (!id.Equals(Guid.Empty))
                {

                    //Listar cursos por categoria 
                    return (IList<Curso>)await _context.Cursos.AsNoTracking().Include(c => c.Categoria).Where(x => x.Categoria.Id == id).ToListAsync();

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

        public async Task<Curso> GetById(Guid id)
        {


            try
            {
                if (!id.Equals(Guid.Empty))
                {
                    return await _context.Cursos.AsNoTracking().Include(c => c.Categoria).Where(x => x.Id == id).FirstOrDefaultAsync();

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


        public async Task<bool> Update(Curso curso)
        {
            if (curso != null)
            {
                try
                {
                    _context.Cursos.Update(curso);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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
