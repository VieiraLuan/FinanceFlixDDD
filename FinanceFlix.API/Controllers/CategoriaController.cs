using FinanceFlix.API.Entities;
using FinanceFlix.Application.Interfaces;
using FinanceFlix.Application.ViewModels;
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
        [Route("GetAll")]
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
        public async Task<IActionResult> GetById(int id)
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
        public async Task<IActionResult> Add([FromBody] CategoriaViewModel categoria)
        {
            try
            {
                if (categoria == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (await _categoriaService.Add(categoria) == false)
                {
                    return BadRequest();
                }
                else
                {
                    return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); throw;
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] CategoriaViewModel categoria)
        {
            try
            {
                if (categoria == null)
                {
                    return BadRequest();
                }

                if (await _categoriaService.Update(categoria) == false)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var categoria = await _categoriaService.GetById(id);

                if (categoria == null)
                {
                    return NotFound();
                }

                if (await _categoriaService.Delete(categoria) == false)
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
