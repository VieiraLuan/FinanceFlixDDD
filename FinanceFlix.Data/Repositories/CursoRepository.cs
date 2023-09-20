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
                    await Console.Out.WriteLineAsync(ex.Message + "ERRO LSV");
                    return false;
                }
            }
            else
            {
                //TODO: Implementar log
                return false;
            }
        }

        public async Task<bool> Delete(Curso curso)
        {
            if (curso != null)
            {
                try
                {
                    _context.Cursos.Remove(curso);
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

        public async Task<IList<Curso>> GetAll()
        {
            try
            {
                return await _context.Cursos.ToListAsync();
            }
            catch (Exception ex)
            {
                //TODO: Implementar log
                return null;
            }
        }

        public async Task<IList<Curso>> GetByCategoria(int id)
        {
            try
            {
                if (id != null)
                {
                   //Listar cursos por categoria 
                   var cursos = await _context.Cursos.Include(c => c.Categoria).Where(c => c.Categoria.Id == id).ToListAsync();

                    if(cursos != null)
                    {
                        return cursos;
                    }
                    else
                    {
                        return null;
                    }

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

        public async Task<Curso?> GetById(int id)
        {
            if (id != null)
            {
                try
                {
                    return await _context.Cursos.FindAsync(id);
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
