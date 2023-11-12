using FinanceFlix.API.Entities;
using FinanceFlix.Data.Context;
using FinanceFlix.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

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
                    Log.Logger.Information("Categoria persistida com sucesso, ID: " + categoria.Id);


                    return true;
                }
                else
                {
                    Log.Logger.Error($"Falha na persistência dos dados \n " +
                        $"ID: {categoria.Id}, " +
                        $"NOME: {categoria.Nome}, " +
                        $"CREATED DATE: {categoria.CreatedDate} , " +
                        $"DESCRICAO: {categoria.Descricao} , " +
                        $"LASTMODIFIEDDATE: {categoria.LastModifiedDate}");
                    return false;
                }

            }
            catch (DbUpdateException ex)
            {
                Log.Logger.Error("Erro: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Log.Logger.Error("Erro: " + ex.Message);
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
                        Log.Logger.Information("Categoria é null");
                        return false;
                    }
                }
                else
                {
                    Log.Logger.Information("Categoria não encontrada: " + id);
                    return false;
                }
            }
            catch (DbUpdateException ex)
            {
                Log.Logger.Error("Erro: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Log.Logger.Error("Erro: " + ex.Message);
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
                Log.Logger.Error("Erro: " + ex.Message);
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
                    Log.Logger.Information("Categoria não encontrada: " + id);
                    return null;
                }


            }
            catch (Exception ex)
            {
                Log.Logger.Error("Erro: " + ex.Message);
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
                        Log.Logger.Error($"Falha na atualização dos dados \n " +
                            $"ID: {categoria.Id}, " +
                            $"NOME: {categoria.Nome}, " +
                            $"CREATED DATE: {categoria.CreatedDate} , " +
                            $"DESCRICAO: {categoria.Descricao} , " +
                            $"LASTMODIFIEDDATE: {categoria.LastModifiedDate}");
                        return false;
                    }

                }
                else
                {
                    Log.Error("Categoria é null");
                    return false;

                }


            }
            catch (DbUpdateException ex)
            {
                Log.Logger.Error("Erro: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Log.Logger.Error("Erro: " + ex.Message);
                return false;
            }
        }

    }
}
