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
        private readonly ITokenApplicationService _tokenService;

        public UsuarioApplicationService(IUsuarioService usuarioService, ITokenApplicationService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        public async Task<UsuarioResponseViewModel> Login(LoginResponseViewModel usuarioLogin)
        {
            try
            {


                var usuario = await _usuarioService.Get(usuarioLogin.Email, usuarioLogin.Senha);

                if (usuario != null)
                {
                    var token = _tokenService.GenerateToken(usuario);

                    var usuarioResponse = new UsuarioResponseViewModel
                    {
                        Id = usuario.Id,
                        Token = token,
                        Email = usuarioLogin.Email,
                        Nome = usuario.Nome,
                        Tipo = usuario.Tipo,
                        FotoUrl = usuario.FotoUrl

                    };

                    return usuarioResponse;

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
        public async Task<bool> Add(AddUsuarioRequestViewModel usuario)
        {
            try
            {
                if (usuario != null)
                {   
                    if(_usuarioService.Get(usuario.Email, usuario.Senha) != null)
                    {
                        return false;
                    }

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
