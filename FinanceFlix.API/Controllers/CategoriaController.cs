using FinanceFlix.Application.Interfaces;
using FinanceFlix.Application.ViewModels.Categoria.Request;
using Microsoft.AspNetCore.Mvc;

namespace FinanceFlix.API.Controllers
{
    [Route("Categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaApplicationService _categoriaService;

        public CategoriaController(ICategoriaApplicationService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categorias = await _categoriaService.GetAll();

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (_categoriaService.GetById == null)
                {
                    return NotFound();
                }
                else
                {
                    var categoria = await _categoriaService.GetById(id);
                    return Ok(categoria);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCategoriaRequestViewModel categoria)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (await _categoriaService.Add(categoria) == false)
                {
                    return BadRequest();
                }
                else
                {
                    return CreatedAtAction(nameof(GetById), new { id = categoria.Descricao }, categoria);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EditCategoriaRequestViewModel categoria)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }


                if (await _categoriaService.Update(categoria) != false)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {


                if (id.Equals(Guid.Empty))
                {
                    return BadRequest();
                }

                if (await _categoriaService.Delete(id) == false)
                {
                    return BadRequest();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); throw;
            }
        }

    }
}
