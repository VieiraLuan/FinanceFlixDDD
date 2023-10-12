using FinanceFlix.API.Entities;
using FinanceFlix.Data.Context;
using FinanceFlix.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace FinanceFlix.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _context;

        public CategoriaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Categoria categoria)
        {
            try
            {

                if (categoria == null)
                {

                    return false;
                }

                _context.Categorias.Add(categoria);

                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (DbUpdateException ex)
            {
                //Registro no Log
                return false;
            }
            catch (Exception ex)
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
                    var categoria = await _context.Categorias.FindAsync(id);

                    if (categoria != null)
                    {
                        _context.Categorias.Remove(categoria);

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
                else
                {
                    return false;
                }
            }
            catch (DbUpdateException ex)
            {
                //Registro no Log
                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<ICollection<Categoria>> GetAll()
        {

            try
            {
                return await _context.Categorias.AsNoTracking().ToListAsync();


            }
            catch (Exception ex)
            {
                // Registro no Log
                return null;
            }

        }

        public async Task<Categoria> GetById(Guid id)
        {

            try
            {
                if (!id.Equals(Guid.Empty))
                {
                    return await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
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
                    _context.Categorias.Update(categoria);


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
            catch (DbUpdateException ex)
            {
                //Registro no Log
                return false;
            }
            catch (Exception ex)
            {
                //Registro no Log
                return false;
            }
        }

    }
}
