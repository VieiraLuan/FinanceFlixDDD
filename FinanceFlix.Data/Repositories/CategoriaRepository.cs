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
            if (categoria == null)
            {
                //Registro no Log
                return false;
            }
            try
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
                return true;
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

        public async Task<bool> Delete(Categoria categoria)
        {
            if (categoria == null)
            {
                return false;

            }
            try
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                //Registro no Log
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);   
                return false;
            }
        }

        public async Task<ICollection<Categoria>> GetAll()
        {

            try
            {
               var categorias =  await _context.Categorias.ToListAsync();

                if(categorias == null)
                {
                    //Registro no Log
                    return null;
                }
                else
                {
                    return categorias;
                }
            }
            catch (Exception ex)
            {
                // Registro no Log
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        

        public async Task<Categoria> GetById(int id)
        {
            if (id != null)
            {
                try
                {
                    var categoria = await _context.Categorias.FindAsync(id);

                    if(categoria == null)
                    {
                        //Registro no Log
                        return null;
                    }
                    else
                    {
                        return categoria;
                    }   
                }
                catch (Exception ex)
                {
                    //Registro no Log
                    return null;
                }
            }
            else
            {
                return null;
            }
            
        }

        public async Task<bool> Update(Categoria categoria)
        {
            if (categoria == null)
            {
                //Registro no Log
                return false;
            }

            try
            {
                _context.Categorias.Update(categoria);
                await _context.SaveChangesAsync();
                return true;
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
