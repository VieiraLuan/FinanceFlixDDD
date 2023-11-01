using FinanceFlix.API.Entities;
using FinanceFlix.Application.Interfaces;
using FinanceFlix.Application.ViewModels.Usuario.Request;
using FinanceFlix.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioApplicationService(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<UsuarioResponseViewModel> Get(LoginResponseViewModel usuarioLogin)
        {
            try
            {
                if (String.IsNullOrEmpty(usuarioLogin.Email) || String.IsNullOrEmpty(usuarioLogin.Senha))
                {
                    return null;
                }
                else
                {
                    //Continuar daqui
                    var usuarioEntity = new Usuario(usuarioLogin.Email, usuarioLogin.Senha);
                }

                return null;



            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> Add(AddUsuarioRequestViewModel usuario)
        {
            try
            {
                if (usuario != null)
                {
                    var usuarioEntity = new Usuario(usuario.Nome, usuario.Email, usuario.Senha, usuario.Tipo, usuario.FotoUrl);
                    return await _usuarioService.Add(usuarioEntity);
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
                    return await _usuarioService.Delete(id);
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

        public async Task<bool> Update(EditUsuarioRequestViewModel usuario)
        {
            try
            {
                if (usuario != null)
                {
                    var usuarioEntity = new Usuario(usuario.Id, DateTime.Now, usuario.Nome, usuario.Email, usuario.Senha, usuario.Tipo, usuario.FotoUrl);
                    return await _usuarioService.Update(usuarioEntity);
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
