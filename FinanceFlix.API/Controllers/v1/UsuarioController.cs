using FinanceFlix.Application.Interfaces;
using FinanceFlix.Application.ViewModels.Usuario.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceFlix.API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/Usuario")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioApplicationService _usuarioApplicationService;

        public UsuarioController(IUsuarioApplicationService usuarioApplicationService)
        {
            _usuarioApplicationService = usuarioApplicationService;
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginResponseViewModel usuarioLogin)
        {
            try
            {
                if (string.IsNullOrEmpty(usuarioLogin.Email) || string.IsNullOrEmpty(usuarioLogin.Senha))
                {
                    return BadRequest();
                }
                else
                {
                    var usuario = await _usuarioApplicationService.Login(usuarioLogin);

                    if (usuario != null)
                    {
                        return Ok(usuario);
                    }
                    else
                    {
                        return NotFound(new { Status = "Error", Message = "Usuário ou senha inválidos." });
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Erro ao tentar fazer login: " + ex.Message);         
                
            }
        }

        [HttpPost]
        [Route("AddUser")]
        [AllowAnonymous]
        public async Task<IActionResult> Add(AddUsuarioRequestViewModel usuario)
        {
            try
            {
                if (usuario != null)
                {
                    var usuarioAdd = await _usuarioApplicationService.Add(usuario);

                    if (usuarioAdd)
                    {
                        return Ok("Usuário cadastrado com sucesso");
                    }
                    else
                    {
                        return BadRequest("Erro ao cadastrar usuário");
                    }
                }
                else
                {
                    return BadRequest("Erro ao cadastrar usuário");
                }

            }
            catch (Exception)
            {
                return BadRequest("Erro ao cadastrar usuário");
                throw;
            }
        }

    }
}
