using FinanceFlix.API.Entities;
using FinanceFlix.Data.Context;
using FinanceFlix.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    await _context.Usuarios.AddAsync(usuario);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                //Logar erro
                return false;
                throw;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                if (!id.Equals(Guid.Empty))
                {
                    var usuario = await _context.Usuarios.FindAsync(id);

                    if (usuario != null)
                    {
                        _context.Usuarios.Remove(usuario);
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    return false;
                }
                return false;

            }
            catch (Exception)
            {
                //Logar erro
                return false;
                throw;
            }
        }

        public async Task<Usuario> Get(string email, string senha)
        {
            try
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(senha))
                {
                    var usuario = await _context.Usuarios
                        .Where(x => x.Email == email && x.Senha == senha).FirstOrDefaultAsync();
                    return usuario;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public async Task<bool> Update(Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    _context.Usuarios.Update(usuario);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                //Logar erro
                return false;
                throw;
            }
        }
    }
}
