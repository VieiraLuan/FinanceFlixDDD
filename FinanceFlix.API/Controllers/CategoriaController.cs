using FinanceFlix.API.Entities;
using FinanceFlix.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FinanceFlix.API.Controllers
{
    [Route("Categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            try
            {
                var categorias = _categoriaService.GetAll();

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            try
            {
                if (_categoriaService.GetById == null)
                {
                    return NotFound();
                }
                else
                {
                    var categoria = _categoriaService.GetById(id);
                    return Ok(categoria);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Add([FromBody] Categoria categoria)
        {
            try
            {
                if (categoria == null)
                {
                    return BadRequest();
                }

                if (_categoriaService.Add(categoria) == false)
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
        public  ActionResult Update([FromBody] Categoria categoria)
        {
            try
            {
                if (categoria == null)
                {
                    return BadRequest();
                }

                if (_categoriaService.Update(categoria) == false)
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
        public ActionResult Delete(Guid id)
        {
           try
            {
                var categoria = _categoriaService.GetById(id);

                if (categoria == null)
                {
                    return NotFound();
                }

                if (_categoriaService.Delete(categoria) == false)
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
