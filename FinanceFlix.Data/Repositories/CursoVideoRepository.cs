using FinanceFlix.Data.Context;
using FinanceFlix.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Data.Repositories
{
    public class CursoVideoRepository : ICursoVideoRepository
    {

        private readonly DataContext _context;


        public CursoVideoRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<bool> Delete(Guid id)
        {
            try
            {
                if (!id.Equals(Guid.Empty))
                {
                    var cursoVideo = await _context.CursosVideos.FindAsync(id);


                    if (cursoVideo != null)
                    {
                        _context.CursosVideos.Remove(cursoVideo);
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
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Erro ao deletar cursoVideo"); 
                return false;

            }
        }
    }
}
