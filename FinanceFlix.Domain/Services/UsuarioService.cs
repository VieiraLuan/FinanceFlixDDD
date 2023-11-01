using FinanceFlix.API.Entities;
using FinanceFlix.Domain.Interfaces.IRepositories;
using FinanceFlix.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Add(Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    return await _usuarioRepository.Add(usuario);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
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
                    return await _usuarioRepository.Delete(id);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public async Task<Usuario> Get(string email, string senha)
        {
            try
            {
                if (String.IsNullOrEmpty(email) == false || String.IsNullOrEmpty(senha) == false)
                {
                    return await _usuarioRepository.Get(email, senha);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<bool> Update(Usuario usuario)
        {
            try
            {
                if(usuario != null)
                {
                    return await _usuarioRepository.Update(usuario);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
